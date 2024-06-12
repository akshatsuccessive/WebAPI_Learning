using Microsoft.AspNetCore.Mvc;
using WebAPI_All.Models.DTO;
using WebAPI_All.Repositories;

namespace WebAPI_All.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _unitOfWork.DepartmentManager.GetAllDepartments();
            return Ok(departments);
        }

        [HttpPost]
        [Route("Add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }
            var newDepartment = await _unitOfWork.DepartmentManager.AddDepartmentAsync(request);
            return Ok(newDepartment);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            var department = await _unitOfWork.DepartmentManager.GetDepartment(id);
            if(department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var department = await _unitOfWork.DepartmentManager.DeleteDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditDepartment([FromRoute] int id, [FromBody] EditDepartmentRequest request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var department = await _unitOfWork.DepartmentManager.EditDepartment(id, request);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
    }
}
