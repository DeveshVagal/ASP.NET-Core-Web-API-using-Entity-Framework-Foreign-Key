using ForeignKeyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKeyWebAPI.EmployeeData
{
        public interface IDepartmentData
        {
            List<Department> GetDepartments();

            Department GetDepartment(Guid id);

            Department AddDepartment(Department department);

            void DeleteDepartment(Department department);

            Department EditDepartment(Department department);
        }
}
