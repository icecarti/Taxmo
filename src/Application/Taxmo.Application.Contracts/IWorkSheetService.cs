using Taxmo.Application.Models;

namespace Taxmo.Application.Contracts;
public interface IWorkSheetService
{
    void AddWorkSheet(TimeWorksheet newWorkSheet);

    void RemoveWorkSheet(TimeWorksheet timeWorksheet);

    void GetWorkInfo(TimeWorksheet timeWorksheet);

    void AddWorkInfo(TimeWorksheet timeWorksheet);
}