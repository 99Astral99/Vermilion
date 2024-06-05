using System.Reflection;

namespace Vermilion.Contracts
{
    public static class AssemblyMarker
    {
        public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
    }
}
