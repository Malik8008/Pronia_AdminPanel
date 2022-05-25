using System.Collections.Generic;

namespace Pronia_BackEnd.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public List<Color> Colors { get; set; }
    }
}
