using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICustomer_Operations
    {
        Task<Customer> Create(Customer objectToAdd);
        Task<Customer> Read(Int64 entityId);
        Task<List<Customer>> ReadAll();
        Task<Customer> Update(Customer objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
