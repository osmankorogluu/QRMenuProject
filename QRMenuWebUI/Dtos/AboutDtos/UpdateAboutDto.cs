using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenuWebUI.Dtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string ImageUrl { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
    }
}
