using Library.Entity;
using Microsoft.EntityFrameworkCore;
namespace Library.DAL.DBContext;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthorTbl> AuthorTbls { get; set; }

    public virtual DbSet<BookTbl> BookTbls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorTbl>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__AUTHOR_T__A839814580080B35");

            entity.ToTable("AUTHOR_TBL");

            entity.Property(e => e.AuthorId).HasColumnName("AUTHOR_ID");
            entity.Property(e => e.BirthDate).HasColumnName("BIRTH_DATE");
            entity.Property(e => e.BirthTown)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BIRTH_TOWN");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
        });

        modelBuilder.Entity<BookTbl>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__BOOK_TBL__054D27E4DC3AA341");

            entity.ToTable("BOOK_TBL");

            entity.Property(e => e.BookId).HasColumnName("BOOK_ID");
            entity.Property(e => e.AuthorId).HasColumnName("AUTHOR_ID");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENRE");
            entity.Property(e => e.NumPages).HasColumnName("NUM_PAGES");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TITLE");
            entity.Property(e => e.YearPublished).HasColumnName("YEAR_PUBLISHED");

            entity.HasOne(d => d.Author).WithMany(p => p.BookTbls)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__BOOK_TBL__AUTHOR__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
