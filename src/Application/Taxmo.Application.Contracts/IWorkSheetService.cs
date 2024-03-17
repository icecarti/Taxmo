using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IWorkSheetService
{
    TimeWorkSheetModel AddWorkSheet(TaxiCompanyModel taxi, DriverModel driver, DateOnly workDate, int hourlySalary, int hours);

    void RemoveWorkSheet(TimeWorkSheetModel timeWorksheet);

    void GetWorkInfo(TimeWorkSheetModel timeWorksheet);

    void AddWorkInfo(TimeWorkSheetModel timeWorksheet, string newWorkInfo);
}