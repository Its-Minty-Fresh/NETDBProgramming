using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Models
{
    public class Album : Media
    {
        public string artist { get; set; }
        public string recordLabel { get; set; }

        public virtual void Display()
        {
            Console.WriteLine($"Id: {mediaId}\nTitle: {title}\nArtist: {artist}\nLabel: {recordLabel}\nGenres: {string.Join(", ", genres)}\n");
        }
    }

}
