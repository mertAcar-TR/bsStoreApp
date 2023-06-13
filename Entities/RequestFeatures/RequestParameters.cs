using System;
namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
	{
		const int maxPageSize = 50;//kullanıcı bir sayfada max 50 kayıt listeleyebilir

		//Auto-implemented property(Logic işletmiyorsun)
		public int PageNumber { get; set; }

		//Full-property(Logic işletiyorsun)
		private int _pageSize;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > maxPageSize ? maxPageSize : value; }
		}

		public string? OrderBy { get; set; }
	}
}

