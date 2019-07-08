using System;
using System.Collections.Generic;

namespace InputSelectionDemo.Infrastructure
{
    public partial class TCustomFieldValues
    {
        public int PatientId { get; set; }
        public int? MerchantId { get; set; }
        public long? CustomId { get; set; }
        public string Value { get; set; }

        public virtual TMerchant Merchant { get; set; }
    }
}
