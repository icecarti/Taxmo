using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
internal interface IParkService
{
    CarParkModel AddCarPark(string address, string postCode, int carCount, TaxiCompanyModel company);

    void RemoveCarPark(CarParkModel carPark);

    void GetCarsInfo(CarParkModel carPark, params CarModel[] cars);

    void GetCarParkInfo(CarParkModel carPark);

    void UpdateCarParkInfo(CarParkModel carPark, string newInfo);
}
