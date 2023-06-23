using Helpers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Requisition.DataAccess.EntityDTO;
using Requisition.Services.Interfaces;
using System.Net;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Requisition.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RequistionController : ControllerBase
    {
        private readonly IReqInfoService _reqInfoService;
        public RequistionController(IReqInfoService reqInfoService)
        {
            _reqInfoService = reqInfoService;
        }
        // GET: api/<RequistionController>
        [Route("GetRequisition")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_reqInfoService.GetRequisition());
            }
            catch (Exception e)
            {
                var error = e.Message;
                return Content(HttpStatusCode.Conflict.ToString(), error);
            }
        }

        // GET api/<RequistionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RequistionController>
        [Route("AddRequisition")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequisitionRecordDTO requisitionRecordDTO)
        {
            Common common = new Common();
            bool IsFlag = await _reqInfoService.AddRequisition(requisitionRecordDTO);
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

        // PUT api/<RequistionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequistionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
