using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using Exceptionless;
using Exceptionless.Logging;
using Exceptionless.Models;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static LOGIC.Services.Interfaces.ILogger_Service;

namespace LOGIC.Services.Implementation
{
    public class Logger_Service : ILogger_Service
    {

        //Reference to our crud functions
        private ILogger_Operations _logger_operations = new Logger_Operations();
        private Exceptionless.Logging.LogLevel _level;

        public async Task<Generic_ResultSet<Logger_ResultSet>> AddLog(ILogger_Service.LogLevel level , string description)
        {
            Generic_ResultSet<Logger_ResultSet> result = new Generic_ResultSet<Logger_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Logger
                Logger Logger = new Logger
                {
                    Level = level.ToString(),
                    Description = description
                };

                //ADD Logger TO DB
                Logger = await _logger_operations.Create(Logger);

                //MANUAL MAPPING OF RETURNED Logger VALUES TO OUR Logger_ResultSet
                Logger_ResultSet loggerAdded = new Logger_ResultSet
                {
                    level = Logger.Level,
                    id = Logger.ID,
                    description = Logger.Description
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Logger logger {0} was added successfully", description);
                result.internalMessage = "LOGIC.Services.Implementation.Logger_Service: AddLog() method executed successfully.";
                result.result_set = loggerAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Logger logger supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Logger_Service: AddLog(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
                exception.ToExceptionless().Submit();
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Logger_ResultSet>>> GetAllLogs()
        {
            Generic_ResultSet<List<Logger_ResultSet>> result = new Generic_ResultSet<List<Logger_ResultSet>>();
            try
            {
                //GET ALL Loggers
                List<Logger> Loggers = await _logger_operations.ReadAll();
                //MAP DB Logger RESULTS
                result.result_set = new List<Logger_ResultSet>();
                // Iterate for each logger we got
                Loggers.ForEach(loggerItem =>
                {
                    result.result_set.Add(new Logger_ResultSet
                    {
                        id = loggerItem.ID,
                        level = loggerItem.Level,
                        description = loggerItem.Description
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Loggers obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Logger_Service: GetAllLogs() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Loggers from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Logger_Service: GetAllLogs(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
                exception.ToExceptionless().Submit();
            }
            return result;
        }

        public void Log(ILogger_Service.LogLevel level, string description)
        {

            _level = GetLogLevel(level);
            /* Submit to Exceptionless client */
            ExceptionlessClient.Default.SubmitLog(description, _level);
            /* Add to Database */
            _ = AddLog(level, description);
        }

        public void EventLog(string message, string type, string source)
        {
            /* Submit to Exceptionless client */
            ExceptionlessClient.Default.SubmitEvent(new Event { Message = message, Type = type, Source = source });
            /* Add to Database */
            _ = AddLog(ILogger_Service.LogLevel.other, string.Format("{0}, {1}, {2}", message, type, source));

        }

        public Exceptionless.Logging.LogLevel GetLogLevel(ILogger_Service.LogLevel level)
        {
            return level switch
            {
                ILogger_Service.LogLevel.trace => Exceptionless.Logging.LogLevel.Trace,
                ILogger_Service.LogLevel.debug => Exceptionless.Logging.LogLevel.Debug,
                ILogger_Service.LogLevel.info => Exceptionless.Logging.LogLevel.Info,
                ILogger_Service.LogLevel.warn => Exceptionless.Logging.LogLevel.Warn,
                ILogger_Service.LogLevel.error => Exceptionless.Logging.LogLevel.Error,
                ILogger_Service.LogLevel.fatal => Exceptionless.Logging.LogLevel.Fatal,
                _ => Exceptionless.Logging.LogLevel.Other,
            };
        }
    }
}
