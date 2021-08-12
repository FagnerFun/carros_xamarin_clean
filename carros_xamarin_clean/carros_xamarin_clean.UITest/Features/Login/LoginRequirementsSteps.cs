using carros_xamarin_clean.Core.Resources;
using NUnit.Framework;
//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace carros_xamarin_clean.UITest.Features.Login
{
    //[Binding]
    //[Scope(Feature = "LoginRequirements")]
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class LoginRequirementsSteps
    {
        IApp app;
        readonly Platform platform;

        static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("LoginButton").Text(Resource.login);
        static readonly Func<AppQuery, AppQuery> UserEntry = c => c.Marked("UserEntry");
        static readonly Func<AppQuery, AppQuery> PasswordEntry = c => c.Marked("PasswordEntry");
        static readonly Func<AppQuery, AppQuery> LoginButton = c => c.Marked("LoginButton");
        static readonly Func<AppQuery, AppQuery> CarSreen = c => c.Marked("Carros");

        public LoginRequirementsSteps(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Given(@"an user at login screen")]
        //public void LoginScreenIsDisplayed()
        //{
        //    List<AppResult> results = new List<AppResult>();

        //    results.AddRange(app.Query(InitialMessage));
        //    app.Screenshot("Login screen.");

        //    //Assert.IsTrue(results.Any());
        //}

        //[When(@"he populate user field")]
        //public void PopulateUserField()
        //{
        //    app.EnterText(UserEntry, "user");
        //}

        //[When(@"he populate password field")]
        //public void PopulatePasswordField()
        //{
        //    app.EnterText(PasswordEntry, "123");
        //}

        //[When(@"he press login button")]
        //public void PressLoginButton()
        //{
        //    app.Tap(LoginButton);
        //}

        //[Then(@"he is allowed to access app")]
        //public void CarScreenIsDisplayed()
        //{
        //    List<AppResult> results = new List<AppResult>();
        //    results.AddRange(app.WaitForElement(CarSreen, "Não foi possivel navegar para carros"));
        //    app.Screenshot("Cars.");
        //    //Assert.IsTrue(results.Any());
        //}

        [Test]
        public void LoginSuccessfully()
        {
            List<AppResult> results = new List<AppResult>();

            results.AddRange(app.Query(InitialMessage));

            app.EnterText(UserEntry, "user");
            app.EnterText(PasswordEntry, "123");
            app.Tap(LoginButton);

            results.AddRange(app.WaitForElement(CarSreen, "Não foi possivel navegar para carros"));
            app.Screenshot("Cars.");

            //Assert.IsTrue(results.Any());
        }
    }
}
