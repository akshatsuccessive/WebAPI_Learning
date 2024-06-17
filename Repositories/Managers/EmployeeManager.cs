using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebAPI_All.Data;
using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories.Managers.Interfaces;

namespace WebAPI_All.Repositories.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeManager(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.
                Include(x => x.Departments).Include(x => x.Projects).
                ToListAsync();
            return employees;
        }

        public async Task<Employee> AddEmployeeAsync(AddEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            var projects = await _context.Projects
                            .Where(p => request.ProjectId == p.ProjectId)
                            .ToListAsync();
            employee.Projects = projects;

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.
                Include(e => e.Departments).
                FirstOrDefaultAsync(x => x.EmployeeId == id);
            return employee!;
        }

        public async Task<Employee> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                return null!;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<ResponseEmployee> EditEmployee(Guid id, EditEmployeeRequest request)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (employee == null)
            {
                return null!;
            }
            var projects = await _context.Projects
                            .Where(p => request.ProjectId == p.ProjectId)
                            .ToListAsync();
            employee.Projects = projects;

            var mappingResult = _mapper.Map(request, employee);
            _context.Employees.Update(mappingResult);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ResponseEmployee>(employee);
            result.ProjectId = request.ProjectId;
            return result;
        }

        public async Task<PagedResponse<Employee>> GetEmployeeList(AddEmployeeListRequest request)
        {
            var query = await _context.Employees.Include(x => x.Departments).Include(x => x.Projects).ToListAsync();
            if(request.SortOrder.ToLower() == "desc")
            {
                query = query.OrderByDescending(e => e.Name).ToList();
            }
            else
            {
                query = query.OrderBy(e => e.Name).ToList();
            }


            var totalCount = query.Count();

            var employees = query
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize);
            var isNextPage = request.PageNumber < totalPages - 1;
            var isPreviousPage = request.PageNumber > 0;

            return new PagedResponse<Employee>
            {
                TotalCount = totalCount,
                Items = employees,
                IsNextPage = isNextPage,
                IsPreviousPage = isPreviousPage
            };
        }
    }
}
