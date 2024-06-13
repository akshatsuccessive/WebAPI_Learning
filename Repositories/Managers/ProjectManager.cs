using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI_All.Data;
using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories.Managers.Interfaces;

namespace WebAPI_All.Repositories.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectManager(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponseProjectAll>> GetAllProjects()
        {
            var projects = await _context.Projects.Include(x => x.Employees).ToListAsync();
            var responseProjects = _mapper.Map<IEnumerable<ResponseProjectAll>>(projects);
            return responseProjects;
        }

        public async Task<Project> AddProjectAsync(AddProjectRequest request)
        {
            var project = _mapper.Map<Project>(request);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<ResponseProjectAll> GetProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            var responseProject = _mapper.Map<ResponseProjectAll>(project);
            return responseProject!;
        }

        public async Task<Project> DeleteProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project == null)
            {
                return null!;
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<ResponseProject> EditProject(int id, EditProjectRequest request)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project == null)
            {
                return null!;
            }
            var mappingResult = _mapper.Map(request, project);

            _context.Projects.Update(mappingResult);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ResponseProject>(project);
            return result;
        }
    }
}
