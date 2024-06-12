using WebAPI_All.Repositories.Managers.Interfaces;

namespace WebAPI_All.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentManager DepartmentManager { get; }
        IProjectManager ProjectManager { get; }
        IEmployeeManager EmployeeManager { get; }
        Task SaveChanges();
    }
}
