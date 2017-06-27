using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ContosoUniversity.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SchoolContext _context;

        public BaseController(SchoolContext context)
        {
            _context = context;
            _context.GetInfrastructure();

        }
    }
}
