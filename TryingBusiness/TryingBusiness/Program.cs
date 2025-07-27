using SimpleInjector;
using UsefullStuff.InjectionHelpers;

namespace TryingBusiness;

public class Program
{
    public static void Main(string[] args)
    {
    }

    private static Container GetContainer() =>
        new SimpleInjectorContainerBuilder()
        .Build();
}