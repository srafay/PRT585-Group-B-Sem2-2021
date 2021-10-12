using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = DAL.Entities.Type;

namespace DAL.Functions.Specific
{
    public class Type_Operations : IType_Operations
    {
        public async Task<Type> Create(Type objectToAdd)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                await context.AddAsync<Type>(objectToAdd);
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
                var recordToDelete = await context.FindAsync<Type>(entityId);
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

        public async Task<Type> Read(long entityId)
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.FindAsync<Type>(entityId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Type>> ReadAll()
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.Set<Type>().ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Type> Update(Type objectToUpdate, long entityId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    var objectFound = await context.FindAsync<Type>(entityId);
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
