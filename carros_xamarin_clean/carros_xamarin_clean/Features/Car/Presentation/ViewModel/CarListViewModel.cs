using carros_xamarin_clean.Core.Presentation;
using carros_xamarin_clean.Features.Car.Domain.UseCases.Interface;
using carros_xamarin_clean.Features.Car.Presentation.Pages;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_xamarin_clean.Features.Car.Presentation.ViewModel
{
    public class CarListViewModel : ViewModelBase
    {
        private readonly ICarUseCase _carUseCase;

        public CarListViewModel(
            INavigationService navigationService,
            ICarUseCase carUseCase) : base(navigationService)
        {
            _carUseCase = carUseCase;

            RefreshCommand = new Command(async () => await RefreshExecute());
            ItemClickCommand = new Command<Domain.Entities.Car>(async (x) => await ItemClickExecute(x));

            Load();
        }

        private ObservableCollection<Domain.Entities.Car> items;
        public ObservableCollection<Domain.Entities.Car> Items
        {
            get => this.items;
            set
            {
                this.items = value;
                RaisePropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }

        public async Task RefreshExecute()
        {
            await ExecuteBusyAction(async () =>
           {
               var cars = await _carUseCase.Download();
               Items = new ObservableCollection<Domain.Entities.Car>(cars);
           });
        }

        private async void Load()
        {
            await ExecuteBusyAction(async () =>
            {
                var cars = await _carUseCase.GetCarsAsync();
                Items = new ObservableCollection<Domain.Entities.Car>(cars);
            });
        }

        private async Task ItemClickExecute(Domain.Entities.Car car)
        {
            var parameters = new NavigationParameters { { nameof(car), car } };
            await this.NavigationService.NavigateAsync(nameof(CarDetailView), parameters);
        }
    }
}
