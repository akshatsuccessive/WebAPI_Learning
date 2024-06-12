using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories;

namespace WebAPI_All.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _unitOfWork.ProjectManager.GetAllProjects();
            return Ok(projects);
        }

        [HttpPost]
        [Route("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProject([FromBody] AddProjectRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }
            var newProject = await _unitOfWork.ProjectManager.AddProjectAsync(request);
            return Ok(newProject);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var project = await _unitOfWork.ProjectManager.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var project = await _unitOfWork.ProjectManager.DeleteProject(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditProject([FromRoute] int id, [FromBody] EditProjectRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var department = await _unitOfWork.ProjectManager.EditProject(id, request);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
    }
}
