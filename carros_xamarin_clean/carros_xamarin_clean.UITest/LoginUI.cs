using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using carros_xamarin_clean.Core.Resources;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace carros_xamarin_clean.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class LoginUI
    {
        IApp app;
        Platform platform;

        static readonly Func<AppQuery, AppQuery> InitialMessage = c => c.Marked("LoginButton").Text(Resource.login);
        static readonly Func<AppQuery, AppQuery> UserEntry = c => c.Marked("UserEntry");
        static readonly Func<AppQuery, AppQuery> PasswordEntry = c => c.Marked("PasswordEntry");
        static readonly Func<AppQuery, AppQuery> LoginButton = c => c.Marked("LoginButton");
        static readonly Func<AppQuery, AppQuery> CarSreen = c => c.Marked("Carros");

        public LoginUI(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void LoginScreenIsDisplayed()
        //{
        //    List<AppResult> results = new List<AppResult>();

        //    results.AddRange(app.Query(InitialMessage));
        //    app.Screenshot("Login screen.");

        //    Assert.IsTrue(results.Any());
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

            Assert.IsTrue(results.Any());
        }
    }
}
