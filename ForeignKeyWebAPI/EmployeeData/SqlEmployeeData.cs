using ForeignKeyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKeyWebAPI.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private DBContext _DbContext;

        public SqlEmployeeData(DBContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            _DbContext.Employees.Add(employee);
            _DbContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _DbContext.Employees.Remove(employee);
            _DbContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _DbContext.Employees.Find(employee.EmployeeId);

            if (existingEmployee != null)
            {
                existingEmployee.EmployeeName = employee.EmployeeName;
                existingEmployee.DepartmentId = employee.DepartmentId;
                _DbContext.Employees.Update(existingEmployee);
                _DbContext.SaveChanges();
            }

            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _DbContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _DbContext.Employees
                .Include(a => a.Departments).ToList();
        }
    }
}
