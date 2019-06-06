using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Lr1WebApi.Models;

namespace Lr1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<PersonModel> _memCache = new List<PersonModel>();

        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> Get()
        {
            return Ok(_memCache);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonModel> Get(int id)
        {
            if (_memCache.Count <= id) return NotFound("No such");

            return Ok(_memCache[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonModel value)
        {
            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            _memCache.Add(value);

            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonModel value)
        {
            if (_memCache.Count <= id) return NotFound("No such");

            var validationResult = value.Validate();

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_memCache.Count <= id) return NotFound("No such");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}