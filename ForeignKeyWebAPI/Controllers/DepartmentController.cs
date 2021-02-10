using ForeignKeyWebAPI.EmployeeData;
using ForeignKeyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKeyWebAPI.Controllers
{
    [ApiController]
    public class DepartmentController : Controller
    {
        private IDepartmentData _departmentData;

        public DepartmentController(IDepartmentData departmentData)
        {
            _departmentData = departmentData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetDepartments()
        {
            return Ok(_departmentData.GetDepartments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var department = _departmentData.GetDepartment(id);

            if (department != null)
            {
                return Ok(department);
            }

            return NotFound($"Department with Id : {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetDepartment(Department department)
        {
            _departmentData.AddDepartment(department);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + department.DepartmentId, department);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var department = _departmentData.GetDepartment(id);

            if (department != null)
            {
                _departmentData.DeleteDepartment(department);
                return Ok();
            }

            return NotFound($"Department with Id : {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditDepartment(Guid id, Department department)
        {
            var existingdepartment = _departmentData.GetDepartment(id);

            if (existingdepartment != null)
            {
                department.DepartmentId = existingdepartment.DepartmentId;
                _departmentData.EditDepartment(department);
            }

            return Ok(department);
        }
    }
}
