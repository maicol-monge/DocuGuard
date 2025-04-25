using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Usuario
	{
		[Key]
		[Column("id_usuario")]
		public int Id { get; set; }

		[Required]
		[Column("nombre")]
		[MaxLength(100)]
		public string Nombre { get; set; }

		[Required]
		[Column("apellido")]
		[MaxLength(100)]
		public string Apellido { get; set; }

		[Required]
		[Column("correo")]
		[EmailAddress]
		[MaxLength(50)]
		public string Correo { get; set; }

		[Required]
		[Column("clave")]
		[MaxLength(255)]
		public string Clave { get; set; }

		[Required]
		[Column("rol")]
		[MaxLength(50)]
		public string Rol { get; set; }

		public virtual ICollection<Documento> DocumentosSubidos { get; set; }
		public virtual ICollection<Permiso> Permisos { get; set; }
	}
}
