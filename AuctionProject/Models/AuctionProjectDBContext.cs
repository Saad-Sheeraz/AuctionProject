using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuctionProject.Models
{
    public partial class AuctionProjectDBContext : DbContext
    {
        //public AuctionProjectDBContext()
        //{
        //}

        public AuctionProjectDBContext(DbContextOptions<AuctionProjectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<TblBiddingTable> TblBiddingTables { get; set; }
        public virtual DbSet<TblInventory> TblInventories { get; set; }
        public virtual DbSet<TblUserDataLogin> TblUserDataLogins { get; set; }
        public virtual DbSet<TblUsersRole> TblUsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1PQ5IS3\\SQLEXPRESS;Database=AuctionProjectDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");
            });

            modelBuilder.Entity<TblBiddingTable>(entity =>
            {
                entity.HasKey(e => e.BiddingId);

                entity.ToTable("tbl_BiddingTable");

                entity.Property(e => e.BiddingId).HasColumnName("Bidding_ID");

                entity.Property(e => e.BidCloseStatus).HasColumnName("bidCloseStatus");

                entity.Property(e => e.BidderId).HasColumnName("bidderId");

                entity.Property(e => e.Bidval)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("bidval");

                entity.Property(e => e.Dateofbid)
                    .HasColumnType("date")
                    .HasColumnName("dateofbid");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.TblBiddingTables)
                    .HasForeignKey(d => d.BidderId)
                    .HasConstraintName("FK_tbl_BiddingTable_tbl_UserDataLogin");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.TblBiddingTables)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_tbl_BiddingTable_tbl_Inventory");
            });

            modelBuilder.Entity<TblInventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId);

                entity.ToTable("tbl_Inventory");

                entity.Property(e => e.InventoryId).HasColumnName("Inventory_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("imgPath");

                entity.Property(e => e.InvName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Inv_name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblInventories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tbl_Inventory_tbl_UserDataLogin");
            });

            modelBuilder.Entity<TblUserDataLogin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_UserDataLogin");

                entity.Property(e => e.UserId).HasColumnName("user_ID");

                entity.Property(e => e.DateofRegister)
                    .HasColumnType("date")
                    .HasColumnName("dateofRegister");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserDataLogins)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tbl_UserDataLogin_tbl_UsersRole");
            });

            modelBuilder.Entity<TblUsersRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tbl_UsersRole");

                entity.Property(e => e.RoleId).HasColumnName("role_ID");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
