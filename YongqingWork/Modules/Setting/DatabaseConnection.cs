
namespace YongqingWork.Modules.Setting
{
    public class DatabaseConnection:IDatabaseConnection
    {
        private readonly string _connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// 取得連線字串
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetConnString()
        {
            return this._connectionString;
        }
    }
}
