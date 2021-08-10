using carros_xamarin_clean.Features.Car.Data.DataSources;
using carros_xamarin_clean.Features.Car.Data.Repositories;
using carros_xamarin_clean.Features.Car.Domain.Repositories;
using carros_xamarin_clean.Features.Car.Domain.UseCases;
using carros_xamarin_clean.Features.Car.Domain.UseCases.Interface;
using carros_xamarin_clean.Features.Car.Presentation.Pages;
using carros_xamarin_clean.Features.Car.Presentation.ViewModel;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using Prism.DryIoc;
using Prism.Ioc;
using Refit;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Car.Extension
{
    public static class ContainerRegistryExtension
    {
        public static void RegisterCar(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterNavigation();
            containerRegistry.RegisterUseCase();
            containerRegistry.RegisterRepository();
            containerRegistry.RegisterAPI();
        }

        private static void RegisterNavigation(this IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CarView, CarViewModel>();
            containerRegistry.RegisterForNavigation<CarViewFlyout, CarViewFlyoutViewModel>();
            containerRegistry.RegisterForNavigation<CarListView, CarListViewModel>();
            containerRegistry.RegisterForNavigation<CarDetailView, CarDetailViewModel>();
        }

        private static void RegisterUseCase(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICarUseCase, CarUseCase>();
        }

        private static void RegisterRepository(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICarRepository, CarRepository>();
        }

        private static void RegisterAPI(this IContainerRegistry containerRegistry)
        {
            var appContainer = containerRegistry.GetContainer();
            var userRepository = (IUserRepository)appContainer.GetService(typeof(IUserRepository));

            var authenticaRefitSettings = new RefitSettings()
            {
                AuthorizationHeaderValueGetter = () => Task.Run(() => userRepository.Get()?.Token),
            };

            containerRegistry.RegisterInstance(RestService.For<ICarClient>(AppSettings.ApiUrl, authenticaRefitSettings));
        }
    }
}
