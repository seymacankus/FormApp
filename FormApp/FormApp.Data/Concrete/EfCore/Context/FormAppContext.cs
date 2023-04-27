using FormApp.Data.Concrete.EfCore.Config;
using FormApp.Data.Concrete.EfCore.Extensions;
using FormApp.Entity;
using FormApp.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Data.Concrete.EfCore.Context
{
    public class FormAppContext : IdentityDbContext<User>
    {
        public FormAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TestForm> TestForms { get; set; }
        public DbSet<TestFormField> TestFormFields { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            builder.ApplyConfigurationsFromAssembly(typeof(TestFormConfig).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
