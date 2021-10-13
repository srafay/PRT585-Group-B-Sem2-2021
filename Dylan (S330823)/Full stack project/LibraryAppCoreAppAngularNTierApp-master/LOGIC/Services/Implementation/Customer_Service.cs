using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Customer Customer Data
    /// </summary>
    public class Customer_Service : ICustomer_Service
    {
        //Reference to our crud functions
        private ICustomer_Operations _Customer_operations = new Customer_Operations();

        /// <summary>
        /// Obtains all the Customer Customeres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Customer_ResultSet>>> GetAllCustomers()
        {
            Generic_ResultSet<List<Customer_ResultSet>> result = new Generic_ResultSet<List<Customer_ResultSet>>();
            try
            {
                //GET ALL Customer CustomerES
                List<Customer> Customers = await _Customer_operations.ReadAll();
                //MAP DB Customer RESULTS
                result.result_set = new List<Customer_ResultSet>();
                Customers.ForEach(Customer =>
                {
                    result.result_set.Add(new Customer_ResultSet
                    {
                        Customer_id = Customer.CustomerID,
                        Customer_name = Customer.Customer_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Customer Customeres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: GetAllCustomers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Customer Customeres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: GetAllCustomers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Customer_ResultSet>> GetCustomerById(long id)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //GET by ID Customer 
                var Customer = await _Customer_operations.Read(id);

                //MAP DB Customer RESULTS
                result.result_set = new Customer_ResultSet
                {
                    Customer_name = Customer.Customer_Name,
                    Customer_id = Customer.CustomerID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Customer  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Customer  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Customer to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Customer_ResultSet>> AddCustomer(string name)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Customer
                Customer Customer = new Customer
                {
                    Customer_Name = name
                };

                //ADD Customer TO DB
                Customer = await _Customer_operations.Create(Customer);

                //MANUAL MAPPING OF RETURNED Customer VALUES TO OUR Customer_ResultSet
                Customer_ResultSet CustomerAdded = new Customer_ResultSet
                {
                    Customer_name = Customer.Customer_Name,
                    Customer_id = Customer.CustomerID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer Customer {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: AddCustomer() method executed successfully.";
                result.result_set = CustomerAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Customer Customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: AddCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Update an Customer Customers name.
        /// </summary>
        /// <param name="Customer_id"></param>
        /// <param name="Customer_name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Customer_ResultSet>> UpdateCustomer(Int64 Customer_id, string Customer_name)
        {
            Generic_ResultSet<Customer_ResultSet> result = new Generic_ResultSet<Customer_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Customer
                Customer Customer = new Customer
                {
                    CustomerID = Customer_id,
                    Customer_Name = Customer_name,
                    //Customer_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Customer IN DB
                Customer = await _Customer_operations.Update(Customer, Customer_id);

                //MANUAL MAPPING OF RETURNED Customer VALUES TO OUR Customer_ResultSet
                Customer_ResultSet CustomerUpdated = new Customer_ResultSet
                {
                    Customer_name = Customer.Customer_Name,
                    Customer_id = Customer.CustomerID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer Customer {0} was updated successfully", Customer_name);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: UpdateCustomer() method executed successfully.";
                result.result_set = CustomerUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Customer Customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: UpdateCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteCustomer(long Customer_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Customer IN DB
                var CustomerDeleted = await _Customer_operations.Delete(Customer_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Customer Customer {0} was deleted successfully", Customer_id);
                result.internalMessage = "LOGIC.Services.Implementation.Customer_Service: DeleteCustomer() method executed successfully.";
                result.result_set = CustomerDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Customer Customer supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Customer_Service: DeleteCustomer(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
