using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IDriverService
{
    Driver AddDriver(string name, string driverLicense, string passport, string phone, string email);

    void RemoveDriver(Driver newDriver);

    void ChangeDriverInfo(Driver driver, string newInfo);

    void GetDriverInfo(Driver driver);
}