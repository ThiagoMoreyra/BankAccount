using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAccount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankStatementController : ControllerBase
    {
        // GET: api/<BankStatementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BankStatementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BankStatementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BankStatementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BankStatementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
