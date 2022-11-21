using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using EmployeeWEB_API_Final.Models;
namespace EmployeeWEB_API_Final.Controllers
{

    public class WorksInController : Controller
    {
        public EmpContext _context;
        public WorksInController(EmpContext EmployeeContext)
        {
            _context = EmployeeContext;
        }
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetWorksIn()
        {
            //   return _context.Employees;
            return Ok(await _context.WorksIns.ToListAsync());
        }

    }
}
