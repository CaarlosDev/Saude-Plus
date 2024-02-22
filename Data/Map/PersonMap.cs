using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudePlus.Models;

namespace SaudePlus.Data.Map
{
    public class PersonMap : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).HasMaxLength(15);
            builder.Property(x => x.Birthday);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.IfSmoke).IsRequired();
            builder.Property(x => x.SmokeQuantity);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }
    }
}
