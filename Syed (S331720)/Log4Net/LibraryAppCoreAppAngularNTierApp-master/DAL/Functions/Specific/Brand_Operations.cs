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
    public class Brand_Operations : IBrand_Operations
    {
        public async Task<Brand> Create(Brand objectToAdd)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                await context.AddAsync<Brand>(objectToAdd);
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
                var recordToDelete = await context.FindAsync<Brand>(entityId);
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

        public async Task<Brand> Read(long entityId)
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.FindAsync<Brand>(entityId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Brand>> ReadAll()
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.Set<Brand>().ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Brand> Update(Brand objectToUpdate, long entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<Brand>(entityId);
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
