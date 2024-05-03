using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vermilion.Contracts.Responses.WorkSchedules;
using Vermilion.Contracts.WorkSchedules.Commands.CreateWorkSchedule;
using Vermilion.Domain.Entities;
using Vermilion.Domain.Repositories;

namespace Vermilion.Application.Handlers.WorkSchedules
{
    public class WorkScheduleCommandHandler
        : IRequestHandler<CreateWorkScheduleCommand, Result<ResponseWorkSchedule>>
    {
        private readonly IRepository<WorkSchedule> _workScheduleRepository;
        private readonly IMapper _mapper;
        public WorkScheduleCommandHandler(IRepository<WorkSchedule> workScheduleRepository, IMapper mapper)
        {
            _workScheduleRepository = workScheduleRepository;
            _mapper = mapper;
        }

        public async Task<Result<ResponseWorkSchedule>> Handle(CreateWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var workScheduleToCreate = WorkSchedule.Create(request.dayOfWeek, request.StartTime, request.EndTime, request.isDayOff, request.CateringId).Value;
            await _workScheduleRepository.AddAsync(workScheduleToCreate);

            return Result.Ok(_mapper.Map<ResponseWorkSchedule>(workScheduleToCreate));
        }
    }
}
