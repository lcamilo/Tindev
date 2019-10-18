using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tindev.Data.Context.EntityConfig;
using Microsoft.Extensions.Configuration;

namespace Tindev.Data.Context
{
    public class TindevContext : DbContext
    {

        public TindevContext()
        :base(Startup.GetConnectionString() ?? "server=69.162.84.204,41433;database=dbTindev;uid=tindevuser;password=\"37Q!0!;06-3*n9^.s7J100:*:8478x\"")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TindevContext>(new DropCreateDatabaseIfModelChanges<TindevContext>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new DesenvolvedorConfiguration());
            modelBuilder.Configurations.Add(new LikeConfiguration());
            modelBuilder.Configurations.Add(new DislikeConfiguration());

        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null || entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            try
        //            {
        //                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //            }
        //            catch (Exception e)
        //            {
        //                try
        //                {
        //                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
        //                }
        //                catch (Exception exception)
        //                {
        //                }
        //            }
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            try
        //            {
        //                entry.Property("DataCadastro").IsModified = false;
        //            }
        //            catch (Exception e)
        //            {
        //            }
        //            entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
        //        }
        //    }
        //    try
        //    {
        //        return base.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}