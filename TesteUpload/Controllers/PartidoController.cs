using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TesteUpload.Models;

namespace TesteUpload.Controllers
{
    public class PartidoController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public PartidoController(IWebHostEnvironment  env)
        {
            _env = env;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Novo()
        {
            return View(new PartidoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Novo(PartidoViewModel partido, object imgh)
        {
            if (partido.Logotipo != null)
            {
                var uniqueFileName = GetUniqueFileName(partido.Logotipo.FileName);
                var uploads = Path.Combine(_env.WebRootPath,"uploads");
                var filePath = Path.Combine(uploads, uniqueFileName);
                await partido.Logotipo.CopyToAsync(new FileStream(filePath, FileMode.Create));

                //to do : Save uniqueFileName  to your db table   
            }


            return RedirectToAction("Index");
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
}