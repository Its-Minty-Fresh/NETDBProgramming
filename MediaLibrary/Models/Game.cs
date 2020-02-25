using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Models
{
    public class Game : Media
    {
        public string Rating { get; set; }

        public Game()
        {
            Rating = "PG";
        }
    }


}
