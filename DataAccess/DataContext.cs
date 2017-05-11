using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccess;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(): base("Clinic2.0")
        {
            Database.SetInitializer<DataContext>(new DbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TypeOfService> TypesOfServices { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<Card>().HasOptional(c => c.Pet).WithRequired(p => p.Card);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
