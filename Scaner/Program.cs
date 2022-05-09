using Scaner.ScanerLibrary;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Scaner.ScanerLibrary.Scaner;
using Scaner.ScanerLibrary.Interfaces;

namespace Scaner;
class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ScanerDevice>().As<IScanerDevice>().SingleInstance();
        IContainer container = builder.Build();
        
        IScanerDevice device = container.Resolve<IScanerDevice>();

        device.Scan();
    }
}
