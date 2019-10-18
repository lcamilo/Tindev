using System.Data.Entity.ModelConfiguration;
using Tindev.Models;

namespace Tindev.Data.Context.EntityConfig
{
    public class DesenvolvedorConfiguration : EntityTypeConfiguration<Desenvolvedor>
    {
        public DesenvolvedorConfiguration()
        {
            ToTable("Desenvolvedores");
            HasKey(c => c.DesenvolvedorId);

            //HasOptional(d => d.Likes);
            //HasOptional(d => d.Dislikes);

            Property(x => x.Bio).HasMaxLength(int.MaxValue).HasColumnType("varchar(max)");

        }
    }
}