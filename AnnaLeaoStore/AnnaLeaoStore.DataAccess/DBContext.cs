using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AnnaLeaoStore.Model;

namespace AnnaLeaoStore.DataAccess
{
	public class DBContext : DbContext
    {
     
		public DbSet<ListaPrecosMOD> ListaPrecosMOD { get; set;}


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
