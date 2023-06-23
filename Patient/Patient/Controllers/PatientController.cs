using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.DataAccess.EntityDTO;
using Patient.Services.Interfaces;
using System.Net;
using Helpers.Common;
using Microsoft.AspNetCore.Authorization;

namespace Patient.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // GET: PatientController
        private readonly IPatientInfoService _patientInfoService;
        public PatientController(IPatientInfoService patientInfoService)
        {
            _patientInfoService = patientInfoService;
        }
        [Route("GetPatient")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_patientInfoService.GetPatient());
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Content(HttpStatusCode.Conflict.ToString(), error);
            }
        }
        [Route("AddPatient")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientRecordDTO patientRecordDTO)
        {
            Common common = new Common();
            bool IsFlag = await _patientInfoService.AddPatient(patientRecordDTO);
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
    }
}
