using carros_xamarin_clean.Features.Login.Domain.Entities;
using Refit;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Login.Data.DataSources
{
    [Headers("Content-Type: application/json")]
    public interface ILoginClient
    {
        [Post("/api/v2/login")]
        Task<User> LoginAsync([Body] Domain.Entities.Login login);
    }
}
