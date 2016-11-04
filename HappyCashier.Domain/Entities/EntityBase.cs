using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCashier.Domain.Entities
{
	public abstract class EntityBase
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}
