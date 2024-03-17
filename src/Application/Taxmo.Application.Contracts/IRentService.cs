using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IRentService
{
    CarParkModel StartRent(CarModel car, DriverModel driver, DateTime startDate, DateTime endDate, int dailyPrice);

    void CloseRent(CarRentModel rent);

    void ContinueRent(CarRentModel rent, DateTime newEndDate);

    void UpdateRentInfo(CarRentModel rent, string newInfo);

    void GetRentInfo(CarRentModel rent);
}