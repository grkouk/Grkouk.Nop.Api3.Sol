using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrKouk.Shared.Mobile.Dtos;

namespace Grkouk.Nop.Api3.Helpers
{
    public class CodeDtoComparer : IEqualityComparer<CodeDto>
    {
        public bool Equals(CodeDto p1, CodeDto p2)
        {
            return p1.Code == p2.Code;
        }

        public int GetHashCode(CodeDto p)
        {
            return p.Code.GetHashCode();
        }
    }
    public class ProductListDtoComparer : IEqualityComparer<ProductListDto>
    {
        public bool Equals(ProductListDto p1, ProductListDto p2)
        {
            return p1.Code == p2.Code;
        }

        public int GetHashCode(ProductListDto p)
        {
            return p.Code.GetHashCode();
        }
    }

}
