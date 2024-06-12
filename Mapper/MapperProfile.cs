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

            CreateMap<Project, AddProjectRequest>().ReverseMap();
            CreateMap<Project, EditProjectRequest>().ReverseMap();  
            CreateMap<ResponseProject, Project>().ReverseMap();
        }
    }
}
