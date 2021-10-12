using LOGIC.Services.Models;
using LOGIC.Services.Models.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface ILogger_Service
    { public enum LogLevel
        {
            trace,
            debug,
            info,
            warn,
            error,
            fatal,
            other
        };

        Task<Generic_ResultSet<Logger_ResultSet>> AddLog(LogLevel level, string description);
        Task<Generic_ResultSet<List<Logger_ResultSet>>> GetAllLogs();

        void Log(LogLevel level, string description);

        void EventLog(string message, string type, string source);
        Exceptionless.Logging.LogLevel GetLogLevel(LogLevel level);
    }
}
