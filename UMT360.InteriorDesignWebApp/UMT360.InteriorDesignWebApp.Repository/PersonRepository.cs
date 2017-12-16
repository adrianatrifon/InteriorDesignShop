using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PersonRepository:BaseRepository<Person>,IPersonRepository
    {
        #region Methods
        public List<Person> ReadAll()
        {
            return ReadAll("dbo.Persons_ReadAll");
        }

        public void Insert(Person person)
        {
            SqlParameter[] parameters = GetParametersFromModel(person);
            ExecuteNonQuery("dbo.Persons_Create", parameters);
        }
        public void Update(Person person)
        {
            SqlParameter[] parameters = GetParametersFromModel(person);
            ExecuteNonQuery("dbo.Persons_Update", parameters);
        }

        public void Delete(Guid personId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PersonID", personId) };
            ExecuteNonQuery("dbo.Persons_Delete", parameters);
        }

        public Person GetById(Guid personId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PersonID", personId) };
            List<Person> persons = new List<Person>();
            persons = ReadAll("dbo.Persons_GetById", parameters);
            return persons.Single();
        }

        protected override Person GetModelFromReader(SqlDataReader reader)
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
            return person;
        }
        internal SqlParameter[] GetParametersFromModel(Person person)
        {
            SqlParameter[] parameters = { new SqlParameter("@PersonID", person.Id),
                                          new SqlParameter("@FirstName", person.FirstName),
                                          new SqlParameter("@LastName", person.LastName),
                                          new SqlParameter("@Street", person.Street),
                                          new SqlParameter("@Number", person.Number),
                                          new SqlParameter("@BirthDay", person.BirthDay),
                                          new SqlParameter("@PhoneNumber", person.PhoneNumber),
                                          new SqlParameter("@CityID", person.CityId),
                                          new SqlParameter("@AccountID", person.AccountId)
                                         };
            return parameters;
        }
        #endregion        
    }
}
