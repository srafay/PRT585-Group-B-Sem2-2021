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
    /// This service allows us to Add, Fetch and Update Brand Data
    /// </summary>
    public class Brand_Service : IBrand_Service
    {
        //Reference to our crud functions
        private IBrand_Operations _brand_operations = new Brand_Operations();

        /// <summary>
        /// Adds a new brand to the database
        /// </summary>
        public async Task<Generic_ResultSet<Brand_ResultSet>> AddBrand(string name)
        {
            Generic_ResultSet<Brand_ResultSet> result = new Generic_ResultSet<Brand_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Product
                Brand Brand = new Brand
                {
                    Name = name
                };

                //ADD Product TO DB
                Brand = await _brand_operations.Create(Brand);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Brand_ResultSet brandAdded = new Brand_ResultSet
                {
                    name = Brand.Name,
                    id = Brand.Id
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Brand brand {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Brand_Service: AddBrand() method executed successfully.";
                result.result_set = brandAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Brand brand supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Brand_Service: AddBrand(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteBrand(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Product IN DB
                var brandDeleted = await _brand_operations.Delete(id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Brand brand {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Brand_Service: DeleteBrand() method executed successfully.";
                result.result_set = brandDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Brand brand supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Brand_Service: DeleteBrand(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Obtains all the Products that exist in the database
        /// </summary>
        public async Task<Generic_ResultSet<List<Brand_ResultSet>>> GetAllBrands()
        {
            Generic_ResultSet<List<Brand_ResultSet>> result = new Generic_ResultSet<List<Brand_ResultSet>>();
            try
            {
                //GET ALL Products
                List<Brand> Brands = await _brand_operations.ReadAll();
                //MAP DB Product RESULTS
                result.result_set = new List<Brand_ResultSet>();
                // Iterate for each product we got
                Brands.ForEach(productItem =>
                {
                    result.result_set.Add(new Brand_ResultSet
                    {
                        name = productItem.Name,
                        id = productItem.Id
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Brands obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Brand_Service: GetAllBrands() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Brand from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Brand_Service: GetAllBrands(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Brand_ResultSet>> GetBrandById(long id)
        {
            Generic_ResultSet<Brand_ResultSet> result = new Generic_ResultSet<Brand_ResultSet>();
            try
            {
                //GET by ID Product 
                var Brand = await _brand_operations.Read(id);

                // Handle the case when the Product with this id is not found and Product is null.
                /* Code for Handling empty Product START */
                if (Brand is not null)
                {
                    //MAP DB Product RESULTS
                    result.result_set = new Brand_ResultSet
                    {
                        id = Brand.Id,
                        name = Brand.Name
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format("GetBrandById - Product obtained successfully");
                }
                /* Code for Handling empty Product END */
                else
                {
                    // Set the message for informing client that no product was found
                    result.userMessage = string.Format("GetBrandById - No Product found for id {0}", id);
                }
                result.internalMessage = "LOGIC.Services.Implementation.Brand_Service: GetBrandById() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Brand from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Brand_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Update a Brand.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name-"></param>
        /// /// <param name="description-"></param>
        public async Task<Generic_ResultSet<Brand_ResultSet>> UpdateBrand(long id, string name)
        {
            Generic_ResultSet<Brand_ResultSet> result = new Generic_ResultSet<Brand_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Brand
                Brand Brand = new Brand
                {
                    Id = id,
                    Name = name
                };

                //UPDATE Brand IN DB
                Brand = await _brand_operations.Update(Brand, id);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Brand_ResultSet brandUpdated = new Brand_ResultSet
                {
                    id = Brand.Id,
                    name = Brand.Name
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Brand {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Brand_Service: UpdateBrand() method executed successfully.";
                result.result_set = brandUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Brand supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Brand_Service: UpdateBrand(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /*public async Task<List<Brand_ResultSet>> GetAllBrands()
        {
            List<Brand_ResultSet> result = new List<Brand_ResultSet>();
            List<Brand_ResultSet> unique_result = new();
            try
            {
                //GET ALL Products
                List<Brand> Products = await _brand_operations.ReadAll();
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

                *//* Return Distinct Brands *//*
                unique_result = result.Distinct().ToList();

                //SET SUCCESSFUL RESULT VALUES
                *//*result.userMessage = string.Format("All Product Brands obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllBrands() method executed successfully.";
                result.success = true;
                result.xyc = "adsadsa";*//*
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                *//*result.exception = exception;
                result.userMessage = "We failed fetch all the required Product Brands from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllBrands(): {0}", exception.Message); ;*//*
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return unique_result;
        }*/
    }
}
