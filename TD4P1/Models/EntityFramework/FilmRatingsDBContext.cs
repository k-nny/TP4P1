using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using TD4P1.Models.EntityFramework;

namespace TD4P1.Models.EntityFramework
{
    public partial class FilmRatingsDBContext : DbContext
    {
        public FilmRatingsDBContext()
        {
        }

        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notation> Notation { get; set; }

        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        public virtual DbSet<Film> Film { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseLoggerFactory(MyLoggerFactory)
//                        .EnableSensitiveDataLogging()
//                        .UseNpgsql("Server=localhost;port=5432;Database=NotationDB; uid=postgres; password=postgres;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId }).HasName("pk_notation");

                entity.HasOne(d => d.FilmNote).WithMany(p => p.NotesFilm)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_notation_film");

                entity.HasOne(d => d.UtilisateurNotant).WithMany(p => p.NotesUtilisateur)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_notation_utilisateur");
            });
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => e.FilmId).HasName("pk_film");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.UtilisateurId).HasName("pk_utilisateur");
                entity.Property(b => b.DateCreation)
                    .HasDefaultValueSql("now()");
                entity.Property(b => b.Pays)
                    .HasDefaultValue("France");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
