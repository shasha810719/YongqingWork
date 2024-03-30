using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
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
        private string connectString = string.Empty;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="databaseConnection"></param>
        public TestRepository(IDatabaseConnection databaseConnection) 
        {
            _databaseConnection = databaseConnection;
            connectString = _databaseConnection.GetConnString().Result;
        }

        /// <summary>
        /// 取得客戶訂單列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerOrderViewModel>> GetCustomerOrderList(int orderId)
        {
            var search = new SqlExecutor(new SqlConnection(connectString));

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

        /// <summary>
        /// 新增客戶訂單
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> PostCustomerOrders(PostCustomerOrderViewModel data)
        {

            bool result = false;


            var insert = new SqlExecutor(new SqlConnection(connectString));

            insert.BeginTransaction();
            
            var orderCmd = new StringBuilder();
            orderCmd.Append(@"
            INSERT INTO [dbo].[Orders]
           ([CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName],[ShipAddress],
           [ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry])
            VALUES
           (@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,
           @ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry);

            SELECT SCOPE_IDENTITY();

                ");
            var para = new { CustomerID = data.CustomerID, EmployeeID = data.EmployeeID , OrderDate  = data.OrderDate , RequiredDate = data.RequiredDate , ShippedDate = data.ShippedDate , ShipVia = data.ShipVia , Freight = data.Freight , ShipName = data.ShipName ,
                ShipAddress = data.ShipAddress , ShipCity = data.ShipCity , ShipRegion = data.ShipRegion , ShipPostalCode = data.ShipPostalCode , ShipCountry = data.ShipCountry};

            var orderId = await insert.QueryAsync<int>(orderCmd.ToString(), para);


            var orderDetailCmd = new StringBuilder();

            orderDetailCmd.Append(@" 
            INSERT INTO [dbo].[Order Details]
           ([OrderID] ,[ProductID] ,[UnitPrice],[Quantity],[Discount])
            VALUES
            (@OrderID,@ProductID,@UnitPrice,@Quantity,@Discount);
            ");


            foreach (var item in data.OrderDetails)
            {
                var detailpara = new { OrderID = orderId, ProductID = item.ProductID, UnitPrice = item.UnitPrice, Quantity = item.Quantity, Discount = item.Discount };
                await insert.ExecuteAsync(orderDetailCmd.ToString(), detailpara);
            }
            
            if (insert.TranscationHasError())
            {
                insert.Rollback();
            }
            else
            {
                insert.Commit();
                result = true;
            }

            return result;
        }
    }
}
