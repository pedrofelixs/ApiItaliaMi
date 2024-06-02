using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiItaliaMi.Data.Mappings
{
    public class PassportMap : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            // Tabela
            builder.ToTable("Passports");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Relacionamentos
            builder.HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.IdCustomer)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.IdUser)
                .IsRequired();

            // Propriedades
            builder.Property(x => x.ContractorCompleteName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.ContractorEmail)
                .HasMaxLength(255);

            builder.Property(x => x.ContractorCPF)
                .HasMaxLength(11);

            builder.Property(x => x.ContractorPhone)
                .HasMaxLength(11);

            builder.Property(x => x.PrenotamiEmail)
                .HasMaxLength(255);

            builder.Property(x => x.PrenotamiPassword)
                .HasMaxLength(255);

            builder.Property(x => x.FastitEmail)
                .HasMaxLength(255);

            builder.Property(x => x.FastitPassword)
                .HasMaxLength(255);

            builder.Property(x => x.CompleteResidentialAddress)
                .HasMaxLength(255);

            builder.Property(x => x.CivilState)
                .HasMaxLength(255);

            builder.Property(x => x.MinorsCompleteNames)
                .HasMaxLength(100);

            // Outras configurações, se necessário
        }
    }
}
