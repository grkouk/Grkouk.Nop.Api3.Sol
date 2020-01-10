using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grkouk.Nop.Api3.Dtos
{
    public class ProductPictureDto
    {
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public string VirtualPath { get; set; }
        public string SeoFilename { get; set; } 
    }
}
