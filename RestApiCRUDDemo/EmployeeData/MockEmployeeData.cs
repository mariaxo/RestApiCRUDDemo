using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        //our lock list of employees
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee One"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two"
            },
        };

        //method 1 implementation
        public List<Employee> GetEmployees()
        {
            return employees;
        }
        public Employee GetEmployee(Guid id)
        {
            //LINQ Employee class method used
            return employees.SingleOrDefault(x => x.Id == id);
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        // the parameter employee is the updated employee that now we need to record in our data
        //employee also has its new updated information too
        public Employee EditEmployee(Employee employee)
        {
            Employee existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }



       
    }
}
