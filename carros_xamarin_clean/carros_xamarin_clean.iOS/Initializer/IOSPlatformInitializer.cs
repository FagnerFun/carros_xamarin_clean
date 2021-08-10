using carros_xamarin_clean.Core.Domain.Interface;
using carros_xamarin_clean.iOS.Util;
using Prism;
using Prism.Ioc;

namespace carros_xamarin_clean.iOS.Initializer
{
    public class IOSPlatformInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataBaseAccessPlataform, DataBaseAccessService>();
        }
    }
}