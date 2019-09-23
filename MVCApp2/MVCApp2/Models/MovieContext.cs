using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext() :base("MovieContext")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesCategory> MoviesCategories { get; set; }
        public DbSet<MoviesLanguage> MoviesLanguages { get; set; }
        public DbSet<StreamingPlatform> StreamingPlatforms { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<MVCApp2.Models.User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }
    }
}