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
    public class EmployeeController : Controller
    {
        public EmpContext _context;
        public EmployeeController(EmpContext EmployeeContext)
        {
            _context = EmployeeContext;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetEmployees()
        {
            //   return _context.Employees;
            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
