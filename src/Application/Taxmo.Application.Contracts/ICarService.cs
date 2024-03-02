using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ICarService
{
    Car AddCar(DateOnly productionDate, string brand, string model, string carNumber, CarPark park, Driver owner);

    void DeleteCar(Car car);

    void GetCarInfo(Car car);

    void UpdateCarInfo(Car car, string newInfo);
}
