using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace WebApplication1.Controllers
{
    public class DocumentosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentosController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Subir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subir(Documento documento, IFormFile archivo)
        {
            if (ModelState.IsValid && archivo != null && archivo.Length > 0)
            {
                var rutaCarpeta = Path.Combine(_environment.WebRootPath, "archivos");
                Directory.CreateDirectory(rutaCarpeta);

                var rutaArchivo = Path.Combine(rutaCarpeta, archivo.FileName);

                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                documento.RutaArchivo = "/archivos/" + archivo.FileName;
                documento.FechaSubida = null; // Se genera automáticamente por SQL Server
                documento.IdUsuarioSubida = 1; // Sustituye con el ID del usuario autenticado
                _context.Documentos.Add(documento);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Mensaje = "Faltan datos o el archivo no es válido.";
            return View(documento);
        }
    }
}
