namespace Vermilion.Domain.ValueObjects
{
    public record Address
    {
        public Address(string street, string city, string state, string zipCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public string Street { get; private set; } // Название улицы
        public string City { get; private set; } // Город
        public string State { get; private set; } // Область
        public string ZipCode { get; private set; } // Почтовый индекс
        public string Country { get; private set; } // Страна
        public override string ToString()
        {
            return $"{Street}, {City}, {State} {ZipCode}, {Country}";
        }
    }
}