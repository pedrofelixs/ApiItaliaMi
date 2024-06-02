using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiItaliaMi.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("Users");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.Username)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasMaxLength(11);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(11);

            builder.Property(x => x.Role)
                .HasMaxLength(255)
                .IsRequired();

            // Índices, se necessário

            // Relacionamentos, se houver
        }
    }
}
