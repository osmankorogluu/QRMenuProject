using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.AboutDto
{
    public class CreateAboutDto
    {
        public string ImageUrl { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
    }
}
