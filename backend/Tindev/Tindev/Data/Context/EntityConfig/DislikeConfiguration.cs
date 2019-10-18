using System.Data.Entity.ModelConfiguration;
using Tindev.Models;

namespace Tindev.Data.Context.EntityConfig
{
    public class DislikeConfiguration : EntityTypeConfiguration<Dislike>
    {
        public DislikeConfiguration()
        {
            ToTable("Dislikes");

            HasKey(c => c.DislikeId);

            HasRequired(d => d.Desenvolvedor).WithMany(d=> d.Dislikes).HasForeignKey( d=> d.DesenvolvedorId);
            HasRequired(d => d.Alvo).WithMany().HasForeignKey(d=> d.AlvoId);

        }
    }
}