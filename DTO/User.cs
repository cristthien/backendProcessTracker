using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DTO
{
    [Table("User")]
    public class User
    {
        [Required]
        [Column("ID")]
        [Key]
        public int id { get; set; }

        [Column("Username", TypeName = "NVARCHAR(50)")]
        public string username{ get; set; }

        [Column("Password", TypeName = "NVARCHAR(60)")]
        [Required]
        public string hashPassword { get; set; }

        public ICollection<Viewer> Boards { get; set; }


    }
}
