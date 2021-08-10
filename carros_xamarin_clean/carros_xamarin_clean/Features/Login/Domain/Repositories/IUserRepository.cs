using carros_xamarin_clean.Features.Login.Domain.Entities;

namespace carros_xamarin_clean.Features.Login.Domain.Repositories
{
    public interface IUserRepository
    {
        void Save(User user);
        User Get();
        void Delete();
    }
}
