using System;
using System.Collections.Generic;

namespace InputSelectionDemo.Infrastructure
{
    public partial class TMerchant
    {
        public TMerchant()
        {
            TCustomFieldDefn = new HashSet<TCustomFieldDefn>();
            TCustomFieldValues = new HashSet<TCustomFieldValues>();
            TPatientFormChklist = new HashSet<TPatientFormChklist>();
        }

        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantCode { get; set; }

        public virtual ICollection<TCustomFieldDefn> TCustomFieldDefn { get; set; }
        public virtual ICollection<TCustomFieldValues> TCustomFieldValues { get; set; }
        public virtual ICollection<TPatientFormChklist> TPatientFormChklist { get; set; }
    }
}
