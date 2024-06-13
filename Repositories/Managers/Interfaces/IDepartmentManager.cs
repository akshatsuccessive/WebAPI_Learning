using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Repositories.Managers.Interfaces
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<ResponseDepartmentAll>> GetAllDepartments();
        Task<Department> AddDepartmentAsync(AddDepartmentRequest request);
        Task<ResponseDepartmentAll> GetDepartment(int id);
        Task<Department> DeleteDepartment(int id);
        Task<ResponseDepartment> EditDepartment(int id, EditDepartmentRequest request);
    }
}
