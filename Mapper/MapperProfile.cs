using AutoMapper;
using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Department, AddDepartmentRequest>().ReverseMap();
            CreateMap<ResponseDepartment, Department>().ReverseMap();
            CreateMap<Department, ResponseDepartmentAll>().ReverseMap();

            CreateMap<Project, AddProjectRequest>().ReverseMap();
            CreateMap<Project, EditProjectRequest>().ReverseMap();  
            CreateMap<ResponseProject, Project>().ReverseMap();
            CreateMap<ResponseProjectAll, Project>().ReverseMap();

            CreateMap<Employee, AddEmployeeRequest>().ReverseMap();
            CreateMap<Employee, EditEmployeeRequest>().ReverseMap();
            CreateMap<ResponseEmployee, Employee>().ReverseMap();
        }
    }
}
