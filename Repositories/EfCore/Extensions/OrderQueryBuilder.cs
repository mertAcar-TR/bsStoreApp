﻿using System;
using Entities.Models;
using System.Reflection;
using System.Text;

namespace Repositories.EfCore.Extensions
{
	public static class OrderQueryBuilder
	{
		public static String CreateOrderQuery<T>(string orderByQueryString)
		{
            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param)) { continue; }

                var properyFromQueryName = param.Split(' ')[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(properyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null) { continue; }

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
	}
}

