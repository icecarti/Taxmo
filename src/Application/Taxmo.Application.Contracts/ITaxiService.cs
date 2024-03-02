using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface ITaxiService
{
    void AddTaxiCompany(TaxiCompany newTaxiCompany);

    void DeleteTaxiCompany(TaxiCompany taxiCompany);

    void GetTaxiCompanyInfo(TaxiCompany taxiCompany);

    void UpdateTaxiCompanyInfo(TaxiCompany taxiCompany);
}
