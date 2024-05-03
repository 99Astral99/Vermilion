using FluentResults;
using MediatR;
using Vermilion.Contracts.Responses.WorkSchedules;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.WorkSchedules.Commands.CreateWorkSchedule
{
    public record CreateWorkScheduleCommand(DayOfWeek dayOfWeek, TimeSpan StartTime, TimeSpan EndTime,
        bool isDayOff, CateringId CateringId) : IRequest<Result<ResponseWorkSchedule>>;
}
