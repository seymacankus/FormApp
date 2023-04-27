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
    public class TestFormFieldConfig : IEntityTypeConfiguration<TestFormField>
    {
        public void Configure(EntityTypeBuilder<TestFormField> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Required).IsRequired();
            builder.Property(x => x.DataType).IsRequired();
            builder.Property(x => x.TestFormId).IsRequired();
        }
    }
}
