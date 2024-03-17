using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IPassengerService
{
    PassengerModel AddPassenger(string name, string phone, string email);

    void ChangePassengerInfo(PassengerModel passenger, string newInfo);

    void GetPassengerInfo(PassengerModel passenger);
}
