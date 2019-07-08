using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InputSelectionDemo.Infrastructure;
using InputSelectionDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace InputSelectionDemo.Contract
{
    public class PatientRegistrationForm : IPatientRegistrationForm
    {
        private readonly apiManagerDatabaseContext _context;

        public PatientRegistrationForm(apiManagerDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateCustomValue(int patientid, long customid, string value, int merchantid)
        {
            //var flag = "0";
            try
            {
                var initialdatabase = _context.Database;
                initialdatabase.OpenConnection();
                initialdatabase.SetCommandTimeout(0);
                DbCommand cmd = initialdatabase.GetDbConnection().CreateCommand();
                cmd.CommandText = "sp_createcustom_values";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@patientid", patientid));
                cmd.Parameters.Add(new SqlParameter("@merchantid", merchantid));
                cmd.Parameters.Add(new SqlParameter("@customvalues", value));
                cmd.Parameters.Add(new SqlParameter("@customid", customid));
                await cmd.ExecuteNonQueryAsync();
                initialdatabase.CloseConnection();
            }
            catch (Exception ex)
            {
                //flag = ex.Message;
            }
            //return flag;
        }

        public TPatient CreatePatient(TPatient model)
        {
            
            _context.TPatient.Add(model);
            _context.SaveChanges();
            return _context.TPatient.Where(x => x.PatientId == model.PatientId).FirstOrDefault();
        }

        public FormCollection FormCollection()
        {
            FormCollection formCollection = new FormCollection
            {
                PatientsCheckList = _context.TPatientFormChklist.Where(x => x.MerchantId == 1).ToList(),
                CustomFieldDefns = _context.TCustomFieldDefn.Where(x => x.MerchantId == 1).ToList()
            };
            return formCollection;
        }

        public IQueryable<TPatientFormChklist> GetPatientFormChklists()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TPatient> GetPatients()
        {
            throw new NotImplementedException();
        }
    }
}
