using System;
using System.Collections.Generic;
using ApiMicroservice.Model;

namespace ApiMicroservice.Repository.Interfaces
{
    public interface ICallRepository
    {
        IEnumerable<Call> GetCalls();
        Call GetCallById(int CallId);
        void InsertCall(Call call);
        void DeleteCall(int CallId);
        void UpdateCall(Call call);
        void Save();
    }
}