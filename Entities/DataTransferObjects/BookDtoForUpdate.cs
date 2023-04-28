using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   //record hemen hemen class ile aynı mantığa gelir.(referans type)
   //public record BookDtoForUpdate(int Id,string Title,decimal Price); alttaki ifade ile aynı mantık
    public record BookDtoForUpdate:BookDtoForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
}
