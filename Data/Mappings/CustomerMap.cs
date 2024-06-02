using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiItaliaMi.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Tabela
            builder.ToTable("Customers");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.CompleteName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.PersonalEmail)
                .HasMaxLength(255);

            builder.Property(x => x.PrenotamiEmail)
                .HasMaxLength(255);

            builder.Property(x => x.PrenotamiPassword)
                .HasMaxLength(255);

            builder.Property(x => x.FastitEmail)
                .HasMaxLength(255);

            builder.Property(x => x.FastitPassword)
                .HasMaxLength(255);

            builder.Property(x => x.Process)
                .HasMaxLength(255);
        }
    }
}
