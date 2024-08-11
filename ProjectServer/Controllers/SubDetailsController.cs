using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubDetailsController : ControllerBase
    {
        private readonly ISubDetails _IsubDetails;
       public SubDetailsController(ISubDetails subDetails) 
        { 
            _IsubDetails = subDetails;
        }

        [HttpPost("Add-SubDetails")]
        public async Task<IActionResult> AddSubDetails([FromBody] SubDetailsDtos subDetailsDto)
        {
            var result = await _IsubDetails.AddSubDetails(subDetailsDto);
            return Ok(result);
        }

        [HttpGet("Get-All-SubDetails")]
        public async Task<IActionResult> GetAllSubDetails()
        {
            var subDetails = await _IsubDetails.GetAllSubDetails();
            return Ok(subDetails);
        }

        [HttpGet("Get-SubDetails")]
        public async Task<IActionResult> GetSubDetailsByInfo()
        {
            var subDetails = await _IsubDetails.GetSubDetailsByInfo();
            return Ok(subDetails);
        }

        [HttpPut("Update-SubDetails-Status")]
        public async Task<IActionResult> UpdateSubDetails(int id, [FromBody] SubDetailsDtos subDetailsDto)
        {
            var result = await _IsubDetails.UpdateSubDetails(id, subDetailsDto);
            if (result)
            {
                return NoContent(); // Indicates successful update with no content to return
            }
            return NotFound(); // Indicates that the resource was not found
        }

        [HttpDelete("Delete-SubDetails")]
        public async Task<IActionResult> DeleteSubDetails(int id)
        {
            var subDetailsDto = new SubDetailsDtos { SubD_Id = id };
            var result = await _IsubDetails.DeleteSubDetails(subDetailsDto);
            if (result)
            {
                return NoContent(); // Indicates successful delete with no content to return
            }
            return NotFound(); // Indicates that the resource was not found
        }
    }
}
