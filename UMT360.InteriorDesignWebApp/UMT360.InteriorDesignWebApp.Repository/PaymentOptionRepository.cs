using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using UMT360.InteriorDesignWebApp.Models;
using UMT360.InteriorDesignWebApp.Repository.Core;

namespace UMT360.InteriorDesignWebApp.Repository
{
    public class PaymentOptionRepository:BaseRepository<PaymentOption>
    {
        #region Methods
        public List<PaymentOption> ReadAll()
        {
            return ReadAll("dbo.PaymentOptions_ReadAll");

        }

        public void Insert(PaymentOption paymentOption)
        {

            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOption.Id), new SqlParameter("@PaymentOptionName", paymentOption.Name) };
            Operation("dbo.PaymentOptions_Create", parameters);

        }
        public void Update(PaymentOption paymentOption)
        {
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOption.Id), new SqlParameter("@PaymentOptionName", paymentOption.Name) };
            Operation("dbo.PaymentOptions_Update", parameters);

        }

        public void Delete(Guid paymentOptionId)
        {
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOptionId) };
            Operation("dbo.PaymentOptions_Delete", parameters);

        }

        public PaymentOption GetById(Guid paymentOptionId)
        {
            PaymentOption paymentOption = new PaymentOption();
            SqlParameter[] parameters = { new SqlParameter("@PaymentOptionID", paymentOptionId) };
            List<PaymentOption> paymentOptions = new List<PaymentOption>();
            paymentOptions = ReadAll("dbo.PaymentOptions_GetById", parameters);

            return paymentOptions.ElementAt(0);
        }

        public override PaymentOption GetModelFromReader(SqlDataReader reader)
        {
            PaymentOption paymentOption = new PaymentOption();
            paymentOption.Id = reader.GetGuid(reader.GetOrdinal("PaymentOptionID"));
            paymentOption.Name = reader.GetString(reader.GetOrdinal("Name"));
            return paymentOption;
        }
        #endregion
        
    }
}
