using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DALContacts
{
    public static class DBInteraction
    {
        //sql connection string and open connection
        private static SqlConnection GetDBConnection()
        {
            SqlConnection objConn;
            objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            objConn.Open();
            return objConn;
        }

        //get data in datatable
        public static DataTable GetTable(ref SqlCommand CommandObject)
        {
            SqlDataAdapter objAdapter;
            DataTable objTable = new DataTable();
            int intCtr = 0;
            try
            {
                objAdapter = new SqlDataAdapter();
                CommandObject.Connection = GetDBConnection();
                objAdapter.SelectCommand = CommandObject;
                intCtr = objAdapter.Fill(objTable);
                return objTable;
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                if (CommandObject.Connection != null)
                {
                    if (CommandObject.Connection.State == ConnectionState.Open)
                        CommandObject.Connection.Close();
                    CommandObject.Connection = null;
                }
            }
        }

        /// <summary>
        /// Execute Command Object in Database. Connection will be opened in this class.
        /// </summary>
        /// <param name="CommandObject">Command Object without connection property</param>
        /// <returns>bool</returns>
        public static bool ExecuteSQL(ref SqlCommand CommandObject)
        {
            bool isSucess = false;
            int intCtr = 0;
            try
            {
                CommandObject.Connection = GetDBConnection();
                intCtr = CommandObject.ExecuteNonQuery();
                if (intCtr > 0)
                    isSucess = true;
            }
            catch (Exception)
            {
                isSucess = false;
                throw;
            }
            finally
            {
                if (CommandObject.Connection != null)
                {
                    if (CommandObject.Connection.State == ConnectionState.Open)
                        CommandObject.Connection.Close();
                    CommandObject.Connection = null;
                }
            }
            return isSucess;
        }
    }
}
