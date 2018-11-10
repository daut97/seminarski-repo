using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klase
{
    public class Auto
    {
        [Key]
        public int AutoID { get; set; }
        public int ProizvodjacID { get; set;}
        [ForeignKey("ProizvodjacID")]
        public Proizvodjac Proizvodjac { get; set; }
        public string Model { get; set; }

        public string Boja { get; set; }
        public string Godiste { get; set; }
        public bool Novo { get; set; }

        

    }
}
