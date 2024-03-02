using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IWorkSheetService
{
    TimeWorksheet AddWorkSheet(TaxiCompany taxi, Driver driver, DateOnly workDate, int hourlySalary, int hours);

    void RemoveWorkSheet(TimeWorksheet timeWorksheet);

    void GetWorkInfo(TimeWorksheet timeWorksheet);

    void AddWorkInfo(TimeWorksheet timeWorksheet, string newWorkInfo);
}