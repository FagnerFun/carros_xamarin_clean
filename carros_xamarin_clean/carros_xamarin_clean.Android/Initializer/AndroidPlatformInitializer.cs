using carros_xamarin_clean.Core.Domain.Interface;
using carros_xamarin_clean.Droid.Util;
using Prism;
using Prism.Ioc;

namespace carros_xamarin_clean.Droid.Initializer
{
    public class AndroidPlatformInitializer: IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDataBaseAccessPlataform, DataBaseAccessService>();
        }
    }
}