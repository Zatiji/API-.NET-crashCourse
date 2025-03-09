using System.Data;
using Dapper;
using IntermediateCSharpCourse.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace IntermediateCSharpCourse.Data {

    public class DataContextEF : DbContext { // inheritance -- also to learn the Entity Framework

        public DbSet<Computer>? Computer {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            if (!options.IsConfigured) {
                options.UseSqlServer( @"Server=localhost;" + // connection for mac and linux //Is a field
                                "Database=DotNetCourseDatabase;" + 
                                "TrustServerCertificate=true;" +
                                "Trusted_Connection=false;" +
                                "User Id=sa;" + 
                                "Password=Ceron500!;", 
                                options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId); 
                // .ToTable("Computer", "TutorialAppSchema"); // si le nom de la table ne correspond pas au nom de l'objet ?
                // .ToTable("TableName", "SchemaName");
        }

    }
}