using System;
using System.Collections.Generic;

namespace InputSelectionDemo.Infrastructure
{
    public partial class TPatientFormChklist
    {
        public int ChklistId { get; set; }
        public bool IsPatientNameChkd { get; set; }
        public bool IsPatientEmailChkd { get; set; }
        public bool IsPatientGenderChkd { get; set; }
        public bool IsPatientAddressChkd { get; set; }
        public int MerchantId { get; set; }
        public string PatientNameLabel { get; set; }

        public virtual TMerchant Merchant { get; set; }
    }
}
