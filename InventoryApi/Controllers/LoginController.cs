using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/values
        [Route("GetLogin")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        [HttpGet("{id}", Name = "GetLoginById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/values/5
        [HttpPut("{id}",Name ="Update")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}",Name ="Delete")]
        public void Delete(int id)
        {
        }
    }
}