using AutoMapper;
using FluentResults;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel.Response;
using Vermilion.Application.Common.Exceptions;
using Vermilion.Contracts.CateringImages.Commands.DeleteCateringImage;
using Vermilion.Contracts.CateringImages.Commands.UploadCateringImage;
using Vermilion.Contracts.CateringImages.Queries.GetCateringImage;
using Vermilion.Contracts.Responses.CateringImage;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.CateringImages
{
    public class CateringImageHandler :
        IRequestHandler<GetCateringImageQuery, Result<ResponseCateringImage>>,
        IRequestHandler<DeleteCateringImageCommand, Result>,
        IRequestHandler<UploadCateringImageCommand, Result<PutObjectResponse>>
    {
        private readonly static string _bucketName = "images";
        private readonly IMinioClient _minioClient;
        private readonly IRepository<CateringImage> _cateringImageRepository;
        private readonly IMapper _mapper;

        public CateringImageHandler(IMinioClient minioClient, IRepository<CateringImage> cateringImageRepository, IMapper mapper)
        {
            _minioClient = minioClient;
            _cateringImageRepository = cateringImageRepository;
            _mapper = mapper;
        }


        public async Task<Result<ResponseCateringImage>> Handle(GetCateringImageQuery request, CancellationToken cancellationToken)
        {
            var cateringImage = await _cateringImageRepository.GetByIdAsync(request.Id, cancellationToken);

            if (cateringImage is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(CateringImage)}\" with ID: {request.Id.Value} was not found", new NotFoundException()));

            return Result.Ok(_mapper.Map<ResponseCateringImage>(cateringImage));
        }

        public async Task<Result<PutObjectResponse>> Handle(UploadCateringImageCommand request, CancellationToken cancellationToken)
        {
            var args = new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(request.Name)
                .WithStreamData(request.fileStream)
                .WithObjectSize(request.fileStream.Length)
                .WithContentType("image/png");

            var res = await _minioClient.PutObjectAsync(args);

            var cateringImage = CateringImage.Create(request.Name, res.Size, request.cateringId).Value;
            await _cateringImageRepository.AddAsync(cateringImage);  

            return Result.Ok(res);
        }

        public async Task<Result> Handle(DeleteCateringImageCommand request, CancellationToken cancellationToken)
        {
            var args = new RemoveObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(request.fileName);

            await _minioClient.RemoveObjectAsync(args, cancellationToken);

            var existCateringImage = await _cateringImageRepository.GetByIdAsync(request.cateringId);

            if (existCateringImage is null)
                return Result.Fail(new ExceptionalError($"\"{nameof(CateringImage)}\" with ID: {request.cateringId.Value} was not found", new NotFoundException()));

            await _cateringImageRepository.DeleteAsync(existCateringImage, cancellationToken);

            return Result.Ok();
        }

        public async Task EnsureBucketExistsAsync(string bucketName)
        {
            var args = new BucketExistsArgs().WithBucket(bucketName);

            var isExist = await _minioClient.BucketExistsAsync(args);
            if (isExist) return;

            var makeArgs = new MakeBucketArgs().WithBucket(bucketName);
            await _minioClient.MakeBucketAsync(makeArgs);
        }
    }
}
