using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;
using UMT360.InteriorDesignWebApp.RepositoryAbstraction;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PaymentOptionRepository:BaseRepository<PaymentOption>,IPaymentOptionRepository
    {
        #region Methods
        public List<PaymentOption> ReadAll()
        {
            return ReadAll("dbo.PaymentOptions_ReadAll");
        }

        public void Insert(PaymentOption paymentOption)
        {
            SqlParameter[] parameters = GetParametersFromModel(paymentOption);
            ExecuteNonQuery("dbo.PaymentOptions_Create", parameters);
        }
        public void Update(PaymentOption paymentOption)
        {
            SqlParameter[] parameters = GetParametersFromModel(paymentOption);
            ExecuteNonQuery("dbo.PaymentOptions_Update", parameters);
        }

        public void Delete(Guid paymentOptionId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOptionId) };
            ExecuteNonQuery("dbo.PaymentOptions_Delete", parameters);
        }

        public PaymentOption GetById(Guid paymentOptionId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOptionId) };
            List<PaymentOption> paymentOptions = new List<PaymentOption>();
            paymentOptions = ReadAll("dbo.PaymentOptions_GetById", parameters);
            return paymentOptions.Single();
        }

        protected override PaymentOption GetModelFromReader(SqlDataReader reader)
        {
            PaymentOption paymentOption = new PaymentOption();
            paymentOption.Id = reader.GetGuid(reader.GetOrdinal("PaymentOptionID"));
            paymentOption.Name = reader.GetString(reader.GetOrdinal("Name"));
            return paymentOption;
        }
        internal SqlParameter[] GetParametersFromModel(PaymentOption paymentOption)
        {
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOption.Id), new SqlParameter("@PaymentOptionName", paymentOption.Name) };
            return parameters;
        }
        #endregion        
    }
}
