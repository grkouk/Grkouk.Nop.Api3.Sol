﻿namespace Grkouk.Nop.Api3.Models
{
    public partial class CustomerAttributeValue
    {
        public int Id { get; set; }
        public int CustomerAttributeId { get; set; }
        public string Name { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }

        public virtual CustomerAttribute CustomerAttribute { get; set; }
    }
}