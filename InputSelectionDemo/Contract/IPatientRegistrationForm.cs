using InputSelectionDemo.Infrastructure;
using InputSelectionDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InputSelectionDemo.Contract
{
    public interface IPatientRegistrationForm
    {
        IQueryable<TPatient> GetPatients();
        IQueryable<TPatientFormChklist> GetPatientFormChklists();

        FormCollection FormCollection();

        TPatient CreatePatient(TPatient model);
        Task CreateCustomValue(int patientid, long customid,string value, int merchantid);
    }
}
