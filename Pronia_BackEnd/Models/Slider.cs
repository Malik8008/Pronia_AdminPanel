using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pronia_BackEnd.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public byte Discount { get; set; }
        public string DiscoverUrl { get; set; }
    }
}
