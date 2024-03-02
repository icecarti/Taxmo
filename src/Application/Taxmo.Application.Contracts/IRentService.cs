using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IRentService
{
    CarPark StartRent(Car car, Driver driver, DateTime startDate, DateTime endDate, int dailyPrice);

    void CloseRent(CarRent rent);

    void ContinueRent(CarRent rent, DateTime newEndDate);

    void UpdateRentInfo(CarRent rent, string newInfo);

    void GetRentInfo(CarRent rent);
}