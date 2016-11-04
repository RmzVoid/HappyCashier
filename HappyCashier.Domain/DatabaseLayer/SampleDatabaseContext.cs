using System.Data.Entity;

namespace HappyCashier.Domain.DatabaseLayer
{
	public class SampleDatabaseContext : DatabaseContext
	{
		public SampleDatabaseContext()
			: base()
		{
			// database initialization policy: drop/create always
			// beahviuor should be moved to configuration file
			Database.SetInitializer<DatabaseContext>(new SampleDatabaseInitializer());
		}
	}
}
