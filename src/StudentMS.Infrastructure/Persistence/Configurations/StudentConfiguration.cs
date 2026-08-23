using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentMS.Domain.Entities;


namespace StudentMS.Infrastructure.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(200);
            builder.HasIndex(s=>s.Email).IsUnique();
        }


    }
}
