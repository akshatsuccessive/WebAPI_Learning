using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> AddEmployeeAsync(AddEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
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
            var mappingResult = _mapper.Map(request, employee);

            _context.Employees.Update(mappingResult);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ResponseEmployee>(employee);
            return result;
        }
    }
}
