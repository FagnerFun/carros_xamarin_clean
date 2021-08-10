using carros_xamarin_clean.Features.Car.Data.DataSources;
using carros_xamarin_clean.Features.Car.Data.Repositories;
using carros_xamarin_clean.Features.Car.Domain.UseCases.Interface;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carros_xamarin_clean.Features.Car.Domain.UseCases
{
    public class CarUseCase : ICarUseCase
    {
        private readonly ICarClient _carClient;
        private readonly ICarRepository _carRepository;

        public CarUseCase(ICarClient carClient, ICarRepository carRepository)
        {
            _carClient = carClient;
            _carRepository = carRepository;
        }

        public async Task<List<Entities.Car>> Download()
        {
            var cars = new List<Entities.Car>();

            try
            {
                cars = await _carClient.GetAsync();
                if(cars != null)
                {
                    _carRepository.AddOrUpdate(cars);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

            return cars;
        }

        public async Task<List<Entities.Car>> GetCarsAsync()
        {
            var cars = new List<Entities.Car>();

            try
            {

                cars = _carRepository.GetAll();
                if (cars != null && cars.Any())
                {
                    return cars;
                }

                return await Download();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

            return cars;
        }

    }
}
