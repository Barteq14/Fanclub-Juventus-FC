using FanclubJuventus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FanclubJuventus.DAL
{
    public class FanclubContext :DbContext
    {
        public FanclubContext() : base("DefaultConnection")
        {

        }
        public DbSet<DreamTeamProfile> DreamTeamProfile { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
       
        public DbSet<Product> Products { get; set; }
       
        public DbSet<Club> Clubs { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Coach> Coaches{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Betting> Betting { get; set; }
        public DbSet<FirstSquad> FirstSquad { get; set; }
        public DbSet<DeliveryOption> DeliveryOption { get; set; }
        public DbSet<KindOfDelivery> KindOfDelivery { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Basket_Product> Basket_Product { get; set; }
        public DbSet<Basket_ProductSize> Basket_ProductSize { get; set; }

        public DbSet<Status> Status { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumSubject> ForumSubjects { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}