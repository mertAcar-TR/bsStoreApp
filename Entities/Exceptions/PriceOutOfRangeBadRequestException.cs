namespace Entities.Exceptions
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
                                                //Bir hata mesajı almasın statik mesaj üretsin.
        public PriceOutOfRangeBadRequestException() : base("Maxium price must be less than 1000 and greater than 10!")
        {
        }
    }
}

