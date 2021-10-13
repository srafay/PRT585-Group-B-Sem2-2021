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
    public class Logger_Operations : ILogger_Operations
    {
        public async Task<Logger> Create(Logger objectToAdd)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                await context.AddAsync<Logger>(objectToAdd);
                await context.SaveChangesAsync();
                return objectToAdd;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Logger>> ReadAll()
        {
            try
            {
                using DatabaseContext context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions);
                var result = await context.Set<Logger>().ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
