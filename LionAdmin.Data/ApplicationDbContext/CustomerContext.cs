using LionAdmin.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionAdmin.Data.ApplicationDbContext
{
    public class CustomerContext : IdentityDbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
        { }
        public DbSet<Customer> customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<tCustomer>().ToTable("Customer");
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Seed();
        }
    }
}
