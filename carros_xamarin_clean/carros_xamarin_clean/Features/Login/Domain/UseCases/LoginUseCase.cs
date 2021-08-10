using carros_xamarin_clean.Core.Resources;
using carros_xamarin_clean.Features.Login.Data.DataSources;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using carros_xamarin_clean.Features.Login.Domain.UseCases.Interface;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Refit;
using System;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Login.Domain.UseCases
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ILoginClient _loginClient;
        private readonly IUserRepository _userRepository;

        public LoginUseCase(ILoginClient loginClient, IUserRepository userRepository)
        {
            _loginClient = loginClient;
            _userRepository = userRepository;
        }

        public async Task<string> LoginAsync(Entities.Login login)
        {
            try
            {
                var user = await _loginClient.LoginAsync(login);
                _userRepository.Save(user);
                return string.Empty;
            }
            catch (ApiException ex)
            {
                if (ex.HasContent)
                {
                    Analytics.TrackEvent(ex.Content);
                    return ex.Content;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

            return Resource.login_fail;
        }
    }
}
