using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class ColorRepository:BaseRepository<Color>
    {
        #region Methods
        public List<Color> ReadAll()
        {
            return  ReadAll("dbo.Colors_ReadAll");
        }

       

        public void Insert(Color color)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Colors_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ColorID", color.Id));
                        command.Parameters.Add(new SqlParameter("@ColorName", color.Name));

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
        public void Update(Color color)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Colors_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ColorID", color.Id));
                        command.Parameters.Add(new SqlParameter("@ColorName", color.Name));

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

        public void Delete(Guid colorId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Colors_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ColorID", colorId));

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

        public Color GetById(Guid colorId)
        {
            SqlParameter[] parameters ={ new SqlParameter("@ColorID", colorId) };
            List<Color> colors = ReadAll("dbo.Colors_GetById", parameters);
            return colors[0];            
        }

        public override Color GetModelFromReader(SqlDataReader reader)
        {
            Color color = new Color();
            color.Id = reader.GetGuid(reader.GetOrdinal("ColorID"));
            color.Name = reader.GetString(reader.GetOrdinal("Name"));
            return color;
        }
        #endregion
    }
}
