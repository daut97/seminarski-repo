using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klase
{
    public class Proizvodjac
    {
        [Key]
        public int ProizvodjacID { get; set; }
        public string Naziv { get; set;}
        public int DrzavaID { get; set; }
        [ForeignKey("DrzavaID")]
        public Drzava Drzava { get; set; }

    }
}
