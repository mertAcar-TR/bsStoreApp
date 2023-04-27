using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   //record hemen hemen class ile aynı mantığa gelir.(referans type)
   //public record BookDtoForUpdate(int Id,string Title,decimal Price); alttaki ifade ile aynı mantık
    public record BookDtoForUpdate
    {
        public BookDtoForUpdate(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
        public int Id { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
    }
}
