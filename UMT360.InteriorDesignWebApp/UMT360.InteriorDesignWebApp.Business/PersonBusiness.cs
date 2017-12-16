using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class PersonBusiness
    {
        #region Methods
        public List<Person> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PersonRepository.ReadAll();
        }

        public void Insert(Person person)
        {
            BusinessContext.Current.RepositoryContext.PersonRepository.Insert(person);
        }
        public void Update(Person person)
        {
            BusinessContext.Current.RepositoryContext.PersonRepository.Update(person);
        }

        public void Delete(Guid personId)
        {
            BusinessContext.Current.RepositoryContext.PersonRepository.Delete(personId);
        }

        public Person GetById(Guid personId)
        {
            return BusinessContext.Current.RepositoryContext.PersonRepository.GetById(personId);
        }
        #endregion        
    }
}
