using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Klase
{
    public class Drzava
    {
        [Key]
        public int DrzavaID { get; set; }
        public string Naziv { get; set;}
    }
}
