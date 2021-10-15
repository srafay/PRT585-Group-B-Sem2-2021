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
    public interface IBrand_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Brand_ResultSet>>> GetAllBrands();
        Task<Generic_ResultSet<Brand_ResultSet>> GetBrandById(Int64 id);
        /* Get all brands */
        /*Task<List<Brand_ResultSet>> GetAllBrands();*/


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Brand_ResultSet>> AddBrand(string name);
        Task<Generic_ResultSet<Brand_ResultSet>> UpdateBrand(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteBrand(Int64 id);
    }
}
