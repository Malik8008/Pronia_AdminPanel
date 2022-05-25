using Pronia_BackEnd.Models;
using System.Collections.Generic;

namespace Pronia_BackEnd.ViewModel.HomeVM
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Client> Clients { get; set; }

        public List<Plant> Plants { get; set; }

    }
}
