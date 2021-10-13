using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using Microsoft.Extensions.Logging;
using LOGIC.Services.Models;
using LOGIC.Services.Models.MyLogger;
using System;
using log4net;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    public class MyLogger_Service : IMyLogger_Service
    {
        private readonly ILogger<MyLogger_Service> _logger;


        public MyLogger_Service(ILogger<MyLogger_Service> logger)
        {
            _logger = logger;
        }

        //Reference to our crud functions
        private readonly ICRUD _crud = new CRUD();
        //GetAllProducts, GetProductByID, AddProduct, DeleteProduct
        public async Task<Generic_ResultSet<MyLogger_ResultSet>> AddLog(string LoggerMsg, string LoggerInfo)
        {
            Generic_ResultSet<MyLogger_ResultSet> result = new Generic_ResultSet<MyLogger_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Applicant
                MyLogger MyLogger = new MyLogger
                {
                    LoggerMsg = LoggerMsg,
                    LoggerInfo = LoggerInfo,

                };
                //writing to file
                /*_logger.LogInformation(LoggerMsg);*/

                //ADD Applicant TO DB
                MyLogger = await _crud.Create<MyLogger>(MyLogger);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                MyLogger_ResultSet MyLoggerAdded = new MyLogger_ResultSet
                {
                    Id = MyLogger.Id,
                    LoggerMsg = MyLogger.LoggerMsg,
                    LoggerInfo = MyLogger.LoggerInfo,

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Your child {0} was registered successfully. Info -> {1}", MyLogger.LoggerMsg,MyLogger.LoggerInfo);
                result.internalMessage = "LOGIC.Services.Implementation.MyLogger_Service: AddLog() method executed successfully.";
                result.result_set = MyLoggerAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for your child. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.MyLogger_Service: AddLog(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
                /*_logger.LogError(result.internalMessage);*/
            }
            return result;
        }


        public async Task<Generic_ResultSet<MyLogger_ResultSet>> GetLogById(Int64 Id)
        {
            Generic_ResultSet<MyLogger_ResultSet> result = new Generic_ResultSet<MyLogger_ResultSet>();
            try
            {
                //GET Person FROM DB
                MyLogger MyLogger = await _crud.Read<MyLogger>(Id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                MyLogger_ResultSet MyLoggerReturned = new MyLogger_ResultSet
                {
                    Id = MyLogger.Id,
                    LoggerMsg = MyLogger.LoggerMsg,
                    LoggerInfo = MyLogger.LoggerInfo,
       
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Person {0} was found successfully. Info -> {1}", MyLoggerReturned.LoggerMsg, MyLoggerReturned.LoggerInfo);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: GetProductById() method executed successfully.";
                result.result_set = MyLoggerReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = string.Format("We failed find the LOG you are looking for. {0}", exception.Message);
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.MyLogger_Service: GetLogById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<bool>> DeleteLog(Int64 Id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //GET Person FROM DB
                var MyLogger = await _crud.Delete<MyLogger>(Id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("LOG with Id {0} was Deleted successfully", Id);
                result.internalMessage = "LOGIC.Services.Implementation.Product_Service: DelLogById() method executed successfully.";
                result.result_set = MyLogger;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed find the Log you are looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.MyLogger_Service: DeleteLog(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<MyLogger_ResultSet>>> GetAllLogs()
        {
            Generic_ResultSet<List<MyLogger_ResultSet>> result = new Generic_ResultSet<List<MyLogger_ResultSet>>();
            try
            {
                //GET ALL GRADES
                List<MyLogger> MyLogger = await _crud.ReadAll<MyLogger>();
                //MAP DB GRADE RESULTS
                result.result_set = new List<MyLogger_ResultSet>();
                MyLogger.ForEach(dg => {
                    result.result_set.Add(new MyLogger_ResultSet
                    {
                        Id = dg.Id,
                        LoggerMsg = dg.LoggerMsg,
                        LoggerInfo = dg.LoggerInfo,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Logs obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.MyLogger_Service: GetAllLogs() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Logs from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.MyLogger_Service: GetAllLogs(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }

}