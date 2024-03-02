using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IRentService
{
    void StartRent(CarRent newRent);

    void CloseRent(CarRent rent);

    void ContinueRent(CarRent rent);

    void GetRentInfo(CarRent rent);
}