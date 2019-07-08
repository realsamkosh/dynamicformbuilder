using InputSelectionDemo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InputSelectionDemo.Models
{
    public class FormCollection
    {
        public TPatient Patient { get; set; }
        public IList<TPatientFormChklist> PatientsCheckList { get; set; }
        public IList<TCustomFieldDefn> CustomFieldDefns { get; set; }
    }
}
