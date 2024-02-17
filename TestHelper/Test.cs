using Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHelper
{
    public class Test
    {

        private object[] employeeObject = {
              "@manager_id", 1,
              "@emp_fname", "test",
              "@emp_lname","test",
              "@dept_id",200,
              "@street", "test",
              "@city","test",
              "@state","test",
              "@zip_code","test",
              "@phone","test",
              "@status","T",
              "@ss_number","test",
              "@salary", 1.003,
              "@start_date", DateTime.Now,
              "@termination_date", DateTime.Now,
              "@birth_date",  DateTime.Now,
              "@bene_health_ins", "T",
              "@bene_life_ins","T",
              "@bene_day_care","T",
              "@gender", "T"     };
        public Test() { 
        
        
        }
        
        public int insertEmployeeReturnAffectedRowCount() {
            return DBHelper.ExecuteNonQuery(@"insert into [employee] (
             [manager_id]
             ,[emp_fname]
             ,[emp_lname]
             ,[dept_id]
             ,[street]
             ,[city]
             ,[state]
             ,[zip_code]
             ,[phone]
             ,[status]
             ,[ss_number]
             ,[salary]
             ,[start_date]
             ,[termination_date]
             ,[birth_date]
             ,[bene_health_ins]
             ,[bene_life_ins]
             ,[bene_day_care]
             ,[gender]
            ) values ( 
              @manager_id,
              @emp_fname,
              @emp_lname,
              @dept_id,
              @street,
              @city,
              @state,
              @zip_code,
              @phone,
              @status,
              @ss_number,
              @salary,
              @start_date,
              @termination_date,
              @birth_date,
              @bene_health_ins,
              @bene_life_ins,
              @bene_day_care,
              @gender
            );", employeeObject);
        }


        public int updateEmployeeReturnAffectedRowCount(int id) {
            //add field for emp_id
            List<object> templist = employeeObject.ToList();
            templist.Add("@EmpId");
            templist.Add(id);
            return DBHelper.ExecuteNonQuery(@"update [employee] 
            SET [manager_id] = @manager_id
                  ,[emp_fname] = @emp_fname
                  ,[emp_lname] = @emp_lname
                  ,[dept_id] = @dept_id
                  ,[street] = @street
                  ,[city] = @city
                  ,[state] = @state
                  ,[zip_code] = @zip_code
                  ,[phone] = @phone
                  ,[status] = @status
                  ,[ss_number] = @ss_number
                  ,[salary] = @salary
                  ,[start_date] = @start_date
                  ,[termination_date] = @termination_date
                  ,[birth_date] = @birth_date
                  ,[bene_health_ins] = @bene_health_ins
                  ,[bene_life_ins] = @bene_life_ins
                  ,[bene_day_care] = @bene_day_care
                  ,[gender] = @gender
             WHERE emp_id = @EmpId
            ;",
            templist.ToArray());
        }

        public object insertEmployeeReturnScalar()
        {
            return DBHelper.ExecuteScalar(@"insert into [employee] (
             [manager_id]
             ,[emp_fname]
             ,[emp_lname]
             ,[dept_id]
             ,[street]
             ,[city]
             ,[state]
             ,[zip_code]
             ,[phone]
             ,[status]
             ,[ss_number]
             ,[salary]
             ,[start_date]
             ,[termination_date]
             ,[birth_date]
             ,[bene_health_ins]
             ,[bene_life_ins]
             ,[bene_day_care]
             ,[gender]
            ) values ( 
              @manager_id,
              @emp_fname,
              @emp_lname,
              @dept_id,
              @street,
              @city,
              @state,
              @zip_code,
              @phone,
              @status,
              @ss_number,
              @salary,
              @start_date,
              @termination_date,
              @birth_date,
              @bene_health_ins,
              @bene_life_ins,
              @bene_day_care,
              @gender
            );", employeeObject);
        }


        public object updateEmployeeReturnScalar(int id)
        {
            //add field for emp_id
            List<object> templist = employeeObject.ToList();
            templist.Add("@EmpId");
            templist.Add(id);
            return DBHelper.ExecuteScalar(@"update [employee] 
            SET [manager_id] = @manager_id
                  ,[emp_fname] = @emp_fname
                  ,[emp_lname] = @emp_lname
                  ,[dept_id] = @dept_id
                  ,[street] = @street
                  ,[city] = @city
                  ,[state] = @state
                  ,[zip_code] = @zip_code
                  ,[phone] = @phone
                  ,[status] = @status
                  ,[ss_number] = @ss_number
                  ,[salary] = @salary
                  ,[start_date] = @start_date
                  ,[termination_date] = @termination_date
                  ,[birth_date] = @birth_date
                  ,[bene_health_ins] = @bene_health_ins
                  ,[bene_life_ins] = @bene_life_ins
                  ,[bene_day_care] = @bene_day_care
                  ,[gender] = @gender
             WHERE emp_id = @EmpId
            ;",
            templist.ToArray());
        }


        public List<Dictionary<string, object>> selectEmployeesReturnListOfDictionary() {
            var dt = DBHelper.ExecuteQuery("select * from [employee]", new object[] { });

            return dt.AsEnumerable()
             .Select(r => r.Table.Columns.Cast<DataColumn>().Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])).ToDictionary(z => z.Key, z => z.Value))
             .ToList();
        }

        public Dictionary<string, object> selectEmployeeByIdReturnListOfDictionary(int id)
        {
            //add field for emp_id
            List<object> templist = employeeObject.ToList();
            templist.Add("@EmpId");
            templist.Add(id);

            var dt = DBHelper.ExecuteQuery("select * from [employee] where emp_id = @EmpId", templist.ToArray());
            return dt.AsEnumerable()
             .Select(r => r.Table.Columns.Cast<DataColumn>().Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])).ToDictionary(z => z.Key, z => z.Value))
             .ToList().FirstOrDefault();
        }
    }
}
