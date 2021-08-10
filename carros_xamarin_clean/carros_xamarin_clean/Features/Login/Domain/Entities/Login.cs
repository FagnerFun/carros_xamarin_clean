using Newtonsoft.Json;

namespace carros_xamarin_clean.Features.Login.Domain.Entities
{
    public class Login
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
