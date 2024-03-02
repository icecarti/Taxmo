using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
internal interface IParkService
{
    CarPark AddCarPark(string address, string postCode, int carCount, TaxiCompany company);

    void RemoveCarPark(CarPark carPark);

    void GetCarsInfo(CarPark carPark, params Car[] cars);

    void GetCarParkInfo(CarPark carPark);

    void UpdateCarParkInfo(CarPark carPark, string newInfo);
}
