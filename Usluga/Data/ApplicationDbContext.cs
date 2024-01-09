using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using System.Data;
using System;
using Usluga.Data.Models;

namespace Usluga.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatEvent> ChatEvents { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<License> Licenses { get; set; }

        public virtual DbSet<LicenseOrganization> LicenseOrganizations { get; set; }

        public virtual DbSet<LicenseServicePackage> LicenseServicePackages { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Right> Rights { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServiceEvent> ServiceEvents { get; set; }

        public virtual DbSet<ServiceEventGraph> ServiceEventGraphs { get; set; }

        public virtual DbSet<ServiceEventStatus> ServiceEventStatuses { get; set; }

        public virtual DbSet<ServiceName> ServiceNames { get; set; }

        public virtual DbSet<ServicePackage> ServicePackages { get; set; }

        public virtual DbSet<ServicePackageName> ServicePackageNames { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatEventEntityConfig());


        }
    }
}