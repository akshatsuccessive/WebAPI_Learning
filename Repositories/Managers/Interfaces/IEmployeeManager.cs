using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Repositories.Managers.Interfaces
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> AddEmployeeAsync(AddEmployeeRequest request);
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> DeleteEmployee(Guid id);
        Task<ResponseEmployee> EditEmployee(Guid id, EditEmployeeRequest request);
    }
}
