using System;
using System.Collections.Generic;
using UMT360.InteriorDesignWebApp.Business.Core;
using UMT360.InteriorDesignWebApp.Models;

namespace UMT360.InteriorDesignWebApp.Business
{
    public class AccountBusiness
    {
        #region Methods
        public List<Account> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.AccountRepository.ReadAll();
        }

        public void Insert(Account account)
        {
            BusinessContext.Current.RepositoryContext.AccountRepository.Insert(account);
        }

        public void Update(Account account)
        {
            BusinessContext.Current.RepositoryContext.AccountRepository.Update(account);
        }

        public void Delete(Guid accountId)
        {
            BusinessContext.Current.RepositoryContext.AccountRepository.Delete(accountId);
        }

        public Account GetById(Guid accountId)
        {
            return BusinessContext.Current.RepositoryContext.AccountRepository.GetById(accountId);
        }
        #endregion
    }
}
