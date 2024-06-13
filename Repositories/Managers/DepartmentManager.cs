using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAPI_All.Data;
using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories.Managers.Interfaces;

namespace WebAPI_All.Repositories.Managers
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentManager(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseDepartmentAll>> GetAllDepartments()
        {
            var departments = await _context.Departments.Include(x => x.Employees).ToListAsync();
            var responseDepartments = _mapper.Map<IEnumerable<ResponseDepartmentAll>>(departments);
            return responseDepartments;
        }

        public async Task<Department> AddDepartmentAsync(AddDepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request);
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<ResponseDepartmentAll> GetDepartment(int id)
        {
            var department = await _context.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.DepartmentId == id);
            var responseDepartment = _mapper.Map<ResponseDepartmentAll>(department);
            return responseDepartment!;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if(department == null)
            {
                return null!;
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<ResponseDepartment> EditDepartment(int id, EditDepartmentRequest request)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.DepartmentId == id);
            if (department == null)
            {
                return null!;
            }
            department.DepartmentName = request.DepartmentName;
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ResponseDepartment>(department);
            return result;
        }
    }
}
