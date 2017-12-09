using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class AccountRepository:BaseRepository<Account>
    {
        #region Methods
        public List<Account> ReadAll()
        {
            return ReadAll("dbo.Accounts_ReadAll");

        }

        public void Insert(Account account)
        {

            SqlParameter[] parameters = { new SqlParameter("@AccountID", account.Id),
                                          new SqlParameter("@EmailAddress", account.EmailAddress),
                                          new SqlParameter("@Password", account.Password),
                                          new SqlParameter("@RoleID", account.RoleId),
                                          new SqlParameter("@PhotoID", account.PhotoId)};

            Operation("dbo.Accounts_Create", parameters);

        }
        public void Update(Account account)
        {
            SqlParameter[] parameters = { new SqlParameter("@AccountID", account.Id),
                                          new SqlParameter("@EmailAddress", account.EmailAddress),
                                          new SqlParameter("@Password", account.Password),
                                          new SqlParameter("@RoleID", account.RoleId),
                                          new SqlParameter("@PhotoID", account.PhotoId)};

            Operation("dbo.Accounts_Update", parameters);

        }

        public void Delete(Guid accountId)
        {
            SqlParameter[] parameters = { new SqlParameter("@AccountID", accountId) };
            Operation("dbo.Accounts_Delete", parameters);

        }

        public Account GetById(Guid accountId)
        {
            Account account = new Account();
            SqlParameter[] parameters = { new SqlParameter("@AccountID", accountId) };
            List<Account> accounts = new List<Account>();
            accounts = ReadAll("dbo.Accounts_GetById", parameters);

            return accounts.ElementAt(0);
        }

        public override Account GetModelFromReader(SqlDataReader reader)
        {
            Account account = new Account();
            account.Id = reader.GetGuid(reader.GetOrdinal("AccountID"));
            account.EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
            account.Password = reader.GetString(reader.GetOrdinal("Password"));
            account.RoleId = reader.GetGuid(reader.GetOrdinal("RoleID"));
            account.PhotoId = reader.GetGuid(reader.GetOrdinal("PhotoID"));
            return account;
        }
        #endregion
        
    }
}
