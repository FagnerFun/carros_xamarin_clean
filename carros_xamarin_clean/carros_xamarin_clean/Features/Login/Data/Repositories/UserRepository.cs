using carros_xamarin_clean.Features.Login.Domain.Entities;
using carros_xamarin_clean.Features.Login.Domain.Repositories;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace carros_xamarin_clean.Features.Login.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string UserKey = "User";

        public async void Delete()
        {
            Application.Current.Properties.Remove(UserKey);
            await Application.Current.SavePropertiesAsync();
        }

        public User Get()
        {
            if (!Application.Current.Properties.ContainsKey(UserKey))
                return null;

            return JsonConvert.DeserializeObject<User>(Application.Current.Properties[UserKey]?.ToString());
        }

        public async void Save(User user)
        {
            Application.Current.Properties[UserKey] = JsonConvert.SerializeObject(user);
            await Application.Current.SavePropertiesAsync();
        }
    }
}
