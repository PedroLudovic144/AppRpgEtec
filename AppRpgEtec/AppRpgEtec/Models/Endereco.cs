using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Licence { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Classification { get; set; }
        public string Type { get; set; }
        public int PlaceRank { get; set; }
        public double Importance { get; set; }
        public string Addresstype { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string[] Boundingbox { get; set; }
    }
}
