using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EntityDataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityDataContext
{
    public class EntityDatabaseContext : DbContext
    {
        public EntityDatabaseContext(DbContextOptions<EntityDatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=rotodb.c6nitrkqqrja.us-east-2.rds.amazonaws.com;Database=cls-db;User ID=admin;Password=root12345;");
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException($"{typeof(ModelBuilder)} is null");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
    }
}
