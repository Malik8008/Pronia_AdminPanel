using System.Collections.Generic;

namespace Pronia_BackEnd.Models
{
    public class Setting
    {
        public int Id { get; set; } 
        public string Key { get; set; }
        public string Value { get; set; }
        public string IconURL { get; set; }  
        public List<SocialMedia> socialMedias { get; set; }
    }
}
