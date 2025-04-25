namespace WebApplication1.Models
{
	public enum TipoPermiso { Lectura, Escritura, Eliminacion }

	public class Permiso
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }

		public int DocumentoId { get; set; }
		public Documento Documento { get; set; }

		public TipoPermiso Tipo { get; set; }
	}
}
