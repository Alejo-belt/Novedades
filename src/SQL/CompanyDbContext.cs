using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OverTimeReport> OverTimeReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación uno a muchos entre Area y Employee
            modelBuilder.Entity<Area>()
                .HasMany(a => a.Employees)
                .WithOne(e => e.Area)
                .HasForeignKey(e => e.AreaId);

            // Configuración de la relación uno a muchos entre Employee y OverTimeReport
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.OverTimeReports)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            // Configuración de la autoreferencia para Leader
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Leader)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.LeaderId)
                .OnDelete(DeleteBehavior.Restrict); // Evita la eliminación en cascada

            // Configuración de la conversión de enum Role en Employee
            modelBuilder.Entity<Employee>()
                .Property(e => e.Rol)
                .HasConversion<int>(); // Esto asegura que el enum se almacene como int en la base de datos

            // Configuración de la conversión de enum Role en OverTimeReport
            modelBuilder.Entity<OverTimeReport>()
                .Property(r => r.Role)
                .HasConversion<int>(); // Esto asegura que el enum se almacene como int en la base de datos

            // Configuración de la conversión de enum State en OverTimeReport
            modelBuilder.Entity<OverTimeReport>()
                .Property(r => r.GetState)
                .HasConversion<int>(); // Esto asegura que el enum se almacene como int en la base de datos
        }
    }

}

