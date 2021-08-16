using Xamarin.UITest;
using TechTalk.SpecFlow;

namespace carros_xamarin_clean.UITest.Base
{
    [Binding]
    public class SetupSteps
    {
        [Given("a started app")]
        public void TheMainPageIsDisplayed()
        {
            if (Global.Platform == Platform.iOS)
            {
                Global.App = ConfigureApp.iOS.StartApp();
            }
            else
            {
                Global.App = ConfigureApp
                    .Android
                    .InstalledApp("com.fagnerfun.carrosclean")
                    .PreferIdeSettings()
                    .EnableLocalScreenshots()
                    .StartApp();
            }
        }
    }
}
