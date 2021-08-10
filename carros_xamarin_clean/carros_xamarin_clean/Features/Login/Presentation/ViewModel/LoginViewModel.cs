using carros_xamarin_clean.Core.Presentation;
using carros_xamarin_clean.Core.Resources;
using carros_xamarin_clean.Core.Validation;
using carros_xamarin_clean.Core.Validation.Rule;
using carros_xamarin_clean.Features.Car.Presentation.Pages;
using carros_xamarin_clean.Features.Login.Domain.UseCases.Interface;
using Prism.Navigation;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace carros_xamarin_clean.Features.Login.Presentation.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginUseCase _loginUseCase;
        protected LoginViewModel(INavigationService navigationService, ILoginUseCase loginUseCase) : base(navigationService)
        {
            _loginUseCase = loginUseCase;

            LoginCommand = new Command(LoginExecute);

            username = new ValidatableObject<string>();
            password = new ValidatableObject<string>();
            loginRequest = new ValidatableObject<string>();

            AddValidations();
        }


        private ValidatableObject<string> username;
        public ValidatableObject<string> Username
        {
            get => username;
            set
            {
                username = value;
                RaisePropertyChanged();
            }
        }

        private ValidatableObject<string> password;
        public ValidatableObject<string> Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        private ValidatableObject<string> loginRequest;
        public ValidatableObject<string> LoginRequest
        {
            get { return loginRequest; }
            set
            {
                loginRequest = value;
                RaisePropertyChanged();
            }
        }


        public ICommand LoginCommand { get; set; }

        private async void LoginExecute()
        {
            var userIsValid = username.Validate();
            var passwordIsValid = password.Validate();

            if (userIsValid && passwordIsValid)
            {
                await ExecuteBusyAction(async () => await Login());
            }
        }

        private async Task Login()
        {
            LoginRequest.Value = await _loginUseCase.LoginAsync(new Domain.Entities.Login
            {
                Username = username.Value,
                Password = password.Value
            });

            if (LoginRequest.IsValid)
            {
                await NavigationService.NavigateAsync(nameof(CarView));
            }
        }

        private void AddValidations()
        {
            username.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = string.Format(Resource.required_field, Resource.user) });
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = string.Format(Resource.required_field, Resource.password) });
            loginRequest.Validations.Add(new IsEmptyRule<string> { ValidationMessage = Resource.login_fail });
        }
    }
}
