using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models.SchoolViewModels;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Microsoft.Extensions.Logging;

namespace ContosoUniversity.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(SchoolContext context) : base(context)
        {
            //var serviceProvider = context.GetInfrastructure<IServiceProvider>();
            //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            /*            using (var db = new SchoolContext())
                        {
                            var serviceProvider = db.GetInfrastructure<IServiceProvider>();
                            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                            loggerFactory.AddProvider(new MyLoggerProvider());
                        }*/
        }

        public IActionResult Index()
        {
            return View();
        }

#if USE_DIRECT_WAY
        public async Task<ActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data = _context.Students
                .GroupBy(student => student.EnrollmentDate)
                .Select(dateGroup => new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                });
            return View(await data.AsNoTracking().ToListAsync());
        } 
#else
        public async Task<ActionResult> About()
        {
            List<EnrollmentDateGroup> groups = new List<EnrollmentDateGroup>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                                   + "FROM Person "
                                   + "WHERE Discriminator = 'Student' "
                                   + "GROUP BY EnrollmentDate";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new EnrollmentDateGroup { EnrollmentDate = reader.GetDateTime(0), StudentCount = reader.GetInt32(1) };
                            groups.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally
            {
                conn.Close();
            }
            return View(groups);
        }
#endif

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
