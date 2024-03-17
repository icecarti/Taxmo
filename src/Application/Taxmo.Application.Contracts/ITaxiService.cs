using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ITaxiService
{
    TaxiCompanyModel AddTaxiCompany(string name, string description, string phone, string owner, DateOnly registrationDate);

    void DeleteTaxiCompany(TaxiCompanyModel taxiCompany);

    void GetTaxiCompanyInfo(TaxiCompanyModel taxiCompany);

    void UpdateTaxiCompanyInfo(TaxiCompanyModel taxiCompany, string newInfo);
}
