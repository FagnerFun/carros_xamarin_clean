using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Login.Domain.UseCases.Interface
{
    public interface ILoginUseCase
    {
        Task<string> LoginAsync(Entities.Login login);
    }
}
