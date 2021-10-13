using LOGIC.Services.Models.MyLogger;
using LOGIC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IMyLogger_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<MyLogger_ResultSet>>> GetAllLogs();
        Task<Generic_ResultSet<MyLogger_ResultSet>> GetLogById(Int64 id);
        Task<Generic_ResultSet<MyLogger_ResultSet>> AddLog(string LoggerMsg, string LoggerInfo);
        Task<Generic_ResultSet<bool>> DeleteLog(Int64 id);
        
    }
}
