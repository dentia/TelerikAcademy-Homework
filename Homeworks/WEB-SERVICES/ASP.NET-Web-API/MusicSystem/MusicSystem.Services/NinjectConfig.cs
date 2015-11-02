namespace MusicSystem.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using MusicSystem.Data.Repositories;

    using Ninject;

    public static class NinjectConfig
    {
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Needed for Ninject.")]
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            kernel.Bind<IMusicSystemData>().To<MusicSystemData>();
        }
    }
}