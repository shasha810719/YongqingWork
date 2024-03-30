using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Text;
using YongqingWork.Helpers;
using YongqingWork.Modules.Setting;
using YongqingWork.ViewModels;

namespace YongqingWork.Repositories
{
    
    public class TestRepository: ITestRepository
    {

        private readonly IDatabaseConnection _databaseConnection;

        public TestRepository(IDatabaseConnection databaseConnection) 
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomerList(string cityName)
        {
            var search = new SqlExecutor(new SqlConnection(await _databaseConnection.GetConnString()));

            var sqlcmd = new StringBuilder();

            sqlcmd.Append(@"
                SELECT * FROM Customers WITH (NOLOCK)
                WHERE city = @cityName

            ");

            var model = new { cityName  = cityName};
            return await search.QueryAsync<CustomerViewModel>(sqlcmd.ToString(), model);
        }

    }
}
