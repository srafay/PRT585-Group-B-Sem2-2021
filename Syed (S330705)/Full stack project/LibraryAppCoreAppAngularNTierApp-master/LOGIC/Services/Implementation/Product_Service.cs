using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Brand;
using LOGIC.Services.Models.Product;
using LOGIC.Services.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Product Data
    /// </summary>
    public class Product_Service : IProduct_Service
    {
        //Reference to our crud functions
        private IProduct_Operations _product_operations = new Product_Operations();

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        public async Task<Generic_ResultSet<Product_ResultSet>> AddProduct(string name, string description, Int64 price, string type, string brand)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Product
                Product Product = new Product
                {
                    Product_Name = name,
                    Product_Description = description,
                    Product_Price = price,
                    Product_Brand = brand,
                    Product_Type = type
                };

                //ADD Product TO DB
                Product = await _product_operations.Create(Product);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Product_ResultSet productAdded = new Product_ResultSet
                {
                    product_name = Product.Product_Name,
                    id = Product.ProductID,
                    product_description = Product.Product_Description,
                    product_price = Product.Product_Price,
                    product_type = Product.Product_Type,
                    product_brand = Product.Product_Brand
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Product product {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: AddProduct() method executed successfully.";
                result.result_set = productAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Product product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: AddProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteProduct(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Product IN DB
                var productDeleted = await _product_operations.Delete(id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Product product {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: DeleteProduct() method executed successfully.";
                result.result_set = productDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Product product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: DeleteProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Obtains all the Products that exist in the database
        /// </summary>
        public async Task<Generic_ResultSet<List<Product_ResultSet>>> GetAllProducts()
        {
            Generic_ResultSet<List<Product_ResultSet>> result = new Generic_ResultSet<List<Product_ResultSet>>();
            try
            {
                //GET ALL Products
                List<Product> Products = await _product_operations.ReadAll();
                //MAP DB Product RESULTS
                result.result_set = new List<Product_ResultSet>();
                // Iterate for each product we got
                Products.ForEach(productItem =>
                {
                    result.result_set.Add(new Product_ResultSet
                    {
                        id = productItem.ProductID,
                        product_name = productItem.Product_Name,
                        product_description = productItem.Product_Description,
                        product_brand = productItem.Product_Brand,
                        product_price = productItem.Product_Price,
                        product_type = productItem.Product_Type
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Products obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllProducts() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Products from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllProducts(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Product_ResultSet>> GetProductById(long id)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //GET by ID Product 
                var Product = await _product_operations.Read(id);

                // Handle the case when the Product with this id is not found and Product is null.
                /* Code for Handling empty Product START */
                if (Product is not null)
                {
                    //MAP DB Product RESULTS
                    result.result_set = new Product_ResultSet
                    {
                        id = Product.ProductID,
                        product_name = Product.Product_Name,
                        product_description = Product.Product_Description,
                        product_type = Product.Product_Type,
                        product_price = Product.Product_Price,
                        product_brand = Product.Product_Brand
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format("GetProductById - Product obtained successfully");
                }
                /* Code for Handling empty Product END */
                else
                {
                    // Set the message for informing client that no product was found
                    result.userMessage = string.Format("GetProductById - No Product found for id {0}", id);
                }
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetProductById() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Product from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Update a Product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name-"></param>
        /// /// <param name="description-"></param>
        public async Task<Generic_ResultSet<Product_ResultSet>> UpdateProduct(long id, string name, string description, Int64 price, string type, string brand)
        {
            Generic_ResultSet<Product_ResultSet> result = new Generic_ResultSet<Product_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Product
                Product Product = new Product
                {
                    ProductID = id,
                    Product_Name = name,
                    Product_Description = description,
                    Product_Price = price,
                    Product_Brand = brand,
                    Product_Type = type
                };

                //UPDATE Product IN DB
                Product = await _product_operations.Update(Product, id);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Product_ResultSet productUpdated = new Product_ResultSet
                {
                    id = Product.ProductID,
                    product_name = Product.Product_Name,
                    product_description = Product.Product_Description,
                    product_brand = Product.Product_Brand,
                    product_price = Product.Product_Price,
                    product_type = Product.Product_Type
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Prduct {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: UpdateProduct() method executed successfully.";
                result.result_set = productUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Product supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: UpdateProduct(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<List<Brand_ResultSet>> GetAllBrands()
        {
            List<Brand_ResultSet> result = new List<Brand_ResultSet>();
            List<Brand_ResultSet> unique_result = new();
            try
            {
                //GET ALL Products
                List<Product> Products = await _product_operations.ReadAll();
                //MAP DB Product RESULTS
                // Iterate for each product we got
                Products.ForEach(productItem =>
                {
                    result.Add(new Brand_ResultSet
                    {
                        id = 0,
                        name = productItem.Product_Brand
                    });
                });

                /* Return Distinct Brands */
                unique_result = result.Distinct().ToList();

                //SET SUCCESSFUL RESULT VALUES
                /*result.userMessage = string.Format("All Product Brands obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllBrands() method executed successfully.";
                result.success = true;
                result.xyc = "adsadsa";*/
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                /*result.exception = exception;
                result.userMessage = "We failed fetch all the required Product Brands from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllBrands(): {0}", exception.Message); ;*/
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return unique_result;
        }

        public async Task<List<Type_ResultSet>> GetAllTypes()
        {
            List<Type_ResultSet> result = new List<Type_ResultSet>();
            try
            {
                //GET ALL Products
                List<Product> Products = await _product_operations.ReadAll();
                //MAP DB Product RESULTS
                result = new List<Type_ResultSet>();
                // Iterate for each product we got
                Products.ForEach(productItem =>
                {
                    result.Add(new Type_ResultSet
                    {
                        id = 0,
                        name = productItem.Product_Type
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                /*result.userMessage = string.Format("All Product Types obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllTypes() method executed successfully.";
                result.success = true;*/
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                /*result.exception = exception;
                result.userMessage = "We failed fetch all the required Product Types from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllTypes(): {0}", exception.Message); ;*/
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
