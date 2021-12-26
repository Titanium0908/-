using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Classes
{
    public partial class Restaurant : DbContext
    {
        public Restaurant()
            : base("name=Restaurant")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Chef> Chef { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<DishOrder> DishOrder { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientString> IngredientString { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Dish)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chef>()
                .Property(e => e.Chef_FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Chef>()
                .Property(e => e.Chef_Education)
                .IsUnicode(false);

            modelBuilder.Entity<Chef>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Chef)
                .HasForeignKey(e => e.Chef_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Dish_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Dish_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.DishOrder)
                .WithRequired(e => e.Dish)
                .HasForeignKey(e => e.Dish_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.IngredientString)
                .WithRequired(e => e.Dish)
                .HasForeignKey(e => e.Dish_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Ingredient_Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Ingredient_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.IngredientString)
                .WithRequired(e => e.Ingredient)
                .HasForeignKey(e => e.Ingredient_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DishOrder)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
