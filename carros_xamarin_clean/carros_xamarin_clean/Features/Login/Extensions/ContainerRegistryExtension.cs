using carros_xamarin_clean.Features.Login.Data.DataSources;
using carros_xamarin_clean.Features.Login.Data.Repositories;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using carros_xamarin_clean.Features.Login.Domain.UseCases;
using carros_xamarin_clean.Features.Login.Domain.UseCases.Interface;
using carros_xamarin_clean.Features.Login.Presentation.Pages;
using carros_xamarin_clean.Features.Login.Presentation.ViewModel;
using Prism.Ioc;
using Refit;

namespace carros_xamarin_clean.Features.Login.Extensions
{
    public static class ContainerRegistryExtension
    {
        public static void RegisterLogin(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterNavigation();
            containerRegistry.RegisterUseCase();
            containerRegistry.RegisterRepository();
            containerRegistry.RegisterAPI();
        }

        private static void RegisterNavigation(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
        }

        private static void RegisterUseCase(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginUseCase, LoginUseCase>();
        }

        private static void RegisterRepository(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUserRepository, UserRepository>();
        }

        private static void RegisterAPI(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(RestService.For<ILoginClient>(AppSettings.ApiUrl));
        }
    }
}
