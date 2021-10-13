using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using LOGIC.Services.Models.CustomerContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICustomerContact_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<CustomerContact_ResultSet>>> GetAllCustomerContacts();
        Task<Generic_ResultSet<CustomerContact_ResultSet>> GetCustomerContactById(Int64 customercontact_id);
        /* Get all brands */
        Task<List<Customer_ResultSet>> GetAllCustomers();
        /* Get all types */


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<CustomerContact_ResultSet>> AddCustomerContact(string customer_name, string customer_number, string customer_email, string customer_address);
        Task<Generic_ResultSet<CustomerContact_ResultSet>> UpdateCustomerContact(Int64 customercontact_id, string customer_name, string customer_number, string customer_email, string customer_address);
        Task<Generic_ResultSet<bool>> DeleteCustomerContact(Int64 customercontact_id);
    }
}
