using ForeignKeyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKeyWebAPI.EmployeeData
{
    public class SqlDepartmentData : IDepartmentData
    {
        private DBContext _dBContext;

        public SqlDepartmentData(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Department AddDepartment(Department department)
        {
            department.DepartmentId = Guid.NewGuid();
            _dBContext.Departments.Add(department);
            _dBContext.SaveChanges();
            return department;
        }

        public void DeleteDepartment(Department department)
        {
            _dBContext.Departments.Remove(department);
            _dBContext.SaveChanges();
        }

        public Department EditDepartment(Department department)
        {
            var existingDepartment = _dBContext.Employees.Find(department.DepartmentId);

            if (existingDepartment != null)
            {
                existingDepartment.EmployeeName = department.DepartmentName;
                existingDepartment.DepartmentId = department.DepartmentId;
                _dBContext.Employees.Update(existingDepartment);
                _dBContext.SaveChanges();
            }

            return department;
        }

        public Department GetDepartment(Guid id)
        {
            var department = _dBContext.Departments.Find(id);
            return department;
        }

        public List<Department> GetDepartments()
        {
            return _dBContext.Departments.ToList();
        }
    }
}
