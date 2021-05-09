using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.DALEmpolyee
{
    public class EmployeesRepository : IEmployeeService
    {
        private readonly EmployeeDbContext _context;

        public EmployeesRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public Employees AddEmployee(Employees employees)
        {
            employees.Id = Guid.NewGuid();
            _context.Employees.Add(employees);
            _context.SaveChanges();
            return employees;
        }

        public void DeleteEmployee(Employees employees)
        {
            _context.Employees.Remove(employees);
            _context.SaveChanges();
        }

        public List<Employees> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employees GetEmployees(Guid id)
        {
            return _context.Employees.Find(id); 
        }
       
        
        public Employees UpdateEmployee(Employees employees)
        {
            var existingemployee = _context.Employees.Find(employees.Id);
            if (existingemployee != null)
            {
                existingemployee.Name = employees.Name;
                _context.Employees.Update(existingemployee);
                _context.SaveChanges();
            }
            return employees;
        }
    }
}
