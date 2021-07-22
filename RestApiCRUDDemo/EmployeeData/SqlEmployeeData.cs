using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;

        //getting the employee context 
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
           //checked ALREADY in the controller
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
            

        }

        //edited employee : employee
        //now we need to save these changes in the db, so will update
        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }

        //get one employee with that id
        public Employee GetEmployee(Guid id)
        {
            //return _employeeContext.Employees.SingleOrDefault(x => x.Id == id);
            //or with find
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        //get all the employees
        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
