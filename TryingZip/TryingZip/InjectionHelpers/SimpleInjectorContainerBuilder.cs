using SimpleInjector;

namespace TryingZip.InjectionHelpers;

public class SimpleInjectorContainerBuilder
{
    private readonly Container _container;

    public SimpleInjectorContainerBuilder()
    {
        _container = new Container();
    }

    public SimpleInjectorContainerBuilder Register<TConcrete>()
        where TConcrete : class
    {
        _container.Register<TConcrete>();
        return this;
    }

    public SimpleInjectorContainerBuilder Register<TService, TImplementation>()
        where TService : class
        where TImplementation : class, TService
    {
        _container.Register<TService, TImplementation>();
        return this;
    }

    public Container VerifyAndGetContainer()
    {
        _container.Verify();
        return _container;
    }
}