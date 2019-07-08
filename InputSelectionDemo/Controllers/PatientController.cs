using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InputSelectionDemo.Contract;
using InputSelectionDemo.Infrastructure;
using InputSelectionDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InputSelectionDemo.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRegistrationForm form_setup;
        private readonly apiManagerDatabaseContext context;

        public PatientController(IPatientRegistrationForm form_Setup, apiManagerDatabaseContext context)
        {
            this.form_setup = form_Setup;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[Route("patient_registration")]
        public IActionResult PatientReg()
        {
            var gtconfig = this.form_setup.FormCollection();
            return View(gtconfig);
        }

        [HttpPost]
        public IActionResult Add_PatientReg(FormCollection model, string[] customvalues, string[] Labels)
        {
            //Profile the Patient
            var result = this.form_setup.CreatePatient(model.Patient);
            //Get the Defined Custom Fields
            var getCustomFields = this.context.TCustomFieldDefn.Where(x => x.MerchantId == 1).ToList();

            //Check the Number of customvalues and Labels
            if (customvalues.Count() != Labels.Count())
                return View();
            else
                for (int i = 0; i < customvalues.Count(); i++)
                {
                    if (getCustomFields.Any(x => x.Label == Labels[i]) == true)
                    {
                        var custid = getCustomFields.FirstOrDefault(x => x.Label == Labels[i]).CustomId;

                        this.form_setup.CreateCustomValue(result.PatientId, custid, customvalues[i], 1);
                    }
                }
            return View();
        }

        [HttpPost]
        public JsonResult PatientAPI()
        {
            DataTable table = new DataTable();
            using (DbDataAdapter adapter = new SqlDataAdapter())
            {
                var initialdatabase = new apiManagerDatabaseContext().Database;
                initialdatabase.OpenConnection();
                initialdatabase.SetCommandTimeout(0);
                DbCommand cmd = initialdatabase.GetDbConnection().CreateCommand();
                cmd.CommandText = "sp_normalized_custom_data";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                //var reader = cmd.ExecuteReader();

                //var model = Read(reader).ToList();
                //initialdatabase.CloseConnection();
                //Columns Not Needed to Appear
                
                adapter.Fill(table);

            };
            string[] existingcol = { "patient_id","merchant_id"};
            foreach (string colName in existingcol)
            {
                table.Columns.Remove(colName);
            }

            for (int i = 0; i <= table.Columns.Count - 1; i++)
            {
                table.Columns[i].ColumnName = table.Columns[i].ToString().Replace("_", " ");
            }
            return Json(table);
        }

        public IActionResult PatientList()
        {
            return View();
        }

        public IActionResult PatientRecordUpdate()
        {
            return View();
        }
        public IActionResult ChkListPatient()
        {
            return View();
        }

        private static IEnumerable<object[]> Read(DbDataReader reader)
        {
            while (reader.Read())
            {
                var values = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    values.Add(reader.GetValue(i));
                }
                yield return values.ToArray();
            }
        }

        public DataTable QueryToTable(apiManagerDatabaseContext db, string queryText, SqlParameter[] parametes)
        {
            using (DbDataAdapter adapter = new SqlDataAdapter())
            {
                var initialdatabase = db.Database;
                initialdatabase.SetCommandTimeout(0);
                DbCommand cmd = initialdatabase.GetDbConnection().CreateCommand();
                cmd.CommandText = "sp_normalized_custom_data";
                cmd.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = cmd;
                if (parametes != null)
                    adapter.SelectCommand.Parameters.AddRange(parametes);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}