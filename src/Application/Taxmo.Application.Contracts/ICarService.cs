using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ICarService
{
    void AddCar(Car newCar);

    void DeleteCar(Car car);

    void GetCarInfo(Car car);

    void UpdateCarInfo(Car car);
}
