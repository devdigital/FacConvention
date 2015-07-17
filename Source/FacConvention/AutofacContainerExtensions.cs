namespace FacConvention
{
    using System;
    using System.Reflection;

    using Autofac;

    public static class AutofacContainerExtensions
    {
        public static void RegisterConvention(
            this ContainerBuilder builder,
            Func<bool> predicate,
            IAutofacConvention convention,
            params Assembly[] assemblies)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            if (!predicate())
            {
                return;
            }
            
            RegisterConvention(builder, convention, assemblies);
        }

        public static void RegisterConvention(
            this ContainerBuilder builder,
            IAutofacConvention convention,
            params Assembly[] assemblies)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (convention == null)
            {
                throw new ArgumentNullException("convention");
            }

            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }
            
            convention.Register(builder, assemblies);
        }
    }
}