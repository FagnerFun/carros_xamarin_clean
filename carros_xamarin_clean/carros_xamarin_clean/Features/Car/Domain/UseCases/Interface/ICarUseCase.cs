using System.Collections.Generic;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Car.Domain.UseCases.Interface
{
    public interface ICarUseCase
    {
        Task<List<Entities.Car>> GetCarsAsync();
        Task<List<Entities.Car>> Download();
    }
}
