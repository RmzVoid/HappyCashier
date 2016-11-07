using System.Data.Entity;

namespace HappyCashier.Domain.DatabaseLayer
{
	public class SampleDatabaseContext : DatabaseContext
	{
		public SampleDatabaseContext()
			: base()
		{
			// database initialization policy: drop/create always
			// behaviour should be moved to configuration file
			Database.SetInitializer<SampleDatabaseContext>(new DatabaseInitializer<SampleDatabaseContext>());
		}
	}
}
