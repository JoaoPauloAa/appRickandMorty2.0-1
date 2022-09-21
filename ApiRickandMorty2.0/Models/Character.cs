using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRickandMorty2._0.Models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
        public int location { get; set; }
    }
}