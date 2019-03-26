using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;
 
namespace Test.TestDataAccess
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection(string db)
        {
            var fileName = ConfigurationManager.AppSettings[db];          
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }
 
        public static UserData GetTestData(string keyName, string db = "TestDataSheetPath")
        {
            using (var connection = new OleDbConnection(TestDataFileConnection(db)))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<UserData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}