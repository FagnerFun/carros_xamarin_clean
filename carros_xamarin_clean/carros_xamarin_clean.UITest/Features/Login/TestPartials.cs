using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace carros_xamarin_clean.UITest.Base
{
    public static class Global
    {
        public static Platform Platform { get; set; }
        public static IApp App { get; set; }
    }

    [TestFixture(Platform.iOS)]
    [TestFixture(Platform.Android)]
    public partial class LoginRequirementsFeature
    {
        public LoginRequirementsFeature(Platform platform)
        {
            Global.Platform = platform;
        }
    }
}
