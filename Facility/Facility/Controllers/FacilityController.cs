using Microsoft.AspNetCore.Mvc;
using System.Net;
using Facility.DataAccess.EntityDTO;
using Facility.Services.Interface;
using Helpers.Common;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Facility.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityInfoService _facilityInfoService;
        public FacilityController(IFacilityInfoService facilityInfoService)
        {
            _facilityInfoService = facilityInfoService;
        }

        [Route("GetFacility")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_facilityInfoService.GetFacility());
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Content(HttpStatusCode.Conflict.ToString(), error);
            }
        }
        [Route("AddFacility")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacilityInfoDTO facilityInfoDTO)
        {
            Common common = new Common();
            bool IsFlag = await _facilityInfoService.AddFacility(facilityInfoDTO);
            if (IsFlag)
            {
                common.statusCode = 200;
                common.statusMessage = "Data Save Successfully.";
            }
            else
            {
                common.statusCode = 200;
                common.statusMessage = "Some thing went wrong.Please contact to the support team";
            }
            return Ok(common);
        }

        // PUT api/<FacilityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FacilityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
