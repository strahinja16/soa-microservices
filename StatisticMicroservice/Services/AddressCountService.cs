using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;
using StatisticMicroservice.Repository.Interfaces;
using StatisticMicroservice.Services.Interfaces;

namespace StatisticMicroservice.Services
{
    public class AddressCountService : IAddressCountService
    {
        private IAddressCountRepository addressCountRepository;

        public AddressCountService(IAddressCountRepository addressCountRepository)
        {
            this.addressCountRepository = addressCountRepository;
        }

        public void findSMSAddressCount(string address, string date)
        {
            // 1. get sms-es with http client
            // 2. find all the s records after <date> and filter those with <address> e.g. +989
            // 3. count the filtered sms-es
            // 4. insert AddressCount to Mongo -> { <address>, count(3), <date> }
        }
    }
}

