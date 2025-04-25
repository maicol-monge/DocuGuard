using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Documento> Documentos { get; set; }
		public DbSet<Permiso> Permisos { get; set; }



    }
}
