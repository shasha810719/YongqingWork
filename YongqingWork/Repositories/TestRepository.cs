using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Text;
using YongqingWork.Helpers;
using YongqingWork.Modules.Setting;
using YongqingWork.ViewModels;

namespace YongqingWork.Repositories
{
    
    /// <summary>
    /// 
    /// </summary>
    public class TestRepository: ITestRepository
    {

        private readonly IDatabaseConnection _databaseConnection;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="databaseConnection"></param>
        public TestRepository(IDatabaseConnection databaseConnection) 
        {
            _databaseConnection = databaseConnection;
        }

        /// <summary>
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerOrderViewModel>> GetCustomerOrderList(int orderId)
        {
            var search = new SqlExecutor(new SqlConnection(await _databaseConnection.GetConnString()));

            var sqlcmd = new StringBuilder();

            sqlcmd.Append(@"
                select o.OrderID,o.CustomerID,o.OrderDate,od.ProductID,p.ProductName,od.Quantity from [Orders] o WITH (NOLOCK)
                join [order details] od WITH (NOLOCK) on o.orderid = od.OrderID
                join [Products] p WITH (NOLOCK) ON od.ProductID  = p.ProductID
                where o.orderid = @orderid
            ");

            var model = new { orderid = orderId};
            return await search.QueryAsync<CustomerOrderViewModel>(sqlcmd.ToString(), model);
        }

    }
}
