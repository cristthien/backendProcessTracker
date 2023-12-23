using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public int id { get; set; }

        public string tittle { get; set; }
        public string desciption { get; set; }
        public int location { get; set; }

        public int listCardid { get; set; }
        public ListCard listCard { get; set; }

    }
}
