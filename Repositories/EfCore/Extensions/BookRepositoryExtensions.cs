﻿using System;
using System.Reflection;
using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Repositories.EfCore.Extensions
{
	public static class BookRepositoryExtensions
	{
		public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice) =>
			books.Where(book => (book.Price >=minPrice) && (book.Price <=maxPrice));

		public static IQueryable<Book> Search(this IQueryable<Book> books,string searchTerm)
		{
			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				return books;
			}

			var lowerCaseTerm = searchTerm.Trim().ToLower();
			return books.Where(book => book.Title.ToLower().Contains(lowerCaseTerm));

            //lucene.net => arama kütüphanesi
        }

		public static IQueryable<Book> Sort(this IQueryable<Book> books,string orderByQueryString)
		{
			if (string.IsNullOrWhiteSpace(orderByQueryString)) { return books.OrderBy(b=>b.Id); }

			var orderQuery = OrderQueryBuilder.CreateOrderQuery<Book>(orderByQueryString);

			if (orderQuery is null) { return books.OrderBy(b=>b.Id); }

			return books.OrderBy(orderQuery);
        }
    }
}

