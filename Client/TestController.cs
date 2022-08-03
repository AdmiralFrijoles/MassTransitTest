using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRequestClient<TestRequest> _client;

        public TestController(IRequestClient<TestRequest> client)
        {
            _client = client;
        }

        [HttpGet("{num}")]
        public async Task<ActionResult<List<string>>> Get(int num)
        {
            var response = await _client.GetResponse<TestResponse>(new() { Limit = num });
            return Ok(response.Message.Values);
        }
    }
}
