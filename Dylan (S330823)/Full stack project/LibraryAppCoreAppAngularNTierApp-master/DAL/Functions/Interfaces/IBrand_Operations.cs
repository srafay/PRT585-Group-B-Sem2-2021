using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IBrand_Operations
    {
        Task<Brand> Create(Brand objectToAdd);
        Task<Brand> Read(Int64 entityId);
        Task<List<Brand>> ReadAll();
        Task<Brand> Update(Brand objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
