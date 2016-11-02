using System.ComponentModel.DataAnnotations.Schema;

namespace HappyCashier.Domain.Entities
{
	public class BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}
