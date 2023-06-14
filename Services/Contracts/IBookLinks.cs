using System;
using Entities.DataTransferObjects;
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;

namespace Services.Contracts
{
	public interface IBookLinks
	{
		LinkResponse TryGenerateLinks(IEnumerable<BookDto> bookDto,string fields,HttpContext httpContext);
	}
}

