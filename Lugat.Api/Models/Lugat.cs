using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lugat.Api.Models
{
    public class Lugat
    {
        public int Id { get; set; }
        public string Sira { get; set; }
        public string Kelime { get; set; }
        public string Kirpilmis { get; set; }
        public string Anlam { get; set; }
    }
}