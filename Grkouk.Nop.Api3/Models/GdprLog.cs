﻿using System;

namespace Grkouk.Nop.Api3.Models
{
    public partial class GdprLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ConsentId { get; set; }
        public string CustomerInfo { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestDetails { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}