using HistoAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using HistoAppV2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HistoAppV2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
            
        private readonly ApplicationDbContext _context;

            public HomeController(ApplicationDbContext context)
            {
                _context = context;
            }



        //Search bar with Surname and Case filters
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var orders = from s in _context.Orders
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.Surname.Contains(searchString)
                                    || s.Case.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(s => s.Surname);
                    break;
                case "Date":
                    orders = orders.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    orders = orders.OrderBy(s => s.Surname);
                    break;
            }
            return View(await orders.AsNoTracking().ToListAsync());
        }

        //private bool OrdersExists(int idOrder)
        //{
        //    return _context.IdOrder.Any(e => e.IdOrder == idOrder);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}