namespace ApiUnes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelApiUnes : DbContext
    {
        public ModelApiUnes()
            : base("name=ModelApiUnes1")
        {
        }

        public virtual DbSet<TB_PESSOA> TB_PESSOA { get; set; }
        public virtual DbSet<TB_UNIVERSIDADE_ESTATISTICAS> TB_UNIVERSIDADE_ESTATISTICAS { get; set; }
        public virtual DbSet<TB_UNIVERSIDADE_PERFIL> TB_UNIVERSIDADE_PERFIL { get; set; }
        public virtual DbSet<TB_UNIVERSIDADE_TAG> TB_UNIVERSIDADE_TAG { get; set; }
        public virtual DbSet<TB_UNIVERSIDADE_TOKEN_API> TB_UNIVERSIDADE_TOKEN_API { get; set; }
        public virtual DbSet<TB_UNIVERSIDADE_VIDEOS> TB_UNIVERSIDADE_VIDEOS { get; set; }
        public virtual DbSet<TB_USUARIO> TB_USUARIO { get; set; }
        public virtual DbSet<TB_USUARIO_ALIAS> TB_USUARIO_ALIAS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_PESSOA>()
                .Property(e => e.PES_IN_PESSOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_PESSOA>()
                .Property(e => e.PES_TX_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_PESSOA>()
                .Property(e => e.PES_TX_OBSERVACAO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_PERFIL>()
                .Property(e => e.UNP_TX_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_PERFIL>()
                .HasMany(e => e.TB_USUARIO)
                .WithMany(e => e.TB_UNIVERSIDADE_PERFIL)
                .Map(m => m.ToTable("TB_UNIVERSIDADE_PERFIL_USUARIO").MapLeftKey("UNP_ID_PERFIL").MapRightKey("USU_ID_USUARIO"));

            modelBuilder.Entity<TB_UNIVERSIDADE_PERFIL>()
                .HasMany(e => e.TB_UNIVERSIDADE_VIDEOS)
                .WithMany(e => e.TB_UNIVERSIDADE_PERFIL)
                .Map(m => m.ToTable("TB_UNIVERSIDADE_VIDEOS_PERFIL").MapLeftKey("UNP_ID_PERFIL").MapRightKey("UNV_ID_VIDEO"));

            modelBuilder.Entity<TB_UNIVERSIDADE_TAG>()
                .Property(e => e.UNT_TX_NOME)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_TAG>()
                .HasMany(e => e.TB_UNIVERSIDADE_VIDEOS)
                .WithRequired(e => e.TB_UNIVERSIDADE_TAG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_TOKEN_API>()
                .Property(e => e.UTA_TX_TOKEN)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_VIDEOS>()
                .Property(e => e.UNV_TX_TITULO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_VIDEOS>()
                .Property(e => e.UNV_TX_DESCRICAO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_VIDEOS>()
                .Property(e => e.UNV_TX_HASH)
                .IsUnicode(false);

            modelBuilder.Entity<TB_UNIVERSIDADE_VIDEOS>()
                .HasMany(e => e.TB_UNIVERSIDADE_ESTATISTICAS)
                .WithRequired(e => e.TB_UNIVERSIDADE_VIDEOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.USU_TX_USUARIO)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .Property(e => e.USU_TX_CONFERENCIA)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO>()
                .HasMany(e => e.TB_UNIVERSIDADE_ESTATISTICAS)
                .WithRequired(e => e.TB_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_USUARIO>()
                .HasMany(e => e.TB_UNIVERSIDADE_TOKEN_API)
                .WithRequired(e => e.TB_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_USUARIO>()
                .HasMany(e => e.TB_USUARIO_ALIAS)
                .WithRequired(e => e.TB_USUARIO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TB_USUARIO_ALIAS>()
                .Property(e => e.UAL_TX_ALIAS)
                .IsUnicode(false);

            modelBuilder.Entity<TB_USUARIO_ALIAS>()
                .Property(e => e.UAL_TX_SENHA)
                .IsUnicode(false);
        }
    }
}
