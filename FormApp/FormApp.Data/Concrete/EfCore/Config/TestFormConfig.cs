using FormApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Data.Concrete.EfCore.Config
{
    public class TestFormConfig : IEntityTypeConfiguration<TestForm>
    {
        public void Configure(EntityTypeBuilder<TestForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
