using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.RepositoryAbstraction
{
    public interface IAccountRepository
    {
        List<Account> ReadAll();    
        void Insert(Account account);     
        void Update(Account account);    
        void Delete(Guid accountId);
        Account GetById(Guid accountId);       
    }
}
