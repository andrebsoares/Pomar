using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomar.Models;
using System.IO;

namespace Pomar.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DataContext()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Arvore> Arvores { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<GrupoArvore> GrupoArvores { get; set; }
        public DbSet<Colheita> Colheitas { get; set; }
        public DbSet<ColheitaArvore> ColheitaArvores { get; set; }

        private void ConfiguraUser(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<User>(x =>
            {
                x.ToTable("tb_user");
                x.HasKey(c => c.Codigo).HasName("Pk_User");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                x.Property(c => c.Usuario).HasColumnName("Usuario");
                x.HasIndex(c => c.Usuario).IsUnique();
                x.Property(c => c.Senha).HasColumnName("Senha");
                x.Property(c => c.Cargo).HasColumnName("Cargo");
            });
        }
        private void ConfiguraArvore(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<Arvore>(x =>
            {
                x.ToTable("tb_arvore");
                x.HasKey(c => c.Codigo).HasName("Pk_Arvore");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                x.Property(c => c.Descricao).HasColumnName("Descricao");
                x.Property(c => c.DataPlantio).HasColumnName("DataPlantio");

                x.HasOne(c => c.Especie).WithMany(c => c.Arvores).HasForeignKey(c => c.EspecieId);

                x.HasOne(c => c.GrupoArvore).WithMany(c => c.Arvores).HasForeignKey(c => c.GrupoArvoreId);
            });
        }

        private void ConfiguraEspecie(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<Especie>(x =>
            {
                x.ToTable("tb_especie");
                x.HasKey(c => c.Codigo).HasName("Pk_Especie");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                x.Property(c => c.Descricao).HasColumnName("Descricao");
            });
        }

        private void ConfiguraGrupoArvore(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<GrupoArvore>(x =>
            {
                x.ToTable("tb_grupoarvore");
                x.HasKey(c => c.Codigo).HasName("Pk_Grupoarvore");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                x.Property(c => c.Descricao).HasColumnName("Descricao");
            });
        }

        private void ConfiguraColheita(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<Colheita>(x =>
            {
                x.ToTable("tb_colheita");
                x.HasKey(c => c.Codigo).HasName("Pk_Colheita");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();
                x.Property(c => c.Informacoes).HasColumnName("Informacoes");
                x.Property(c => c.PesoBruto).HasColumnName("PesoBruto").HasColumnType("decimal(18,2)");
            });
        }
        private void ConfiguraColheitaArvore(ModelBuilder contrutorModels)
        {
            contrutorModels.Entity<ColheitaArvore>(x =>
            {
                x.ToTable("tb_colheitaarvore");
                x.HasKey(c => c.Codigo).HasName("Pk_ColheitaArvore");
                x.Property(c => c.Codigo).HasColumnName("Codigo").ValueGeneratedOnAdd();

                x.HasOne(c => c.Arvore).WithMany(c => c.ColheitasArvore).HasForeignKey(c => c.ArvoreId);
                x.HasOne(c => c.Colheita).WithMany(c => c.ColheitaArvores).HasForeignKey(c => c.ColheitaId);
            });
        }

        protected override void OnModelCreating(ModelBuilder contrutorModels)
        {
            contrutorModels.UseIdentityColumns();// ForSqlServerUseIdentityColumns();
            contrutorModels.HasDefaultSchema("bdPomar");

            ConfiguraUser(contrutorModels);
            ConfiguraEspecie(contrutorModels);
            ConfiguraArvore(contrutorModels);
            ConfiguraGrupoArvore(contrutorModels);
            ConfiguraColheita(contrutorModels);
            ConfiguraColheitaArvore(contrutorModels);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            dbContextOptionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            dbContextOptionsBuilder.UseLazyLoadingProxies();
        }
    }
}