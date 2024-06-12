using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Repositories.Managers.Interfaces
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> AddDepartmentAsync(AddDepartmentRequest request);
        Task<Department> GetDepartment(int id);
        Task<Department> DeleteDepartment(int id);
        Task<ResponseDepartment> EditDepartment(int id, EditDepartmentRequest request);
    }
}
