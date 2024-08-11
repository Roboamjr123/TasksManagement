using AuthLibrary.Dtos;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Interface
{
    public interface ISubDetails
    {
        Task<IEnumerable<SubDetails>> GetAllSubDetails();
        Task<IEnumerable<SubTasksDtos>> GetSubDetailsByInfo();
        Task<string> AddSubDetails(SubDetailsDtos subDetails);
        Task<bool> UpdateSubDetails(int id,SubDetailsDtos subDetails);
        Task<bool> DeleteSubDetails(SubDetailsDtos subDetailsdto);

    }
}
