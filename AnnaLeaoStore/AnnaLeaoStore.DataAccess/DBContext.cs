using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AnnaLeaoStore.Model;

namespace AnnaLeaoStore.DataAccess
{
	public class DBContext : DbContext
    {
     
		public DbSet<ListaPrecos> ListaPrecosMOD { get; set; }
		public DbSet<ListaPrecosItem> ListaPrecosItemMOD { get; set; }
		public DbSet<Produtos> ProdutosMOD { get; set; }
		public DbSet<Grades> GradesMOD { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			Database.SetInitializer<DBContext>(null);
            base.OnModelCreating(modelBuilder); 
		}

        private void FixEfProviderServicesProblem()
        {
            // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            // Make sure the provider assembly is available to the running application. 
            // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
