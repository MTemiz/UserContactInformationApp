﻿using Microsoft.EntityFrameworkCore;
using UserContactInformation.Application.Interface;
using UserContactInformation.Domain.Entities;
using UserContactInformation.Inftastructure.Persistence.Configuration;

namespace UserContactInformation.Inftastructure.Persistence.Context
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            builder.ApplyConfiguration(new PersonEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }
        public DbSet<Person> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}