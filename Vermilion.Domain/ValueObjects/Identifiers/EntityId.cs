namespace Vermilion.Domain.ValueObjects.Identifiers
{
    public abstract record EntityId
    {
        protected readonly string Value;
        protected EntityId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("ID не может быть null");
            }
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
