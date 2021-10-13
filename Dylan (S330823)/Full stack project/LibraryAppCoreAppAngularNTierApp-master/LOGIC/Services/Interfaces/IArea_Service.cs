using LOGIC.Services.Models;
using LOGIC.Services.Models.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Interfaces
{
    public interface IArea_Service
    {
        /* fetch methods */
        Task<Generic_ResultSet<List<Area_ResultSet>>> GetAllAreas();
        Task<Generic_ResultSet<Area_ResultSet>> GetAreaById(Int64 area_id);

        //Task<Generic_ResultSet<Area_ResultSet>> GetAreaByName(String name); always can add extra new calls as needed, and add to its dedicated
        //dal service and interface


        /* Create/Edit/Delete methods */
        Task<Generic_ResultSet<Area_ResultSet>> AddArea(string postcode, string cityname, string statename);
        Task<Generic_ResultSet<Area_ResultSet>> UpdateArea(Int64 area_id, string postcode, string cityname, string statename);
        Task<Generic_ResultSet<bool>> DeleteArea(Int64 area_id);

    }
}

