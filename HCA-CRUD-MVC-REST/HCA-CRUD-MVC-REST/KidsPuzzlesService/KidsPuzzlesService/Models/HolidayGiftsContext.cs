using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidsPuzzlesService.Models
{
    public partial class HolidayGiftsContext : DbContext
    {      
        public HolidayGiftsContext(DbContextOptions<HolidayGiftsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KidsPuzzles> KidsPuzzles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KidsPuzzles>(entity =>
            {
                entity.HasKey(e => e.PuzzleId)
                    .HasName("PK_ChristmasGifts-Puzzles");

                entity.Property(e => e.PuzzleId).HasColumnName("PuzzleID");

                entity.Property(e => e.PuzzleDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PuzzleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
