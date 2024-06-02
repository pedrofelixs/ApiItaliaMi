using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiItaliaMi.Data.Mappings
{
    public class CittizenshipMap : IEntityTypeConfiguration<Cittizenship>
    {
        public void Configure(EntityTypeBuilder<Cittizenship> builder)
        {
            // Tabela
            builder.HasKey(x => x.Id);
            builder.ToTable("Cittizenships"); // Corrigido para "Cittizenships" ou o nome correto da tabela no seu banco de dados

            // Relacionamentos
            builder.HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.IdCustomer)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.IdUser)
                .IsRequired();

            // Outras propriedades
            builder.Property(x => x.CustomerCompleteName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ContractorEmail)
                .HasMaxLength(255);

            builder.Property(x => x.ContractorPhone)
                .HasMaxLength(11);

            // Outras configurações, se necessário

            // Índices, se necessário
        }
    }
}
