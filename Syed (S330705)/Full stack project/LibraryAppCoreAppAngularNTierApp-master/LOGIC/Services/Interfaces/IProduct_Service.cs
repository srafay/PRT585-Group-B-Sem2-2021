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
    public interface IProduct_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Product_ResultSet>>> GetAllProducts();
        Task<Generic_ResultSet<Product_ResultSet>> GetProductById(Int64 id);
        /* Get all brands */
        Task<List<Brand_ResultSet>> GetAllBrands();
        /* Get all types */
        Task<List<Type_ResultSet>> GetAllTypes();


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Product_ResultSet>> AddProduct(string name, string description, Int64 price, string type, string brand);
        Task<Generic_ResultSet<Product_ResultSet>> UpdateProduct(Int64 id, string name, string description, Int64 product_price, string product_type, string product_brand);
        Task<Generic_ResultSet<bool>> DeleteProduct(Int64 id);
    }
}
