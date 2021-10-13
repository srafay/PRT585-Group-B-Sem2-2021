using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class CustomerContact_Operations : ICustomerContact_Operations
    {
        public async Task<CustomerContact> Create(CustomerContact objectToAdd)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                await context.AddAsync<CustomerContact>(objectToAdd);
                await context.SaveChangesAsync();
                return objectToAdd;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(long entityId)
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var recordToDelete = await context.FindAsync<CustomerContact>(entityId);
                if (recordToDelete != null)
                {
                    context.Remove(recordToDelete);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerContact> Read(long entityId)
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.FindAsync<CustomerContact>(entityId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CustomerContact>> ReadAll()
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.Set<CustomerContact>().ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CustomerContact> Update(CustomerContact objectToUpdate, long entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<CustomerContact>(entityId);
                    if (objectFound != null)
                    {
                        context.Entry(objectFound).CurrentValues.SetValues(objectToUpdate);
                        await context.SaveChangesAsync();
                    }
                    return objectFound;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
