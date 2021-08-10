using carros_xamarin_clean.Core.Domain.Interface;
using carros_xamarin_clean.Core.Repository;
using carros_xamarin_clean.Features.Car.Data.Repositories;

namespace carros_xamarin_clean.Features.Car.Domain.Repositories
{
    public class CarRepository : Repository<Entities.Car>, ICarRepository
    {
        public CarRepository(IDataBaseAccessPlataform dataBaseAccessPlataform) : base(dataBaseAccessPlataform)
        {

        }
    }
}
