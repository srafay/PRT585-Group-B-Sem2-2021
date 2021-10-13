using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Area;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Area area Data
    /// </summary>
    public class Area_Service : IArea_Service
    {
        //Reference to our crud functions
        private IArea_Operations _area_operations = new Area_Operations();

        /// <summary>
        /// Obtains all the Area areaes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Area_ResultSet>>> GetAllAreas()
        {
            Generic_ResultSet<List<Area_ResultSet>> result = new Generic_ResultSet<List<Area_ResultSet>>();
            try
            {
                //GET ALL Area areaES
                List<Area> Areaes = await _area_operations.ReadAll();
                //MAP DB Area RESULTS
                result.result_set = new List<Area_ResultSet>();
                Areaes.ForEach(area =>
                {
                    result.result_set.Add(new Area_ResultSet
                    {
                        area_id = area.AreaId,
                        postcode = area.Postcode,
                        cityname = area.CityName,
                        statename = area.StateName,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Area areaes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Area_Service: GetAllAreas() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Area areaes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Area_Service: GetAllAreas(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Area_ResultSet>> GetAreaById(long id)
        {
            Generic_ResultSet<Area_ResultSet> result = new Generic_ResultSet<Area_ResultSet>();
            try
            {
                //GET by ID Area 
                var Area = await _area_operations.Read(id);

                //MAP DB Area RESULTS
                result.result_set = new Area_ResultSet
                {
                    area_id = Area.AreaId,
                    postcode = Area.Postcode,
                    cityname = Area.CityName,
                    statename = Area.StateName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Area  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Area_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Area  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Area_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new area to the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Area_ResultSet>> AddArea(string postcode, string cityname, string statename)
        {
            Generic_ResultSet<Area_ResultSet> result = new Generic_ResultSet<Area_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Area
                Area Area = new Area
                {
                    Postcode = postcode,
                    CityName = cityname,
                    StateName = statename
                };

                //ADD Area TO DB
                Area = await _area_operations.Create(Area);

                //MANUAL MAPPING OF RETURNED Area VALUES TO OUR Area_ResultSet
                Area_ResultSet areaAdded = new Area_ResultSet
                {
                    postcode = Area.Postcode,
                    area_id = Area.AreaId,
                    cityname = Area.CityName,
                    statename = Area.StateName,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Area area {0} was added successfully", postcode);
                result.internalMessage = "LOGIC.Services.Implementation.Area_Service: AddArea() method executed successfully.";
                result.result_set = areaAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Area area supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Area_Service: AddArea(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Area areas postcode cityname statename.
        /// </summary>
        /// <param name="area_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Area_ResultSet>> UpdateArea(Int64 area_id, string postcode, string cityname, string statename)
        {
            Generic_ResultSet<Area_ResultSet> result = new Generic_ResultSet<Area_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Area
                Area Area = new Area
                {
                    
                    AreaId = area_id,
                    Postcode = postcode,
                    CityName = cityname,
                    StateName = statename
                    //Area_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Area IN DB
                Area = await _area_operations.Update(Area, area_id);

                //MANUAL MAPPING OF RETURNED Area VALUES TO OUR Area_ResultSet
                Area_ResultSet areaUpdated = new Area_ResultSet
                {
                    area_id = Area.AreaId,
                    postcode = Area.Postcode,
                    cityname = Area.CityName,
                    statename = Area.StateName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Area area {0} was updated successfully", postcode);
                result.internalMessage = "LOGIC.Services.Implementation.Area_Service: UpdateArea() method executed successfully.";
                result.result_set = areaUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Area area supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Area_Service: UpdateArea(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteArea(long area_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Area IN DB
                var areaDeleted = await _area_operations.Delete(area_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Area area {0} was deleted successfully", area_id);
                result.internalMessage = "LOGIC.Services.Implementation.Area_Service: DeleteArea() method executed successfully.";
                result.result_set = areaDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Area area supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Area_Service: DeleteArea(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
