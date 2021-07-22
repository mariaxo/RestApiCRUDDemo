using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public interface IEmployeeData
    {
        //5 functions needed

        /// <summary>
        /// gets all of the employees
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployees();


        /// <summary>
        /// gets one employee matching the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployee(Guid id);


        /// <summary>
        /// returns the created employee
        /// </summary>
        /// <returns></returns>
        Employee AddEmployee(Employee employee);


        void DeleteEmployee(Employee employee);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>the edited employee</returns>
        Employee EditEmployee(Employee employee);

    }
}
