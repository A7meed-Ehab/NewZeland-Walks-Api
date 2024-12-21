using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;

        public WalksController(IMapper mapper)
        {
            this._mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalksDto createWalksDto)
        {
            var mappedModel=
        }
    }
}
