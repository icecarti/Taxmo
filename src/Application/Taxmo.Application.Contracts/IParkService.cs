using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
internal interface IParkService
{
    void AddCarPark(CarPark newCarPark);

    void RemoveCarPark(CarPark carPark);

    void GetCarsInfo(CarPark carPark);

    void GetCarParkInfo(CarPark carPark);
}
