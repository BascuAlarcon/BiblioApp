using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BibliotecaDAL
{
    public class DataBaseHelper : IDisposable
    {

        #region Variables
        private string _strConnectionString;
        private SqlConnection _objConnection;
        private SqlCommand _objCommand;

        #endregion


        #region Constructores

        public DataBaseHelper()
        {
            _strConnectionString = ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString;

            _objConnection = new SqlConnection();
            _objCommand = new SqlCommand();

            _objConnection.ConnectionString = _strConnectionString;
            _objCommand.Connection = _objConnection;
        }

        #endregion


        #region Methods (public) 

        #region AddParameters
        public void AddParameter(string name, object value)
        {
            _objCommand.Parameters.AddWithValue(name, value);
        }

        #endregion 

        #region ExecuteNonQuery

        public int ExecuteNonQuery(string spName, ref bool executionSucceeded)
        {
            return ExecuteNonQuery(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public int ExecuteNonQuery(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            _objCommand.CommandText = query;
            _objCommand.CommandType = commandtype;

            int i = -1;
            try
            {
                if (_objConnection.State == System.Data.ConnectionState.Closed)
                {
                    _objConnection.Open();
                }
                executionSucceeded = true;
                i = _objCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                executionSucceeded = false;
                Console.Write(ex);
            }
            finally
            {
                _objCommand.Parameters.Clear();
                if(connectionstate == ConnectionState.CloseOnExit)
                {
                    _objConnection.Close();
                }
            }
             
            return i;
        }
        #endregion

        #region DataSet

        public DataSet ExecuteDataSet(string spName, ref bool executionSucceeded)
        {
            return ExecuteDataSet(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public DataSet ExecuteDataSet(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            _objCommand.CommandText = query;
            _objCommand.CommandType = commandtype;
            sda.SelectCommand = _objCommand;
            var ds = new DataSet();
            try
            {
                executionSucceeded = true;
                sda.Fill(ds);
            }
            catch(Exception ex)
            {
                executionSucceeded = false;
                Console.Write(ex);
            }
            finally
            {
                _objCommand.Parameters.Clear();
                if ((connectionstate == ConnectionState.CloseOnExit) && (_objConnection.State == System.Data.ConnectionState.Open))
                {
                    _objConnection.Close();
                }
            }
            return ds;
        }

        #endregion

        #region ExecuteReader

        public SqlDataReader ExecuteReader(string spName, ref bool executionSucceeded)
        {
            return ExecuteReader(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public SqlDataReader ExecuteReader(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            _objCommand.CommandText = query;
            _objCommand.CommandType = commandtype;
            SqlDataReader reader = null;
            try
            {
                if(_objConnection.State == System.Data.ConnectionState.Closed)
                {
                    _objConnection.Open();
                }
                executionSucceeded = true;
                reader = connectionstate == ConnectionState.CloseOnExit 
                    ? _objCommand.ExecuteReader(CommandBehavior.CloseConnection) 
                    : _objCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                executionSucceeded = false;
                Console.Write(ex);
            }
            finally
            {
                _objCommand.Parameters.Clear();
            }
            return reader;
        }

        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string spName, ref bool executionSucceeded)
        {
            return ExecuteScalar(spName, CommandType.StoredProcedure, ConnectionState.CloseOnExit, ref executionSucceeded);
        }

        public object ExecuteScalar(string query, CommandType commandtype, ConnectionState connectionstate, ref bool executionSucceeded)
        {
            _objCommand.CommandText = query;
            _objCommand.CommandType = commandtype;
            object o = null;
            try
            {
                if(_objConnection.State == System.Data.ConnectionState.Closed)
                {
                    _objConnection.Open();
                }
                _objCommand.ExecuteScalar();
                executionSucceeded = true;
                o = _objCommand.Parameters[_objCommand.Parameters.Count - 1].Value;
            }
            catch(Exception ex)
            {
                executionSucceeded = false;
                Console.Write(ex);
            }
            finally
            {
                _objCommand.Parameters.Clear();
                if(connectionstate == ConnectionState.CloseOnExit)
                {
                    _objConnection.Close();
                }
            } 
            return o;
        }

        #endregion

        public void Dispose()
        {
            _objConnection.Close();
            _objConnection.Dispose();
            _objCommand.Dispose();
        }

        #endregion
    }

    public enum ConnectionState
    {
        KeepOpen, CloseOnExit
    }
}
