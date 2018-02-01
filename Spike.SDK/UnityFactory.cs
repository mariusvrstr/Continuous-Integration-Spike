
namespace Spike.SDK
{
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using Unity;

    public static class UnityFactory
    {
        private const string UnitySection = "unity";
        public static IUnityContainer Container { get; private set; }

        static UnityFactory()
        {
            try
            {
                var section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnitySection);
                var container = new UnityContainer();
                section?.Configure(container);
                Container = container;
            }
            catch (Exception ex)
            {
                var errorDetails = $"Failed to initialize Unity Factotory, please check configuration including [{UnitySection}]";
                //Logger.Error(errorDetails);
                ex.Data.Add("Failed Unity DI Initialization", errorDetails);
            }
        }

        private static string GetRequestContext(StackTrace stackTrace, Type contractType)
        {
            return $"Failed for type [{contractType}] from [{stackTrace.GetFrame(1)?.GetMethod()?.ReflectedType?.FullName ?? "?"}.{stackTrace.GetFrame(1).GetMethod().Name}]";
        }

        public static T Resolve<T>(string name = null)
        {
            try
            {
                T resolved;
                if (Container.IsRegistered<T>(name))
                {
                    resolved = Container.Resolve<T>(name);
                }
                else
                {
                    throw new Exception($"Unity DI Resolution Failed - [{typeof(T)}] does not have a mapping registered.");
                }

                if (resolved != null) return resolved;

                throw new Exception($"Unity DI Resolution Failed - [{typeof(T)}] mapping did not succeed."); ;
            }
            catch (Exception ex)
            {
                var errorDetails = GetRequestContext(new StackTrace(), typeof(T));
                //Logger.Error(errorDetails);
                ex.Data.Add("Failed Unity DI Concretion Resolution", errorDetails);

                throw;
            }
        }
    }
}
