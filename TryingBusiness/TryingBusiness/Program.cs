using SimpleInjector;
using UsefullStuff;

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