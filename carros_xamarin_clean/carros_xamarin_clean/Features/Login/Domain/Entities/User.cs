using Newtonsoft.Json;

namespace carros_xamarin_clean.Features.Login.Domain.Entities
{
    public class User
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("urlFoto")]
        public string UrlFoto { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
