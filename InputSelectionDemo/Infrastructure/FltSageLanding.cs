using System;
using System.Collections.Generic;

namespace InputSelectionDemo.Infrastructure
{
    public partial class FltSageLanding
    {
        public int SageId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ProcessingCode { get; set; }
        public decimal? Amount { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TransRef { get; set; }
        public DateTime? FetchDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string MembershipGrade { get; set; }
        public string Status { get; set; }
    }
}
