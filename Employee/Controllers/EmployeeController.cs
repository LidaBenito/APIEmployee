using Employee.DALEmpolyee;
using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllEmployee()
        {
            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeService.GetEmployees(id);
            if (employee != null)
                return Ok(employee);
            else
                return NotFound("the employee not found ");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employees employees)
        {
            _employeeService.AddEmployee(employees);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path+"/"+employees.Id,employees); 
     
        }

        [HttpDelete]

        [Route("api/[controller]/{id}")]

        public  IActionResult DeleteEmployee(Guid id)
        {
            var employ = _employeeService.GetEmployees(id);
            if (employ != null)
            {
                _employeeService.DeleteEmployee(employ);
                return Ok();
            }
            return NotFound();


        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult UpdateEmployee(Guid id, Employees employees)
        {
            var Existingemploy = _employeeService.GetEmployees(id);
            if (Existingemploy != null)
            {
                employees.Id = Existingemploy.Id;
                _employeeService.UpdateEmployee(employees);
               
            }
            return Ok(employees);


        }
    }
}
