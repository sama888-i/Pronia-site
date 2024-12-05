using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;
using Pronia.ViewModels.Slider;

namespace Pronia.Controllers
{
    public class HomeController(ProniaDbContext _context) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var datas = await _context.Sliders
                .Where(x=>!x.IsDeleted)
                .Select(x => new SliderItemVM
                {
                 ImageUrl = x.ImageUrl,
                 Link = x.Link,
                 Subtitle=x.Subtitle ,
                 Title=x.Title 

                }).ToListAsync();
            return View(datas);
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();

        }
    }
}
