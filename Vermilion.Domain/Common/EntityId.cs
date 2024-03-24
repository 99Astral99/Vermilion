namespace Vermilion.Domain.Common
{
    public abstract record EntityId
    {
        protected string Value { get; private set; }
        protected EntityId(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Id can't be null");
            }
            Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
