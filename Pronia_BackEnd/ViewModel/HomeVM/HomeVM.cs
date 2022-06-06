using Pronia_BackEnd.Models;
using System.Collections.Generic;

namespace Pronia_BackEnd.ViewModel.HomeVM
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Client> Clients { get; set; }
        public List<Size> Sizes { get; set; }   
        public List<Plant> Plants { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; } 
        public List<Setting> Settings { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }



    }
}
