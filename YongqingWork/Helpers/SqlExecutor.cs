using Dapper;
using System.Data;

namespace YongqingWork.Helpers
{
    public class SqlExecutor : IDbExecutor, IDisposable
    {
        private bool _transcationClosed = true;

        private readonly IDbConnection _dbConnection;

        private bool _transcationError;

        private string _transcationErrorMessage;

        private IDbTransaction _transaction;

        public SqlExecutor(IDbConnection dbConnection)
        {
            this._dbConnection = dbConnection;
        }

        public void BeginTransaction()
        {
            if (this._transcationClosed)
            {
                this._transcationClosed = false;
                if (this._dbConnection.State == ConnectionState.Closed)
                {
                    this._dbConnection.Open();
                }
                this._transaction = this._dbConnection.BeginTransaction();
            }
        }

        public void Commit()
        {
            this._transaction.Commit();
            this._transcationClosed = true;
        }

        public void Dispose()
        {
            if (!this._transcationClosed)
            {
                this.Rollback();
            }
            this._dbConnection.Dispose();
        }

        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            int num;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                num = SqlMapper.Execute(this._dbConnection, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                num = -1;
            }
            return num;
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            int num;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                num = await SqlMapper.ExecuteAsync(this._dbConnection, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                num = -1;
            }
            return num;
        }

        public string GetErrorMessage()
        {
            return this._transcationErrorMessage;
        }

        public IDbTransaction GetTransaction()
        {
            return this._transaction;
        }

        private void HandleTranscationError(string message)
        {
            this._transcationError = true;
            this._transcationErrorMessage = message;
        }

        public IEnumerable<dynamic> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            IEnumerable<object> objs;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                objs = SqlMapper.Query(this._dbConnection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                objs = null;
            }
            return objs;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            IEnumerable<T> ts;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                ts = SqlMapper.Query<T>(this._dbConnection, sql, param, transaction, buffered, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                ts = null;
            }
            return ts;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            IEnumerable<T> ts;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                ts = await SqlMapper.QueryAsync<T>(this._dbConnection, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                ts = null;
            }
            return ts;
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            SqlMapper.GridReader gridReader;
            try
            {
                if (this._transaction != null)
                {
                    transaction = this._transaction;
                }
                gridReader = await SqlMapper.QueryMultipleAsync(this._dbConnection, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception exception)
            {
                this.HandleTranscationError(exception.Message);
                gridReader = null;
            }
            return gridReader;
        }

        public void Rollback()
        {
            this._transaction.Rollback();
            this._transcationClosed = true;
        }

        public bool TranscationHasError()
        {
            return this._transcationError;
        }
    }
}