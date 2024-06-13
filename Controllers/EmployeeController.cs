using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories;

namespace WebAPI_All.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _unitOfWork.EmployeeManager.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        [Route("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProject([FromBody] AddEmployeeRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }
            var newProject = await _unitOfWork.EmployeeManager.AddEmployeeAsync(request);
            return Ok(newProject);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var project = await _unitOfWork.EmployeeManager.GetEmployee(id);
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
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            var project = await _unitOfWork.EmployeeManager.DeleteEmployee(id);
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
        public async Task<IActionResult> EditEmployee([FromRoute] Guid id, [FromBody] EditEmployeeRequest request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            try
            {
                var project = await _unitOfWork.EmployeeManager.EditEmployee(id, request);
                if (project == null)
                {
                    return NotFound();
                }
                return Ok(project);
            }
            catch(Exception ex)
            {
                return BadRequest(String.Format("{0} This project is already associated with the Project", ex.Message));
            }
        }
    }
}
