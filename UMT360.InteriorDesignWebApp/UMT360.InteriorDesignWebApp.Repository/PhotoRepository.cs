using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PhotoRepository
    {
        #region Methods
        public List<Photo> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Photo> photos = new List<Photo>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Photos_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Photo photo = new Photo();
                                photo.Id = reader.GetGuid(reader.GetOrdinal("PhotoID"));
                                photo.Image = (byte[])reader["Image"];                               

                                photos.Add(photo);
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

                    Console.WriteLine("There was an error: {0}", ex.StackTrace);
                }

            }
            return photos;
        }

        public void Insert(Photo photo)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Photos_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PhotoID", photo.Id));
                        command.Parameters.Add(new SqlParameter("@PhotoName", photo.Image));

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
        public void Update(Photo photo)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Photos_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PhotoID", photo.Id));
                        command.Parameters.Add(new SqlParameter("@PhotoName", photo.Image));

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
        public void Delete(Guid photoId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Photos_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PhotoID", photoId));

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

        public Photo GetById(Guid photoId)
        {
            Photo photo = new Photo();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Photos_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PhotoID", photoId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                photo.Id = reader.GetGuid(reader.GetOrdinal("PhotoID"));
                                photo.Image = (byte[])reader["Image"];

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

            return photo;
        }
        #endregion
    }
}
