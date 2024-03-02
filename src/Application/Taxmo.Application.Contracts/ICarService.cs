using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ICarService
{
    Car AddCar();

    void DeleteCar(Car car);

    void GetCarInfo(Car car);

    void UpdateCarInfo(Car car);
}
