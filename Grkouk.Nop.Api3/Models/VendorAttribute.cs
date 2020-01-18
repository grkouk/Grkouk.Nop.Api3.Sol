using System.Collections.Generic;

namespace Grkouk.Nop.Api3.Models
{
    public partial class VendorAttribute
    {
        public VendorAttribute()
        {
            VendorAttributeValue = new HashSet<VendorAttributeValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public int AttributeControlTypeId { get; set; }

        public virtual ICollection<VendorAttributeValue> VendorAttributeValue { get; set; }
    }
}
