using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using LOGIC.Services.Models.CustomerContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update CustomerContact Data
    /// </summary>
    public class CustomerContact_Service : ICustomerContact_Service
    {
        //Reference to our crud functions
        private ICustomerContact_Operations _customercontact_operations = new CustomerContact_Operations();

        /// <summary>
        /// Adds a new customercontact to the database
        /// </summary>
        public async Task<Generic_ResultSet<CustomerContact_ResultSet>> AddCustomerContact(string customer_name, string customer_number, string customer_email, string customer_address)
        {
            Generic_ResultSet<CustomerContact_ResultSet> result = new Generic_ResultSet<CustomerContact_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF CustomerContact
                CustomerContact CustomerContact = new CustomerContact
                {
                    Customer_Name = customer_name,
                    Customer_Number = customer_number,
                    Customer_Email = customer_email,
                    Customer_Address = customer_address
                };

                //ADD CustomerContact TO DB
                CustomerContact = await _customercontact_operations.Create(CustomerContact);

                //MANUAL MAPPING OF RETURNED CustomerContact VALUES TO OUR CustomerContact_ResultSet
                CustomerContact_ResultSet customercontactAdded = new CustomerContact_ResultSet
                {
                    customer_name = CustomerContact.Customer_Name,
                    customercontact_id = CustomerContact.CustomerContactID,
                    customer_number = CustomerContact.Customer_Number,
                    customer_email = CustomerContact.Customer_Email,
                    customer_address = CustomerContact.Customer_Address
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied CustomerContact customercontact {0} was added successfully", customer_name);
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: AddCustomerContact() method executed successfully.";
                result.result_set = customercontactAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the CustomerContact customercontact supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: AddCustomerContact(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteCustomerContact(long customercontact_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete CustomerContact IN DB
                var customercontactDeleted = await _customercontact_operations.Delete(customercontact_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied CustomerContact customercontact {0} was deleted successfully", customercontact_id);
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: DeleteCustomerContact() method executed successfully.";
                result.result_set = customercontactDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the CustomerContact customercontact supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: DeleteCustomerContact(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Obtains all the CustomerContacts that exist in the database
        /// </summary>
        public async Task<Generic_ResultSet<List<CustomerContact_ResultSet>>> GetAllCustomerContacts()
        {
            Generic_ResultSet<List<CustomerContact_ResultSet>> result = new Generic_ResultSet<List<CustomerContact_ResultSet>>();
            try
            {
                //GET ALL CustomerContacts
                List<CustomerContact> CustomerContacts = await _customercontact_operations.ReadAll();
                //MAP DB CustomerContact RESULTS
                result.result_set = new List<CustomerContact_ResultSet>();
                // Iterate for each customercontact we got
                CustomerContacts.ForEach(CustomerContact =>
                {
                    result.result_set.Add(new CustomerContact_ResultSet
                    {
                        customercontact_id = CustomerContact.CustomerContactID,
                        customer_name = CustomerContact.Customer_Name,
                        customer_number = CustomerContact.Customer_Number,
                        customer_email = CustomerContact.Customer_Email,
                        customer_address = CustomerContact.Customer_Address

                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All CustomerContacts obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: GetAllCustomerContacts() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required CustomerContacts from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: GetAllCustomerContacts(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<CustomerContact_ResultSet>> GetCustomerContactById(long customercontact_id)
        {
            Generic_ResultSet<CustomerContact_ResultSet> result = new Generic_ResultSet<CustomerContact_ResultSet>();
            try
            {
                //GET by ID CustomerContact 
                var CustomerContact = await _customercontact_operations.Read(customercontact_id);

                // Handle the case when the CustomerContact with this id is not found and CustomerContact is null.
                /* Code for Handling empty CustomerContact START */
                if (CustomerContact is not null)
                {
                    //MAP DB CustomerContact RESULTS
                    result.result_set = new CustomerContact_ResultSet
                    {
                        customercontact_id = CustomerContact.CustomerContactID,
                        customer_name = CustomerContact.Customer_Name,
                        customer_number = CustomerContact.Customer_Number,
                        customer_email = CustomerContact.Customer_Email,
                        customer_address = CustomerContact.Customer_Address
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format("GetCustomerContactById - CustomerContact obtained successfully");
                }
                /* Code for Handling empty CustomerContact END */
                else
                {
                    // Set the message for informing client that no customercontact was found
                    result.userMessage = string.Format("GetCustomerContactById - No CustomerContact found for id {0}", customercontact_id);
                }
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: GetCustomerContactById() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required CustomerContact from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Update a CustomerContact.
        /// </summary>
        /// <param name="customercontact_id"></param>
        /// <param name="customer_name"></param>
 
        public async Task<Generic_ResultSet<CustomerContact_ResultSet>> UpdateCustomerContact(long customercontact_id, string customer_name, string customer_number, string customer_email, string customer_address)
        {
            Generic_ResultSet<CustomerContact_ResultSet> result = new Generic_ResultSet<CustomerContact_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF CustomerContact
                CustomerContact CustomerContact = new CustomerContact
                {
                    CustomerContactID = customercontact_id,
                    Customer_Name = customer_name,
                    Customer_Number = customer_number,
                    Customer_Email = customer_email,
                    Customer_Address = customer_address
                };

                //UPDATE CustomerContact IN DB
                CustomerContact = await _customercontact_operations.Update(CustomerContact, customercontact_id);

                //MANUAL MAPPING OF RETURNED CustomerContact VALUES TO OUR CustomerContact_ResultSet
                CustomerContact_ResultSet customercontactUpdated = new CustomerContact_ResultSet
                {
                    customercontact_id = CustomerContact.CustomerContactID,
                    customer_name = CustomerContact.Customer_Name,
                    customer_number = CustomerContact.Customer_Number,
                    customer_email = CustomerContact.Customer_Email,
                    customer_address = CustomerContact.Customer_Address
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Prduct {0} was updated successfully", customer_name);
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: UpdateCustomerContact() method executed successfully.";
                result.result_set = customercontactUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the CustomerContact supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: UpdateCustomerContact(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<List<Customer_ResultSet>> GetAllCustomers()
        {
            List<Customer_ResultSet> result = new List<Customer_ResultSet>();
            List<Customer_ResultSet> unique_result = new();
            try
            {
                //GET ALL CustomerContacts
                List<CustomerContact> CustomerContacts = await _customercontact_operations.ReadAll();
                //MAP DB CustomerContact RESULTS
                // Iterate for each customercontact we got
                CustomerContacts.ForEach(CustomerContact =>
                {
                    result.Add(new Customer_ResultSet
                    {
                        Customer_id = 0,
                        Customer_name = CustomerContact.Customer_Name
                    });
                });

                /* Return Distinct Brands */
                unique_result = result.Distinct().ToList();

                //SET SUCCESSFUL RESULT VALUES
                /*result.userMessage = string.Format("All CustomerContact Brands obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.CustomerContact_Service: GetAllBrands() method executed successfully.";
                result.success = true;
                result.xyc = "adsadsa";*/
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                /*result.exception = exception;
                result.userMessage = "We failed fetch all the required CustomerContact Brands from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.CustomerContact_Service: GetAllBrands(): {0}", exception.Message); ;*/
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return unique_result;
        }
    }
}
