using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICustomerContact_Operations
    {
        Task<CustomerContact> Create(CustomerContact objectToAdd);
        Task<CustomerContact> Read(Int64 entityId);
        Task<List<CustomerContact>> ReadAll();
        Task<CustomerContact> Update(CustomerContact objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
