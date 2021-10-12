using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IProduct_Operations
    {
        Task<Product> Create(Product objectToAdd);
        Task<Product> Read(Int64 entityId);
        Task<List<Product>> ReadAll();
        Task<Product> Update(Product objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
