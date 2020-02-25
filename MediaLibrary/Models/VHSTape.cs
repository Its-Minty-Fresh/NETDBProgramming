using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Models
{
    class VHSTape : IMedia
    {
        void IMedia.Play()
        {
            throw new NotImplementedException();
        }

        void IMedia.Rewind()
        {
            throw new NotImplementedException();
        }
    }
}
