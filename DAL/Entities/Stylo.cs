using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Stylo
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nom { get; set; }

        public string? Photo { get; set; }

        public float Prix { get; set; }

        [ForeignKey("NomMarque")]
        public Marque Marque { get; set; }
        [ForeignKey("NomType")]
        public TypeSt Type { get; set; }
        public string NomMarque { get; set; }
        public string NomType { get; set; }





    }
}
