namespace Entities.RequestFeatures
{
    public class BookParameters:RequestParameters
	{
			//unsigned integer,negatif olamaz
		public uint MinPrice { get; set; }
		public uint MaxPrice { get; set; } = 1000;//sınırlandırdık
		public bool ValidPriceRange => MaxPrice > MinPrice;
		public string? SearchTerm { get; set; }

		public BookParameters()
		{
			OrderBy = "id";
		}
	}
}

