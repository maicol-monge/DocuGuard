using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Permiso
	{
		[Key]
		[Column("id_permiso")]
		public int Id { get; set; }

		[ForeignKey("Documento")]
		[Column("id_documento")]
		public int IdDocumento { get; set; }

		[ForeignKey("Usuario")]
		[Column("id_usuario")]
		public int IdUsuario { get; set; }

		[Required]
		[Column("nivel_acceso")]
		[MaxLength(50)]
		public string NivelAcceso { get; set; } // "lectura", "escritura", "eliminación"

		public virtual Documento Documento { get; set; }
		public virtual Usuario Usuario { get; set; }
	}
}
