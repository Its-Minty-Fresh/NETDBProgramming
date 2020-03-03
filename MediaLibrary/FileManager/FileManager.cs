using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLibrary.Models;

namespace MediaLibrary.FileManager
{
    public abstract class FileManager
    {
        public static NLog.Logger logger = 
            NLog.LogManager.GetCurrentClassLogger();

        public string FiePath { get; set; }
        public List<Media> MediaMyProperty { get; set; }

        public abstract bool IsUniqueTitles(string title);

        public abstract void Add(Media media);
        
    }
}
