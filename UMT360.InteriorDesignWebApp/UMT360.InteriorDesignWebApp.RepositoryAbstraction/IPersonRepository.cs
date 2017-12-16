using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IPersonRepository
    {
        List<Person> ReadAll();
        void Insert(Person person);
        void Update(Person person);
        void Delete(Guid personId);
        Person GetById(Guid personId);
    }
}
