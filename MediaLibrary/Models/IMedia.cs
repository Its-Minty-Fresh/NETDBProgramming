using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Models
{
    public interface IMedia
    {
        void Play();
        void Rewind();

    }
}
