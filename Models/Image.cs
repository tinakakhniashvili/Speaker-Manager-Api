using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakerManagerApi.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
    }
}