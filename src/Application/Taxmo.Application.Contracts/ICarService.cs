using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ICarService
{
    CarModel AddCar(DateOnly productionDate, string brand, string model, string carNumber, CarParkModel park, DriverModel owner);

    void DeleteCar(CarModel car);

    void GetCarInfo(CarModel car);

    void UpdateCarInfo(CarModel car, string newInfo);
}
