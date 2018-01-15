using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace UMT360.InteriorDesignWebApp.Repository.Core
{
    public abstract class BaseRepository<TModel>
    {
        #region Members
        protected static string _connectionString = GetConnectionString();
        #endregion

        #region Methods
        private static string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["InteriorDesignDB"];
            if(connectionStringSettings==null)
            {
                throw new ArgumentNullException("No connection string defined in the configuration file!");
            }
            return connectionStringSettings.ConnectionString;
        }
        
        public List<TModel> ReadAll(string storedProcedureName, SqlParameter[] parameters=default(SqlParameter[]))
        {            
            List<TModel> result = new List<TModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storedProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if(parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {                        

                                result.Add(GetModelFromReader(reader));
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
            }
            return result;
        }

        public void ExecuteNonQuery(string stroredProcedureName, IEnumerable<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = stroredProcedureName;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("There was a SQL error: {0}", sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }
            }
        }
        protected abstract TModel GetModelFromReader(SqlDataReader reader);        
        #endregion
    }
}
