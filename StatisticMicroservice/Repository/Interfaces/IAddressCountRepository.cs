using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticMicroservice.Model;

namespace StatisticMicroservice.Repository.Interfaces
{
    public interface IAddressCountRepository
    {
        Task<IEnumerable<AddressCount>> GetAddressCounts();

        Task<AddressCount> GetAddressCountById(string id);

        Task InsertAddressCount(AddressCount addressCount);

        Task<bool> UpdateAddressCount(AddressCount addressCount);

        Task<bool> RemoveAddressCount(string id);

    }
}