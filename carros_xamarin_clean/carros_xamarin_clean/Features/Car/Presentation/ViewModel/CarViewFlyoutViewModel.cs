using carros_xamarin_clean.Core.Domain.Entity;
using carros_xamarin_clean.Core.Presentation;
using carros_xamarin_clean.Core.Resources;
using carros_xamarin_clean.Features.Login.Domain.Entities;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using carros_xamarin_clean.Features.Login.Presentation.Pages;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_xamarin_clean.Features.Car.Presentation.ViewModel
{
    public class CarViewFlyoutViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;
        private readonly IUserRepository _userRepository;

        public CarViewFlyoutViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IUserRepository userRepository) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _userRepository = userRepository;

            ItemCommand = new Command<CarViewFlyoutMenuItem>(ItemClickExecute);
            MenuItems = new ObservableCollection<CarViewFlyoutMenuItem>(new[]
            {
                new CarViewFlyoutMenuItem { Id = 0, Title = "Logout", TargetAction = async () => await Logout() },
                new CarViewFlyoutMenuItem { Id = 1, Title = "Logout", TargetAction = async () => await Logout() },
                new CarViewFlyoutMenuItem { Id = 2, Title = "Logout", TargetAction = async () => await Logout() },
                new CarViewFlyoutMenuItem { Id = 3, Title = "Logout", TargetAction = async () => await Logout() },
                new CarViewFlyoutMenuItem { Id = 4, Title = "Logout", TargetAction = async () => await Logout() },
                new CarViewFlyoutMenuItem { Id = 5, Title = "Navegar", TargetAction = NavegateSample },
            });

            this.User = _userRepository.Get();
        }

        public ObservableCollection<CarViewFlyoutMenuItem> MenuItems { get; set; }
        public Command<CarViewFlyoutMenuItem> ItemCommand { get; set; }

        private User user;
        public User User
        {
            get => this.user;
            set
            {
                this.user = value;
                RaisePropertyChanged();
            }
        }

        private void ItemClickExecute(CarViewFlyoutMenuItem flyoutMenuItem)
        {
            flyoutMenuItem.TargetAction.Invoke();
        }

        private async Task Logout()
        {
            var dialogResult = await this._pageDialogService.DisplayAlertAsync(
                Resource.dialog_logoutapp,
                Resource.dialog_logoutconfirmation,
                Resource.dialog_yes,
                Resource.dialog_no);

            if (dialogResult)
            {
                this._userRepository.Delete();
                await this.NavigationService.NavigateAsync($"app:///{nameof(NavigationPage)}/{nameof(LoginView)}");
            }
        }

        private void NavegateSample()
        {
            var nav = Application.Current.MainPage as NavigationPage;
            var flyout = nav.CurrentPage as FlyoutPage;
            flyout.Detail = new NavigationPage(new LoginView());;
            flyout.IsPresented = false;
        }
    }
}
