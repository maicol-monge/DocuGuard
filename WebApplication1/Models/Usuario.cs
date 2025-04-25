namespace WebApplication1.Models
{
	public enum RolUsuario { Administrador, Usuario }

	public class Usuario
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Correo { get; set; }
		public string ContraseñaHash { get; set; }
		public RolUsuario Rol { get; set; }
	}
}
