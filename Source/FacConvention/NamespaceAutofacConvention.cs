namespace FacConvention
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Autofac;

    public abstract class NamespaceAutofacConvention : IAutofacConvention
    {
        private readonly IDictionary<string, BuilderDelegate> namespaceRegistrations;

        public void Register(ContainerBuilder builder, Assembly[] assemblies)
        {
            foreach (var keyValuePair in this.namespaceRegistrations)
            {
                var @namespace = keyValuePair.Key;
                var registrationBuilder = builder
                    .RegisterAssemblyTypes(assemblies)
                    .Where(t => IsNamespaceMatch(t, @namespace));

                keyValuePair.Value(registrationBuilder);
            }
        }  

        protected NamespaceAutofacConvention()
        {
            this.namespaceRegistrations = new Dictionary<string, BuilderDelegate>();
        }    

        protected void AddNamespaceConvention(string @namespace, BuilderDelegate builder)
        {
            if (string.IsNullOrWhiteSpace(@namespace))
            {
                throw new ArgumentNullException("namespace");
            }

            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            if (this.namespaceRegistrations.ContainsKey(@namespace))
            {
                throw new InvalidOperationException(string.Format("The namespace '{0}' has already been registered.", @namespace));
            }

            this.namespaceRegistrations.Add(@namespace, builder);
        }

        private static bool IsNamespaceMatch(Type type, string @namespace)
        {
            return type.Namespace != null && type.Namespace.EndsWith(@namespace);
        }
    }
}