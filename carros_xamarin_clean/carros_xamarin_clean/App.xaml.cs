using carros_xamarin_clean.Features.Car.Extension;
using carros_xamarin_clean.Features.Car.Presentation.Pages;
using carros_xamarin_clean.Features.Login;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using carros_xamarin_clean.Features.Login.Extensions;
using carros_xamarin_clean.Features.Login.Presentation.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace carros_xamarin_clean
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnStart()
        {
            base.OnStart();

            AppCenter.Start($"android={AppSettings.AppCenterAndroidKey};ios={AppSettings.AppCenterIosKey};", typeof(Analytics), typeof(Crashes));
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var userRepository = Container.GetContainer().GetService(typeof(IUserRepository)) as IUserRepository;
            if (userRepository.Get() == null)
            {
                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LoginView)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(CarView)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterLogin();
            containerRegistry.RegisterCar();
        }
    }
}
