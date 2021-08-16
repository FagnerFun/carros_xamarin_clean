using carros_xamarin_clean.Core.Resources;
using carros_xamarin_clean.UITest.Base;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest.Queries;


namespace carros_xamarin_clean.UITest.Features.Login
{
    [Binding]
    [Scope(Feature = "LoginRequirements")]
    public class LoginRequirementsSteps
    {
        static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("LoginButton").Text(Resource.login);
        static readonly Func<AppQuery, AppQuery> UserEntry = c => c.Marked("UserEntry");
        static readonly Func<AppQuery, AppQuery> PasswordEntry = c => c.Marked("PasswordEntry");
        static readonly Func<AppQuery, AppQuery> LoginButton = c => c.Marked("LoginButton");
        static readonly Func<AppQuery, AppQuery> CarSreen = c => c.Marked("Carros");


        [Given(@"an user at login screen")]
        public void LoginScreenIsDisplayed()
        {
            Global.App.Query(InitialMessage);
            Global.App.Screenshot("Login screen.");
        }

        [When(@"he populate user field")]
        public void PopulateUserField()
        {
            Global.App.EnterText(UserEntry, "user");
        }

        [When(@"he populate password field")]
        public void PopulatePasswordField()
        {
            Global.App.EnterText(PasswordEntry, "123");
        }

        [When(@"he press login button")]
        public void PressLoginButton()
        {
            Global.App.Tap(LoginButton);
        }

        [Then(@"he is allowed to access app")]
        public void CarScreenIsDisplayed()
        {
            Global.App.WaitForElement(CarSreen, "Não foi possivel navegar para carros", TimeSpan.FromMinutes(1));
            Global.App.Screenshot("Cars.");
        }
    }
}
