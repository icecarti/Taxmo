using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IPassengerService
{
    Passenger AddPassenger(string name, string phone, string email);

    void ChangePassengerInfo(Passenger passenger, string newInfo);

    void GetPassengerInfo(Passenger passenger);
}
