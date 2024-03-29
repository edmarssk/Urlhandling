﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Models;

namespace UrlHandling.Data.Context
{
    public class MainUrlHandlingDbContext : DbContext, IUnitOfWork
    {

        public MainUrlHandlingDbContext(DbContextOptions<MainUrlHandlingDbContext> options) : base(options)
        {
        }

        public DbSet<UrlLink> UrlLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder
                          .Model
                          .GetEntityTypes()
                          .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainUrlHandlingDbContext).Assembly);

            foreach (var relationShip in modelBuilder
                          .Model
                          .GetEntityTypes()
                          .SelectMany(e => e.GetForeignKeys()))
                relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return await base.SaveChangesAsync() > 0;
        }

    }
}
