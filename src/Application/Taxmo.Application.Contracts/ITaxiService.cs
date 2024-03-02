using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ITaxiService
{
    TaxiCompany AddTaxiCompany(string name, string description, string phone, string owner, DateOnly registrationDate);

    void DeleteTaxiCompany(TaxiCompany taxiCompany);

    void GetTaxiCompanyInfo(TaxiCompany taxiCompany);

    void UpdateTaxiCompanyInfo(TaxiCompany taxiCompany, string newInfo);
}
