using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;
 
namespace Test.TestDataAccess
{
    class ExcelDataAccess<T1>
    {
        private const string CONNECTION = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;";

        public static string TestDataFileConnection(string db)
        {
            var fileName = ConfigurationManager.AppSettings[db];          
            var con = string.Format(CONNECTION, fileName);
            return con;
        }
 
        public static T1 GetTestData(string keyName, string db = "TestDataSheetPath")
        {
            using (var connection = new OleDbConnection(TestDataFileConnection(db)))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<T1>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}