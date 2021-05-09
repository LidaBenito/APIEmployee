using Employee.Models;
using System;
using System.Collections.Generic;

namespace Employee.DALEmpolyee
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees();
        Employees GetEmployees(Guid id);
        Employees AddEmployee(Employees employees);
        void DeleteEmployee(Employees employees);
        Employees UpdateEmployee(Employees employees);
    }
}
