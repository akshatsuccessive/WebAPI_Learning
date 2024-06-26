﻿using WebAPI_All.Models.DomainModels;
using WebAPI_All.Models.DTO;

namespace WebAPI_All.Repositories.Managers.Interfaces
{
    public interface IProjectManager
    {
        Task<IEnumerable<ResponseProjectAll>> GetAllProjects();
        Task<Project> AddProjectAsync(AddProjectRequest request);
        Task<ResponseProjectAll> GetProject(int id);
        Task<Project> DeleteProject(int id);
        Task<ResponseProject> EditProject(int id, EditProjectRequest request);
    }
}
