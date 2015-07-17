namespace FacConvention
{
    using System.Reflection;

    using Autofac;

    public interface IAutofacConvention
    {        
        void Register(ContainerBuilder builder, Assembly[] assemblies);
    }
}