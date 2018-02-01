

namespace Spike.Adapters.Database
{
    public static class ContextFactory
    {
        public static IDataContext Create()
        {
            return new DataContext();
        }
    }
}
