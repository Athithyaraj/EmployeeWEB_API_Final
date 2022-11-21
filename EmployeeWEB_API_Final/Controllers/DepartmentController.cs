using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using EmployeeWEB_API_Final.Models;

namespace EmployeeWEB_API_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        public EmpContext _context;
        public DepartmentController(EmpContext EmployeeContext)
        {
            _context = EmployeeContext;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetDepartment()
        {
            //   return _context.Employees;
            return Ok(await _context.Departments.ToListAsync());
        }

    }
}
