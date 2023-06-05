using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyShop.Api.Models;
using MyShop.Shared;
using MyShopAPI.Contexts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MyShop.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {
            return Ok(_employeeRepository.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id) {
            return Ok(_employeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee) {
            if (employee == null) {
                return BadRequest();
            }

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty) {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var createdEmployee = _employeeRepository.AddEmployee(employee);

            return Created("employee", createdEmployee);
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee) {
            if (employee == null) { 
                return BadRequest();
            }

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty) {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var employeeToUpdate = _employeeRepository.GetEmployeeById(employee.ID);

            if (employeeToUpdate == null) { 
                return NotFound();
            }

            _employeeRepository.UpdateEmployee(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id) {
            if (id == 0) { 
                return BadRequest();
            }

            var employeeToDelete = _employeeRepository.GetEmployeeById(id);
            if (employeeToDelete == null) { 
                return NotFound();
            }

            _employeeRepository.DeleteEmployee(id);

            return NoContent();
        }
    }
}