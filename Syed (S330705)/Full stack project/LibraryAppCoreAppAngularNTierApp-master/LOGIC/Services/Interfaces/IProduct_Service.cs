using LOGIC.Services.Models;
using LOGIC.Services.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IProduct_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Product_ResultSet>>> GetAllProducts();
        Task<Generic_ResultSet<Product_ResultSet>> GetProductById(Int64 id);


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Product_ResultSet>> AddProduct(string name, string description);
        Task<Generic_ResultSet<Product_ResultSet>> UpdateProduct(Int64 id, string name, string description);
        Task<Generic_ResultSet<bool>> DeleteProduct(Int64 id);
    }
}
