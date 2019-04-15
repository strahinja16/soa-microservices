using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface ICallRepository
    {
        IEnumerable<Call> GetCalls();
        Call GetCallById(Guid CallId);
        void InsertCall(Call call);
        void DeleteCall(Guid CallId);
        void UpdateCall(Call call);
        void Save();
    }
}