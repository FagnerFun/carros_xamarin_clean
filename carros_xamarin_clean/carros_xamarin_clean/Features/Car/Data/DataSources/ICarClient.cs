using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Car.Data.DataSources
{
    public interface ICarClient
    {
        [Get("/api/v2/carros")]
        [Headers("Authorization: Bearer")]
        Task<List<Domain.Entities.Car>> GetAsync();
    }
}
