using LOGIC.Services.Models;
using LOGIC.Services.Models.Brand;
using LOGIC.Services.Models.Product;
using LOGIC.Services.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IType_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Type_ResultSet>>> GetAllTypes();
        Task<Generic_ResultSet<Type_ResultSet>> GetTypeById(Int64 id);
        /* Get all brands */
        /*Task<List<Type_ResultSet>> GetAllTypes();*/


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Type_ResultSet>> AddType(string name);
        Task<Generic_ResultSet<Type_ResultSet>> UpdateType(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteType(Int64 id);
    }
}
