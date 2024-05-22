using FluentResults;
using MediatR;
using Minio.DataModel.Response;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.CateringImages.Commands.UploadCateringImage
{
    public sealed record UploadCateringImageCommand(Stream fileStream, string Name, string contentType, CateringId cateringId) : IRequest<Result<PutObjectResponse>>;
}
