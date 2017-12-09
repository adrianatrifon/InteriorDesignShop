﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class CurrencyRepository:BaseRepository<Currency>
    {
        #region Methods
        public List<Currency> ReadAll()
        {
            return ReadAll("dbo.Currencies_ReadAll");

        }

        public void Insert(Currency currency)
        {

            SqlParameter[] parameters = { new SqlParameter("@CurrencyID", currency.Id), new SqlParameter("@CurrencyName", currency.Name) };
            Operation("dbo.Currencies_Create", parameters);

        }
        public void Update(Currency currency)
        {
            SqlParameter[] parameters = { new SqlParameter("@CurrencyID", currency.Id), new SqlParameter("@CurrencyName", currency.Name) };
            Operation("dbo.Currencies_Update", parameters);

        }

        public void Delete(Guid currencyId)
        {
            SqlParameter[] parameters = { new SqlParameter("@CurrencyID", currencyId) };
            Operation("dbo.Currencies_Delete", parameters);

        }

        public Currency GetById(Guid currencyId)
        {
            Currency currency = new Currency();
            SqlParameter[] parameters = { new SqlParameter("@CurrencyID", currencyId) };
            List<Currency> currencies = new List<Currency>();
            currencies = ReadAll("dbo.Currencies_GetById", parameters);

            return currencies.ElementAt(0);
        }

        public override Currency GetModelFromReader(SqlDataReader reader)
        {
            Currency currency = new Currency();
            currency.Id = reader.GetGuid(reader.GetOrdinal("CurrencyID"));
            currency.Name = reader.GetString(reader.GetOrdinal("Currency"));
            return currency;
        }
        #endregion        
    }
}
