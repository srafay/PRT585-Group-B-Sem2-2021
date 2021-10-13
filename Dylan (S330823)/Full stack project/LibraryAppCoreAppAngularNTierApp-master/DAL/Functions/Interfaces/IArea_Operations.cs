using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IArea_Operations
    {
        Task<Area> Create(Area objectToAdd);
        Task<Area> Read(Int64 entityId);
        Task<List<Area>> ReadAll();
        Task<Area> Update(Area objectToUpdate, Int64 entityId);
        Task<bool> Delete(Int64 entityId);
    }
}
