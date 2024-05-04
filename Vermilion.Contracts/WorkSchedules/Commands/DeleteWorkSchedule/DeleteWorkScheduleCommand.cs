using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Contracts.WorkSchedules.Commands.DeleteWorkSchedule
{
    public sealed record DeleteWorkScheduleCommand(WorkScheduleId Id);
}
