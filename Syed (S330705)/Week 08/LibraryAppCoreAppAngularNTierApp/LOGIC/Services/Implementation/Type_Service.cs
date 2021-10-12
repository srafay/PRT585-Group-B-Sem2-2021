using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = DAL.Entities.Type;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Type Data
    /// </summary>
    public class Type_Service : IType_Service
    {
        //Reference to our crud functions
        private IType_Operations _type_operations = new Type_Operations();

        /// <summary>
        /// Adds a new Type to the database
        /// </summary>
        public async Task<Generic_ResultSet<Type_ResultSet>> AddType(string name)
        {
            Generic_ResultSet<Type_ResultSet> result = new Generic_ResultSet<Type_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Type
                Type Type = new Type
                {
                    Name = name
                };

                //ADD Product TO DB
                Type = await _type_operations.Create(Type);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Type_ResultSet TypeAdded = new Type_ResultSet
                {
                    name = Type.Name,
                    id = Type.Id
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Type Type {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Type_Service: AddType() method executed successfully.";
                result.result_set = TypeAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Type Type supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Type_Service: AddType(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteType(long id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Product IN DB
                var TypeDeleted = await _type_operations.Delete(id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Type Type {0} was deleted successfully", id);
                result.internalMessage = "LOGIC.Services.Implementation.Type_Service: DeleteType() method executed successfully.";
                result.result_set = TypeDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Type Type supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Type_Service: DeleteType(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Obtains all the Products that exist in the database
        /// </summary>
        public async Task<Generic_ResultSet<List<Type_ResultSet>>> GetAllTypes()
        {
            Generic_ResultSet<List<Type_ResultSet>> result = new Generic_ResultSet<List<Type_ResultSet>>();
            try
            {
                //GET ALL Products
                List<Type> Types = await _type_operations.ReadAll();
                //MAP DB Product RESULTS
                result.result_set = new List<Type_ResultSet>();
                // Iterate for each product we got
                Types.ForEach(productItem =>
                {
                    result.result_set.Add(new Type_ResultSet
                    {
                        name = productItem.Name,
                        id = productItem.Id
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Types obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Type_Service: GetAllTypes() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Type from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Type_Service: GetAllTypes(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Type_ResultSet>> GetTypeById(long id)
        {
            Generic_ResultSet<Type_ResultSet> result = new Generic_ResultSet<Type_ResultSet>();
            try
            {
                //GET by ID Product 
                var Type = await _type_operations.Read(id);

                // Handle the case when the Product with this id is not found and Product is null.
                /* Code for Handling empty Product START */
                if (Type is not null)
                {
                    //MAP DB Product RESULTS
                    result.result_set = new Type_ResultSet
                    {
                        id = Type.Id,
                        name = Type.Name
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format("GetTypeById - Product obtained successfully");
                }
                /* Code for Handling empty Product END */
                else
                {
                    // Set the message for informing client that no product was found
                    result.userMessage = string.Format("GetTypeById - No Product found for id {0}", id);
                }
                result.internalMessage = "LOGIC.Services.Implementation.Type_Service: GetTypeById() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Type from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Type_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Update a Type.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name-"></param>
        /// /// <param name="description-"></param>
        public async Task<Generic_ResultSet<Type_ResultSet>> UpdateType(long id, string name)
        {
            Generic_ResultSet<Type_ResultSet> result = new Generic_ResultSet<Type_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Type
                Type Type = new Type
                {
                    Id = id,
                    Name = name
                };

                //UPDATE Type IN DB
                Type = await _type_operations.Update(Type, id);

                //MANUAL MAPPING OF RETURNED Product VALUES TO OUR Product_ResultSet
                Type_ResultSet TypeUpdated = new Type_ResultSet
                {
                    id = Type.Id,
                    name = Type.Name
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Type {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Type_Service: UpdateType() method executed successfully.";
                result.result_set = TypeUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Type supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Type_Service: UpdateType(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /*public async Task<List<Type_ResultSet>> GetAllTypes()
        {
            List<Type_ResultSet> result = new List<Type_ResultSet>();
            List<Type_ResultSet> unique_result = new();
            try
            {
                //GET ALL Products
                List<Type> Products = await _Type_operations.ReadAll();
                //MAP DB Product RESULTS
                // Iterate for each product we got
                Products.ForEach(productItem =>
                {
                    result.Add(new Type_ResultSet
                    {
                        id = 0,
                        name = productItem.Product_Type
                    });
                });

                *//* Return Distinct Types *//*
                unique_result = result.Distinct().ToList();

                //SET SUCCESSFUL RESULT VALUES
                *//*result.userMessage = string.Format("All Product Types obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetAllTypes() method executed successfully.";
                result.success = true;
                result.xyc = "adsadsa";*//*
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                *//*result.exception = exception;
                result.userMessage = "We failed fetch all the required Product Types from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Product_Service: GetAllTypes(): {0}", exception.Message); ;*//*
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return unique_result;
        }*/
    }
}
