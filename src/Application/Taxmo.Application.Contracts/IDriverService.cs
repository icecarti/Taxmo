using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IDriverService
{
    Driver AddDriver(Driver driver);

    void RemoveDriver(Driver newDriver);

    void ChangeDriverInfo(Driver driver);

    void GetDriverInfo(Driver driver);
}
