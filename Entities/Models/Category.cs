using System;
namespace Entities.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string? CategoryName { get; set; }

		//Ref : Collection navigation property
		//public ICollection<Book> Books { get; set; }
	}
}

