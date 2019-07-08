using System;
using System.Collections.Generic;

namespace InputSelectionDemo.Infrastructure
{
    public partial class TCustomFieldDefn
    {
        public long CustomId { get; set; }
        public int? MerchantId { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }

        public virtual TMerchant Merchant { get; set; }
    }
}
