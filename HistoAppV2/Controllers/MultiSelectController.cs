//using HistoAppV2.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace HistoAppV2.Controllers
//{
//    public class MultiSelectController : Controller
//    {
//        private ApplicationDbContext Context { get; }
//        public MultiSelectController(ApplicationDbContext _context)
//        {
//            this.Context = _context;
//        }
//        public IActionResult MultiSelectList()
//        {
//            SelectList multiSelects = new SelectList(this.Context.MultiList.ToList(), "TestId", "Test");
//            return View(multiSelects);
//        }

//        [HttpPost]
//        public IActionResult MultiSelectList(string[] TestIds)
//        {
//            SelectList multiSelects = new SelectList(this.Context.MultiList.ToList(), "TestId", "Test");
//            return View(multiSelects);
//        }

//    }
//}
