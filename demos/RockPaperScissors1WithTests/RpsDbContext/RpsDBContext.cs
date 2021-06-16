using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RpsDbContext
{
    public partial class RpsDBContext : DbContext
    {
        public RpsDBContext()
        {
        }

        public RpsDBContext(DbContextOptions<RpsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RpsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.Player1Id).HasColumnName("Player1ID");

                entity.Property(e => e.Player2Id).HasColumnName("Player2ID");

                entity.Property(e => e.Round1Id).HasColumnName("Round1ID");

                entity.Property(e => e.Round2Id).HasColumnName("Round2ID");

                entity.Property(e => e.Round3Id).HasColumnName("Round3ID");

                entity.HasOne(d => d.Player1)
                    .WithMany(p => p.GamePlayer1s)
                    .HasForeignKey(d => d.Player1Id)
                    .HasConstraintName("FK__Games__Player1ID__3E52440B");

                entity.HasOne(d => d.Player2)
                    .WithMany(p => p.GamePlayer2s)
                    .HasForeignKey(d => d.Player2Id)
                    .HasConstraintName("FK__Games__Player2ID__3F466844");

                entity.HasOne(d => d.Round1)
                    .WithMany(p => p.GameRound1s)
                    .HasForeignKey(d => d.Round1Id)
                    .HasConstraintName("FK__Games__Round1ID__403A8C7D");

                entity.HasOne(d => d.Round2)
                    .WithMany(p => p.GameRound2s)
                    .HasForeignKey(d => d.Round2Id)
                    .HasConstraintName("FK__Games__Round2ID__412EB0B6");

                entity.HasOne(d => d.Round3)
                    .WithMany(p => p.GameRound3s)
                    .HasForeignKey(d => d.Round3Id)
                    .HasConstraintName("FK__Games__Round3ID__4222D4EF");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerFname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PlayerFName");

                entity.Property(e => e.PlayerLname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PlayerLName");
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.Property(e => e.RoundId).HasColumnName("RoundID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
