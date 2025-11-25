using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<EmployeeDto> _employees = new()
        {
            new EmployeeDto(1, "Alice", "Johnson", "alice.johnson@example.com", "Software Engineer"),
            new EmployeeDto(2, "Bob", "Martinez", "bob.martinez@example.com", "Product Manager"),
            new EmployeeDto(3, "Cara", "Singh", "cara.singh@example.com", "QA Engineer")
        };

        // GET: api/employees
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            return Ok(_employees);
        }

        private record EmployeeDto(int Id, string FirstName, string LastName, string Email, string Position);
    }
}
