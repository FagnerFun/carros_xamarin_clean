using carros_xamarin_clean.Core.Presentation;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace carros_xamarin_clean.Features.Car.Presentation.ViewModel
{
    public class CarViewModel : ViewModelBase
    {
        public CarViewModel(INavigationService navigationService) : base(navigationService)
        {
        }


    }
}
