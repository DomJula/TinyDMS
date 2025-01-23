using Microsoft.EntityFrameworkCore;
using TinyDmsBackend.Models;

public class AppDbContext : DbContext
{
    public DbSet<Doc_Contract> Contracts {get; set;}    // DbSet für Verträge
    public DbSet<Doc_File> Files {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=app.db");
    }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabelle Doc_Contract konfigurieren
            modelBuilder.Entity<Doc_Contract>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.ContractNumber)
                      .IsUnique();

                entity.Property(e => e.ContractNumber)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Title)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.StartDate)
                      .IsRequired();

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Status)
                      .HasDefaultValue("active")
                      .HasMaxLength(20);

                entity.HasOne(e => e.File)
                      .WithOne(f => f.Contract)
                      .HasForeignKey<Doc_Contract>(e => e.FileId);
            });

            // Tabelle Doc_File konfigurieren
            modelBuilder.Entity<Doc_File>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FileName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.FilePath)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(e => e.Timestamp)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FileType)
                      .HasMaxLength(50);

                entity.Property(e => e.Description)
                      .HasColumnType("text");

                entity.Property(e => e.Labels)
                      .HasColumnType("text");
            });

        }   
}