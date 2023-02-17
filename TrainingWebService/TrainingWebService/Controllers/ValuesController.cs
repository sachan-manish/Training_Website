using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingWebService.Models;

namespace TrainingWebService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (TrainingDatabaseContext context = new TrainingDatabaseContext())
            {

                var dbData = context.Modules.ToList();
                return Ok(dbData);
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetSubModules(int id)
        {
            using (TrainingDatabaseContext context = new TrainingDatabaseContext())
            {

                var dbData = context.SubModules.ToList().Where(a => a.ModuleId == id);
                return Ok(dbData);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
