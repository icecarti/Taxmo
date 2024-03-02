using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IPassengerService
{
    void AddPassenger(Passenger newPassenger);

    void ChangePassengerInfo(Passenger passenger);

    void GetPassengerInfo(Passenger passenger);
}
