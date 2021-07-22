using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;

namespace RestApiCRUDDemo.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //5 API methods needed here
        

        private IEmployeeData _employeeData;

        //inject IEmployeeData to this controller
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        //get All employees
        //this is an HTTP GET method
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        { 
            //from our mock repository w are getting back the employees
            //we are getting it back as an HTTP OK result
            return Ok(_employeeData.GetEmployees());
        }

        //get a single employee
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            //from our mock repository w are getting back one employee
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else return NotFound($"Employee with Id: {id} was not found.");
        }

        //add an employee
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            //201Created : server created your request
            // on that path, we created that object
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }


        //delete an employee
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();

            }
            //404 not found
            return NotFound($"Employee with Id: {id} was not found.");
        }



        //PUT replaces the whole source
        //PATCH only updates the changes
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        //1. edit the employee with Guid id
        //2. update the info like the employee parameter
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            //let's see if that employee exists first
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                //employee is what we want to change our existingEmployee to
                //employee comes without an id
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee); // takes employee as an example to change our existing one in the db
                
            }

            //if there is not such employee with that id, still we just won't update anything
            return Ok(employee);
        }



    }
}
