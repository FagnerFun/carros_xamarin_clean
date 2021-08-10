using Newtonsoft.Json;

namespace carros_xamarin_clean.Core.Entity
{
    public class DBEntity
    {
        [JsonProperty("id")]
        public int _id { get; set; }
    }
}
