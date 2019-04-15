using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface ISMSRepository
    {
        IEnumerable<SMS> GetSMSes();
        SMS GetSMSById(Guid SMSId);
        void InsertSMS(SMS sms);
        void DeleteSMS(Guid SMSId);
        void UpdateSMS(SMS sms);
        void Save();
    }
}