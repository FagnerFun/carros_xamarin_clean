using carros_xamarin_clean.Core.Presentation;
using Prism.Navigation;

namespace carros_xamarin_clean.Features.Car.Presentation.ViewModel
{
    public class CarDetailViewModel : ViewModelBase
    {
        public CarDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private Domain.Entities.Car car;
        public Domain.Entities.Car Car
        {
            get => car;
            set
            {
                car = value;
                RaisePropertyChanged();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Car = parameters.GetValue<Domain.Entities.Car>(nameof(car));
        }
    }
}
