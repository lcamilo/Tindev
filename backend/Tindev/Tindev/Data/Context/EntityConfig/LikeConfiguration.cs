using System.Data.Entity.ModelConfiguration;
using Tindev.Models;

namespace Tindev.Data.Context.EntityConfig
{
    public class LikeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeConfiguration()
        {
            ToTable("Likes");
            HasKey(c => c.LikeId);

            HasRequired(d => d.Desenvolvedor).WithMany(e => e.Likes).HasForeignKey( d=> d.DesenvolvedorId);
            HasRequired(d => d.Alvo).WithMany().HasForeignKey(d=> d.AlvoId);

        }
    }
}