using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;
using Pronia.Migrations;
using Pronia.Models;
using Pronia.ViewModels.Slider;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(ProniaDbContext _context,IWebHostEnvironment _env) : Controller
    {
        public async Task< IActionResult> Index()
        {
           
              return View(await _context.Sliders.ToListAsync());
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost ]
        public async Task<IActionResult> Create(SliderCreateVM vm) 
        {
            
            if (vm.File.ContentType.StartsWith("images"))
               ModelState.AddModelError("File","File type must be an image");           
            if(vm.File.Length>800 * 1024)
               ModelState.AddModelError("File", "File length must be lees than 888kb");
            
            if (!ModelState.IsValid) return View();
            string newFileName = Path.GetRandomFileName() + Path.GetExtension(vm.File.FileName );
            using (Stream stream = System.IO.File.Create(Path.Combine(_env.WebRootPath ,"imgs","sliders",newFileName )))
            {
                await vm.File.CopyToAsync(stream );
            }
            Slider slider = new Slider
            {
                Title=vm.Title,
                Subtitle=vm.Subtitle ,
                Link =vm.Link,
                ImageUrl=newFileName ,                
            };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof (Index));
        }
    }
}
