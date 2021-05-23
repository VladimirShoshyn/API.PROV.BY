using api.prov.by.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.prov.by.Controllers.v1
{    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            return Content("<h1>Hi, everyone!</h1>");
        }

        [HttpPost("/{id}")]
        public async Task<IActionResult> GetData(string id, [FromQuery] string pass)
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> AddData([FromBody] DataRequest dataRequest)
        {
            if (!ModelState.IsValid) return BadRequest();

            var dt = new Data(dataRequest);

            var res = new DataResponse 
            {
                ExpDate = dt.ExpirationDate,
                Link = dt.Number.ToString(),
                Pass = dt.Pass
            };            

            dt.Pass = dt.IsFree ? "" : Extensions.GetMD5(dt.Pass);

            return Ok(res);
        }
    }
}
