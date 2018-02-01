

namespace Spike.Tests
{
    public enum ResolveBy
    {
        Default,
        StubbedVersion,
        LatestVersion
    }

    public abstract class BaseTestClass
    {
        public static ResolveBy? Resolver { get; set; } = null;

        public static string TypeOfResolver
        {
            get
            {
                return Resolver?.ToString() ?? null;
            }
        }

        public BaseTestClass(ResolveBy? resolver = null)
        {
            if (resolver != null && resolver != ResolveBy.Default)
            {
                Resolver = resolver;
            }           
        }

    }
}
