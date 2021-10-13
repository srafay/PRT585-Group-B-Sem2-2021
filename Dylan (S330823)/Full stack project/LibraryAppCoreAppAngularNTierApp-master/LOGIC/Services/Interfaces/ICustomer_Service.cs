using LOGIC.Services.Models;
using LOGIC.Services.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ICustomer_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Customer_ResultSet>>> GetAllCustomers();
        Task<Generic_ResultSet<Customer_ResultSet>> GetCustomerById(Int64 id);

        //Task<Generic_ResultSet<Customer_ResultSet>> GetCustomerByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Customer_ResultSet>> AddCustomer(string name);
        Task<Generic_ResultSet<Customer_ResultSet>> UpdateCustomer(Int64 id, string name);
        Task<Generic_ResultSet<bool>> DeleteCustomer(Int64 id);

    }
}

