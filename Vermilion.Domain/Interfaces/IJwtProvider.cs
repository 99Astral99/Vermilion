using Vermilion.Domain.Entities;

namespace Vermilion.Domain.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
