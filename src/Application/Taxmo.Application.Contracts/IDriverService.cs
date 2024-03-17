using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IDriverService
{
    DriverModel AddDriver(string name, string driverLicense, string passport, string phone, string email);

    void RemoveDriver(DriverModel newDriver);

    void ChangeDriverInfo(DriverModel driver, string newInfo);

    void GetDriverInfo(DriverModel driver);
}