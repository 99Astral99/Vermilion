using FluentResults;
using Vermilion.Domain.Common;
using Vermilion.Domain.Interfaces;
using Vermilion.Domain.ValueObjects.Identifiers;

namespace Vermilion.Domain.Entities
{
    public class CateringImage : Entity<CateringImageId>, IAuditable
    {
        private CateringImage(CateringImageId id, string name, long size, CateringId cateringId) : base(id)
        {
            Name = name;
            CateringId = cateringId;
            Size = size;
        }

        public string Name { get; private set; }

        public long Size { get; private set; }

        public CateringId CateringId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public static Result<CateringImage> Create(string name, long size, CateringId cateringId)
        {
            var id = new CateringImageId(Guid.NewGuid());
            var cateringImage = new CateringImage(id, name, size, cateringId);

            return Result.Ok(cateringImage);
        }
    }
}
