using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer.Enteties;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer.EntetiesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DataAccesLayer.EF
{
    public class AppDBContext : IdentityDbContext<User>
    {
        // Data context, show with which type of objects we will work
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ForCompare> ForCompares { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UsersRefreshToken> UsersRefreshTokens { get; set; }
        // On creating an instance of ApplicationContext, program check if there is
        // a data base with the name from connection string, and if not create this DB
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            // Database.EnsureDeleted(); // delete DB with old diagram
            // Database.EnsureCreated(); // create DB with new diagram   
        }

        // Make connection to DB using method UseSqlServer
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = UAHP; Trusted_Connection = True; MultipleActiveResultSets=true");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AddConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new ForCompareConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
        }
    }
}
