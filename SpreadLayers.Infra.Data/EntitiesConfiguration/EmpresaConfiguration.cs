using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpreadLayers.Domain.Entities;

namespace SpreadLayers.Infra.Data.EntitiesConfiguration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.Segmento);
        }
    }
}