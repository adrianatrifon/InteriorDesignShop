using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    class PersonRepository:BaseRepository<Person>
    {
        #region Methods
        public List<Person> ReadAll()
        {
            return ReadAll("dbo.Persons_ReadAll");

        }

        public void Insert(Person person)
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

            Operation("dbo.Persons_Create", parameters);

        }
        public void Update(Person person)
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

            Operation("dbo.Persons_Update", parameters);

        }

        public void Delete(Guid personId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PersonID", personId) };
            Operation("dbo.Persons_Delete", parameters);

        }

        public Person GetById(Guid personId)
        {
            Person person = new Person();
            SqlParameter[] parameters = { new SqlParameter("@PersonID", personId) };
            List<Person> persons = new List<Person>();
            persons = ReadAll("dbo.Persons_GetById", parameters);

            return persons.ElementAt(0);
        }

        public override Person GetModelFromReader(SqlDataReader reader)
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
        #endregion        
    }
}
