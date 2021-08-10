using Microsoft.AppCenter.Crashes;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Core.Presentation
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public INavigationService NavigationService { get; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }


        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
        protected async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await theBusyAction();

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
