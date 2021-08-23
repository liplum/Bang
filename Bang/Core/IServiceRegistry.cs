namespace Bang.Services;
public interface IServiceRegistry
{
    public void RegisterSingleton<Interface, Clz>() where Interface : IInjectable where Clz : Interface, new();

    public void RegisterTransient<Interface, Clz>() where Interface : IInjectable where Clz : Interface, new();

    public void RegisterInstance<Clz>(Clz obj);
}
