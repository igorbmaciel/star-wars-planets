using star_wars_planets.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace star_wars_planets.Data.Context
{
    internal class PlanetContextConfig : EntityTypeConfiguration<Planet>
    {
        public PlanetContextConfig()
        {
            ToTable("Planet");
            HasKey(x => x.Id);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Weather)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Ground)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.MovieQuantity)
                .IsRequired();

        }
    }
}