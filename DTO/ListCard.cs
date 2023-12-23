using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("List Card")]
    public class ListCard
    {
        [Key]
        public int id{ get; set; }

        public string name { get; set; }

        public int location { get; set; }

        public int boardID { get; set; }
        public Board board { get; set; }
    }
}
