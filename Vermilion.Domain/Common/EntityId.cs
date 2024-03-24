namespace Vermilion.Domain.Common
{
    public abstract record EntityId
    {
        public Guid Value { get; private set; }
        protected EntityId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentException("Id can't be null");
            }
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
