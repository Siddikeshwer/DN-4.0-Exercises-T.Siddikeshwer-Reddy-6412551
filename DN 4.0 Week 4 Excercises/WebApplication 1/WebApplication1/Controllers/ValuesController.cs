using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private static List<string> items = new List<string> { "item1", "item2" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(items);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            items.Add(value);
            return Ok(items);
        }

        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] string value)
        {
            if (index >= 0 && index < items.Count)
            {
                items[index] = value;
                return Ok(items);
            }
            return BadRequest();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
                return Ok(items);
            }
            return BadRequest();
        }
    }
}
