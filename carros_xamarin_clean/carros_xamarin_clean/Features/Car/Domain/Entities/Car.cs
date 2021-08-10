using carros_xamarin_clean.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace carros_xamarin_clean.Features.Car.Domain.Entities
{
    public class Car : DBEntity
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        [JsonProperty("urlFoto")]
        public string UrlFoto { get; set; }

        [JsonProperty("urlVideo")]
        public string UrlVideo { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
