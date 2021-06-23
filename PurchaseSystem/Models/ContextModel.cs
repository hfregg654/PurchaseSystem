using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PurchaseSystem.Models
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ContextModel")
        {
        }

        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<Prouduct> Prouducts { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMaster>()
                .HasMany(e => e.Prouducts)
                .WithRequired(e => e.CategoryMaster)
                .HasForeignKey(e => e.prod_categoryid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_purid)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.order_prodid)
                .IsUnicode(false);

            modelBuilder.Entity<Prouduct>()
                .Property(e => e.prod_id)
                .IsUnicode(false);

            modelBuilder.Entity<Prouduct>()
                .Property(e => e.prod_price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Prouduct>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.Prouduct)
                .HasForeignKey(e => e.order_prodid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.pur_id)
                .IsUnicode(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.pur_total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.pur_assets)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Purchase>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.Purchase)
                .HasForeignKey(e => e.order_purid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_acc)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.user_pri)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Purchases)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.pur_creid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asset>()
                .Property(e => e.assets_total)
                .HasPrecision(18, 0);
        }
    }
}
