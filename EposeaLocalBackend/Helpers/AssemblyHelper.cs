using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace EposeaLocalBackend.API.Helpers
{
    public static class AssemblyHelper
    {
        public static Assembly[] GetSolutionAssemblies()
        {
            return new[]
            {
                typeof(ServiceCollectionExtensions).Assembly,
                typeof(Data.Infrastructure.IRegisterDependency).Assembly,
                typeof(Business.Infrastructure.IRegisterDependency).Assembly,
                typeof(Core.Infrastructure.IRegisterDependency).Assembly,
            };
        }
    }
}
