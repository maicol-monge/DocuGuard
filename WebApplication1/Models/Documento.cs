using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Documento
	{
		[Key]
		[Column("id_documento")]
		public int Id { get; set; }

		[Required]
		[Column("titulo")]
		[MaxLength(255)]
		public string Titulo { get; set; }

		[Column("descripcion")]
		public string Descripcion { get; set; }

		[Column("ruta_archivo")]
		[MaxLength(500)]
		public string RutaArchivo { get; set; }

		[Column("fecha_subida")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public byte[] FechaSubida { get; set; } // Tipo TIMESTAMP en SQL Server → byte[]

		[Column("version")]
		public int Version { get; set; }

		[Column("estado")]
		[MaxLength(50)]
		public string Estado { get; set; }

		[ForeignKey("UsuarioSubida")]
		[Column("id_usuario_subida")]
		public int IdUsuarioSubida { get; set; }

		public virtual Usuario UsuarioSubida { get; set; }

		public virtual ICollection<Permiso> Permisos { get; set; }
	}
}
