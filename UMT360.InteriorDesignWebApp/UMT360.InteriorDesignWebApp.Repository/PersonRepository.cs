using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Repository
{
    class PersonRepository
    {
        #region Methods
        public List<Person> ReadAll()
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            List<Person> persons = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Persons_ReadAll";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Person person = new Person();
                                person.Id = reader.GetGuid(reader.GetOrdinal("PersonID"));
                                person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                person.Street = reader.GetString(reader.GetOrdinal("Street"));
                                person.Number = reader.GetString(reader.GetOrdinal("Number"));
                                person.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
                                person.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));                                
                                person.CityId = reader.GetGuid(reader.GetOrdinal("CityID"));
                                person.AccountId = reader.GetGuid(reader.GetOrdinal("AccountID"));

                                persons.Add(person);
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
            return persons;
        }

        public void Insert(Person person)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Persons_Create";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PersonID", person.Id));
                        command.Parameters.Add(new SqlParameter("@FirstName", person.FirstName));
                        command.Parameters.Add(new SqlParameter("@LastName", person.LastName));
                        command.Parameters.Add(new SqlParameter("@Street", person.Street));
                        command.Parameters.Add(new SqlParameter("@Number", person.Number));
                        command.Parameters.Add(new SqlParameter("@BirthDay", person.BirthDay));
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", person.PhoneNumber));
                        command.Parameters.Add(new SqlParameter("@CityID", person.CityId));
                        command.Parameters.Add(new SqlParameter("@AccountID", person.AccountId));                       

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
        public void Update(Person person, string newFirstName, string newLastName, string newStreet, string newNumber, DateTime newBirthDay,
                            string newPhoneNumber, Guid newCityId, Guid newAccountId)
        {
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Persons_Update";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PersonID", person.Id));
                        command.Parameters.Add(new SqlParameter("@FirstName", newFirstName));
                        command.Parameters.Add(new SqlParameter("@LastName", newLastName));
                        command.Parameters.Add(new SqlParameter("@Street", newStreet));
                        command.Parameters.Add(new SqlParameter("@Number", newNumber));
                        command.Parameters.Add(new SqlParameter("@BirthDay", newBirthDay));
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", newPhoneNumber));
                        command.Parameters.Add(new SqlParameter("@CityID", newCityId));
                        command.Parameters.Add(new SqlParameter("@AccountID", newAccountId));

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
        public void Delete(Guid personId)
        {

            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Persons_Delete";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@PersonID", personId));

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

        public Person GetById(Guid personId)
        {
            Person person = new Person();
            string connectionString = @"Server=ADRI-PC\SQLEXPRESS;Database=InteriorDesignShopDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "dbo.Persons_GetById";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@PersonID", personId));
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                person.Id = reader.GetGuid(reader.GetOrdinal("PersonID"));
                                person.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                person.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                person.Street = reader.GetString(reader.GetOrdinal("Street"));
                                person.Number = reader.GetString(reader.GetOrdinal("Number"));
                                person.BirthDay = reader.GetDateTime(reader.GetOrdinal("BirthDay"));
                                person.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                person.CityId = reader.GetGuid(reader.GetOrdinal("CityID"));
                                person.AccountId = reader.GetGuid(reader.GetOrdinal("AccountID"));

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

            return person;
        }
        #endregion
    }
}
