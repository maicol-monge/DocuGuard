namespace WebApplication1.Models
{
	public class Documento
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public string RutaArchivo { get; set; }
		public string Estado { get; set; } // Activo, Archivado, En revisión
		public DateTime FechaSubida { get; set; }
		public int Version { get; set; }
		public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public ICollection<Permiso> Permisos { get; set; }
	}
}
