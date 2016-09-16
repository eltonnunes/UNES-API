using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiUnes.Models.Object;

namespace ApiUnes.Models
{
    public partial class ServeLojaContext : DbContext
    {
        static ServeLojaContext()
        {
            Database.SetInitializer<ServeLojaContext>(null);
        }

        public ServeLojaContext()
            : base("Name=ModelApiUnes")
        {
            Database.CommandTimeout = 600; // 5 minutos
        }

        public DbSet<TB_PESSOA> TbPessoa { get; set; }
        public DbSet<TB_UNIVERSIDADE_ESTATISTICAS> TB_UNIVERSIDADE_ESTATISTICAS { get; set; }
        public DbSet<TB_UNIVERSIDADE_PERFIL> TbUniversidadePerfil { get; set; }
        public DbSet<TB_UNIVERSIDADE_TAG> TB_UNIVERSIDADE_TAG { get; set; }
        public DbSet<TB_UNIVERSIDADE_TOKEN_API> TB_UNIVERSIDADE_TOKEN_API { get; set; }
        public DbSet<TB_UNIVERSIDADE_VIDEOS> TB_UNIVERSIDADE_VIDEOS { get; set; }
        public DbSet<TB_USUARIO> TbUsuario { get; set; }
        public DbSet<TB_USUARIO_ALIAS> TB_USUARIO_ALIAS { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_PESSOA>().ToTable("TB_PESSOA", "dbo");
            modelBuilder.Entity<TB_UNIVERSIDADE_ESTATISTICAS>().ToTable("TB_UNIVERSIDADE_ESTATISTICAS", "dbo");
            modelBuilder.Entity<TB_UNIVERSIDADE_PERFIL>().ToTable("TB_UNIVERSIDADE_PERFIL", "dbo");
            modelBuilder.Entity<TB_UNIVERSIDADE_TAG>().ToTable("TB_UNIVERSIDADE_TAG", "dbo");
            modelBuilder.Entity<TB_UNIVERSIDADE_TOKEN_API>().ToTable("TB_UNIVERSIDADE_TOKEN_API", "dbo");
            modelBuilder.Entity<TB_UNIVERSIDADE_VIDEOS>().ToTable("TB_UNIVERSIDADE_VIDEOS", "dbo");
            modelBuilder.Entity<TB_USUARIO>().ToTable("TB_USUARIO", "dbo");
            modelBuilder.Entity<TB_USUARIO_ALIAS>().ToTable("TB_USUARIO_ALIAS", "dbo");
        }
    }
}