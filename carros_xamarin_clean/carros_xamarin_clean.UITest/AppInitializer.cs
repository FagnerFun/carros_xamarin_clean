using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace carros_xamarin_clean.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("com.fagnerfun.carrosclean")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS
                .EnableLocalScreenshots()
                .StartApp();
        }
    }
}