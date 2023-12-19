using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    [Table("Board")]
    public class Board
    {

        [Key]
        [Column("ID")]
        public int id { get; set; }


        [Column("Name", TypeName = "NVARCHAR(50)")]
        public string name { get; set; }

        [Column("Color", TypeName = "NVARCHAR(20)")]
        public string color { get; set; }
        
        
        [Required]
        public User owner { get; set; }


        public List<Viewer> Viewers { get; set; }

    }
}
