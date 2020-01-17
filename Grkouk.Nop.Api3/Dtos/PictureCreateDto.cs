using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grkouk.Nop.Api3.Dtos
{
    public class PictureCreateDto   
    {
     
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public string AltAttribute { get; set; }
        public string TitleAttribute { get; set; }
    }
}
