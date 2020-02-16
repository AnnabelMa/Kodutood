using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sport.Models;
using Microsoft.EntityFrameworkCore;
using Sport.Data;
using Sport.Models.SpordiViewModels;
using System.Data.Common;

namespace Sport.Controllers
{
    public class HomeController : Controller
    {
        private readonly SpordiContext _context;
        public HomeController(SpordiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Üldine()
        {
            IQueryable<RegistreeringuKPGroup> data =
                 from sportlane in _context.Sportlased
                 group sportlane by sportlane.RegistreeringuKP into dateGroup
                 select new RegistreeringuKPGroup()
       {
           RegistreeringuKP = dateGroup.Key,
           SportlaneCount = dateGroup.Count()
       };
            return View(await data.AsNoTracking().ToListAsync());

            /* List<RegistreeringuKPGroup> groups = new List<RegistreeringuKPGroup>();
             var conn = _context.Database.GetDbConnection();
             try
             {
                 await conn.OpenAsync();
                 using (var command = conn.CreateCommand())
                 {
                     string query = "SELECT Registreeringu kuupäev, COUNT(*) AS SportlaneCount "
                         + "FROM Person "
                         + "WHERE Discriminator = 'Sportlane' "
                         + "GROUP BY Registreeringu kuupäev";
                     command.CommandText = query;
                     DbDataReader reader = await command.ExecuteReaderAsync();

                     if (reader.HasRows)
                     {
                         while (await reader.ReadAsync())
                         {
                             var row = new RegistreeringuKPGroup { RegistreeringuKP = reader.GetDateTime(0), SportlaneCount = reader.GetInt32(1) };
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
             */
        }
        private readonly ILogger<HomeController> _logger;


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
