using System;
using Entities.Models;

namespace Repositories.EfCore
{
	public static class BookRepositoryExtensions
	{
		public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice) =>
			books.Where(book => (book.Price >=minPrice) && (book.Price <=maxPrice));
	}
}

