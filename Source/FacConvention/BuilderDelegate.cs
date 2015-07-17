namespace FacConvention
{
    using Autofac.Builder;
    using Autofac.Features.Scanning;

    public delegate IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> BuilderDelegate(
        IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder);
}