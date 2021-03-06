﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class AccountRepository:BaseRepository<Account>,IAccountRepository
    {
        #region Methods
        public List<Account> ReadAll()
        {
            return ReadAll("dbo.Accounts_ReadAll");
        }

        public void Insert(Account account)
        {
            SqlParameter[] parameters = GetParametersFromModel(account);
            ExecuteNonQuery("dbo.Accounts_Create", parameters);
        }

        public void Update(Account account)
        {
            SqlParameter[] parameters = GetParametersFromModel(account);
            ExecuteNonQuery("dbo.Accounts_Update", parameters);
        }

        public void Delete(Guid accountId)
        {
            SqlParameter[] parameters = { new SqlParameter("@AccountID", accountId) };
            ExecuteNonQuery("dbo.Accounts_Delete", parameters);
        }

        public Account GetById(Guid accountId)
        {
            SqlParameter[] parameters = { new SqlParameter("@AccountID", accountId) };
            List<Account> accounts = new List<Account>();
            accounts = ReadAll("dbo.Accounts_GetById", parameters);

            return accounts.Single();
        }

        protected override Account GetModelFromReader(SqlDataReader reader)
        {
            Account account = new Account();
            account.Id = reader.GetGuid(reader.GetOrdinal("AccountID"));
            account.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
            account.Password = reader.GetString(reader.GetOrdinal("Password"));
            account.RoleId = reader.GetGuid(reader.GetOrdinal("RoleID"));
            account.PhotoId = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            return account;
        }
        internal SqlParameter[] GetParametersFromModel(Account account)
        {
            SqlParameter[] parameters = { new SqlParameter("@AccountID", account.Id),
                                          new SqlParameter("@EmailAddress", account.EmailAddress),
                                          new SqlParameter("@Password", account.Password),
                                          new SqlParameter("@RoleID", account.RoleId),
                                          new SqlParameter("@PhotoID", account.PhotoId)};
            return parameters;
        }
        #endregion

    }
}
