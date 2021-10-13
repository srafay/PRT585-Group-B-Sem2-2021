using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = DAL.Entities.Type;

namespace DAL.Functions.Interfaces
{
    public interface IType_Operations
    {
        Task<Entities.Type> Create(Entities.Type objectToAdd);
        Task<Entities.Type> Read(Int64 entityId);
        Task<List<Entities.Type>> ReadAll();
        Task<Type> Update(Entities.Type objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
