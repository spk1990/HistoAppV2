using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HistoAppV2.Data;
using HistoAppV2.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;

namespace HistoAppV2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Dropdown list

        //public IActionResult MultiSelect()
        //{
        //var data = new List<Orders> {
        //new Orders { Id=1, Test="Cd20"},
        //new Orders { Id=2, Test="Cd45"},
        // new Orders { Id=3, Test="S100" }
        // };
        // Orders model = new();
        //model.TestList = data.Select(x => new SelectListItem { Text = x.Test, Value = x.Id.ToString() }).ToList();
        //return View(model);
        //}





        // GET: Orders
        public async Task<IActionResult> Index()
        {
            
            return _context.Orders != null ? 
                          View(await _context.Orders.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
        }

        
        //public IList<Orders> MyOrders(string id)
        //{
        //    return _context.Orders.Where(o => o.AspNetUsers.IdOrder = id).ToList();
        //}

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? idOrder)
        {
            if (idOrder == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.IdOrder == idOrder);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Surname,Case,Block,Test,Levels,RequestedBy,CreatedDate,Notes,Email")] Orders orders)
        //public IActionResult Create([Bind("Id,Surname,Case,Block,Test,Levels,RequestedBy,CreatedDate,Notes,Email")] Orders orders)
        {
            if (ModelState.IsValid)   
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Request complete";
                //return RedirectToAction("Index");
                //return View(orders);
                
            }
            
            //sending email using Gmail SMTP

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect("smtp.gmail.com");
                client.Authenticate("skeenandbs@gmail.com", "bajbrwctuielbbga");

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<p>{"Surname: "}{orders.Surname}</p><p>{"Case: "}{orders.Case}</p><p>{"Block: "}{orders.Block}</p><p>{"Test: "}{orders.Test}</p><p>{"Levels: "}{orders.Levels}</p><p>{"Notes: "}{orders.Notes}</p><p>{"Requested By: "}{orders.RequestedBy}</p>",
                };
                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("HistoAppV2 Order", "skeenandbs@gmail.com"));
                message.To.Add(new MailboxAddress("Test01", orders.Email));
                message.Subject = "New Request";
                client.Send(message);

                client.Disconnect(true);
            }
           
            return View(orders);
        }

        //MultiSelect List
        //public IActionResult MultiSelect()
        //{
            //var data = new List<Orders> {
            //new Orders { Id=1, Test="S100"},
           // new Orders { Id=2, Test="CD20"}
            //};
            //Orders model = new();
            //model.TestList = data.Select(x => new SelectListItem { Text = x.Test, Value = x.Id.ToString() }).ToList();
            //return View(model);
        //}

        //[HttpPost]
        //public IActionResult PostSelectedValues(PostMultiSelectList model)
        //{
            //return View();
        //}


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int idOrder, [Bind("IdOrder,Surname,Case,Block,Test,Levels,RequestedBy,CreatedDate,Notes,Email")] Orders orders)
        {
            if (idOrder != orders.IdOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.IdOrder))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? idOrder)
        {
            if (idOrder == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.IdOrder == idOrder);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int idOrder)
        {
          return (_context.Orders?.Any(e => e.IdOrder == idOrder)).GetValueOrDefault();
        }
    }
}
