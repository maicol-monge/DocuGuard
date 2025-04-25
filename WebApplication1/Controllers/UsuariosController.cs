using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Controllers
{
	public class UsuariosController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Usuarios/Register
		public ActionResult Register() => View();

		// POST: Usuarios/Register
		[HttpPost]
		public ActionResult Register(Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				usuario.Clave = HashPassword(usuario.Clave);
				db.Usuarios.Add(usuario);
				db.SaveChanges();
				return RedirectToAction("Login");
			}
			return View(usuario);
		}

		// GET: Usuarios/Login
		public ActionResult Login() => View();

		// POST: Usuarios/Login
		[HttpPost]
		public ActionResult Login(string correo, string clave)
		{
			string claveHash = HashPassword(clave);
			var user = db.Usuarios.FirstOrDefault(u => u.Correo == correo && u.Clave == claveHash);
			if (user != null)
			{
				HttpContext.Session.SetInt32("UsuarioId", user.Id);
				HttpContext.Session.SetString("Rol", user.Rol);
				return RedirectToAction("Index", "Home");
			}
			ViewBag.Error = "Credenciales inválidas";
			return View();
		}

		// GET: Usuarios/EditarClave
		public ActionResult EditarClave() => View();

		// POST: Usuarios/EditarClave
		[HttpPost]
		public ActionResult EditarClave(string claveActual, string claveNueva)
		{
			// Obtener el ID del usuario desde la sesión
			int? userId = HttpContext.Session.GetInt32("UsuarioId");
			if (userId == null)
			{
				// Si no hay sesión activa, redirigir al login
				return RedirectToAction("Login");
			}

			// Buscar el usuario en la base de datos
			var usuario = db.Usuarios.Find(userId.Value);
			if (usuario != null && usuario.Clave == HashPassword(claveActual))
			{
				// Actualizar la contraseña si la actual es correcta
				usuario.Clave = HashPassword(claveNueva);
				db.SaveChanges();
				ViewBag.Mensaje = "Contraseña actualizada correctamente";
			}
			else
			{
				// Mostrar mensaje de error si la contraseña actual no coincide
				ViewBag.Mensaje = "Contraseña actual incorrecta";
			}
			return View();
		}

		private string HashPassword(string password)
		{
			using (var sha = SHA256.Create())
			{
				byte[] bytes = Encoding.UTF8.GetBytes(password);
				byte[] hash = sha.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}
	}
}
