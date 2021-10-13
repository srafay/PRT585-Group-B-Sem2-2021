using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ILogger_Operations
    {
        Task<Logger> Create(Logger objectToAdd);
        Task<List<Logger>> ReadAll();
    }
}
