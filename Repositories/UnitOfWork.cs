using AutoMapper;
using WebAPI_All.Data;
using WebAPI_All.Repositories.Managers;
using WebAPI_All.Repositories.Managers.Interfaces;

namespace WebAPI_All.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDepartmentManager departmentManager;
        private IProjectManager projectManager;
        private IEmployeeManager employeeManager;
        private readonly IMapper _mapper;
        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IDepartmentManager DepartmentManager => departmentManager ??= new DepartmentManager(_context, _mapper);
        public IProjectManager ProjectManager => projectManager ??= new ProjectManager(_context, _mapper);
        public IEmployeeManager EmployeeManager => employeeManager ??= new EmployeeManager(_context, _mapper);
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
