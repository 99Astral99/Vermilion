using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Vermilion.Infrastructure.Converters
{
    public class DayOfWeekConverter : ValueConverter<DayOfWeek, string>
    {
        public DayOfWeekConverter()
         : base(
             coreValue => ToString(coreValue),
             efValue => FromString(efValue))
        {
        }

        private static string ToString(DayOfWeek type)
        {
            return type switch
            {
                DayOfWeek.Monday => "Monday",
                DayOfWeek.Tuesday => "Tuesday",
                DayOfWeek.Wednesday => "Wednesday",
                DayOfWeek.Thursday => "Thursday",
                DayOfWeek.Friday => "Friday",
                DayOfWeek.Saturday => "Saturday",
                DayOfWeek.Sunday => "Sunday",
                _ => throw new NotImplementedException(),
            };
        }

        private static DayOfWeek FromString(string type)
        {
            return type.ToUpper() switch
            {
                "Monday" => DayOfWeek.Monday,
                "Tuesday" => DayOfWeek.Tuesday,
                "Wednesday" => DayOfWeek.Wednesday,
                "Thursday" => DayOfWeek.Thursday,
                "Friday" => DayOfWeek.Friday,
                "Saturday" => DayOfWeek.Saturday,
                "Sunday" => DayOfWeek.Sunday,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
