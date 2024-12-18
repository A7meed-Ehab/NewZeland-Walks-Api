using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IMapper _Mapper;
        private readonly AppDbContext _context;
        private readonly IRegionRepository _regionRepository;

        public RegionController(IMapper mapper,AppDbContext appDbContext,IRegionRepository regionRepository)
        {
            this._Mapper = mapper;
            this._context = appDbContext;
            this._regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions =await _regionRepository.GetAllAsync();
            return Ok(_Mapper.Map<List<RegionDTO>>(regions));
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var region =await _context.Regions.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (region == null)
            {
                return NotFound();
            }
            return Ok(_Mapper.Map<RegionDTO>(region));
        }
        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] CreateRegionDto regionDto)
        {
            if (ModelState.IsValid)
            {

                var mappedModel = _Mapper.Map<Region>(regionDto);
                if (mappedModel == null)
                {
                    return BadRequest();
                }
                await  _regionRepository.CreateAsync(mappedModel);
                var modelDto = _Mapper.Map<RegionDTO>(mappedModel);
                return CreatedAtAction(nameof(GetById), new { id = modelDto.Id }, modelDto);
             }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            if (ModelState.IsValid)
            {
                var region =_Mapper.Map<Region>(updateRegionDto);
                var updatedRegion =await _regionRepository.UpdateAsync(Id, region);
                if (updatedRegion == null)
                {
                    return NotFound($"Region with ID {Id} not found.");
                }
               return Ok(_Mapper.Map<RegionDTO>(region));
            }else{
                return BadRequest();
            } 
        }
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var region =await _regionRepository.DeleteAsync(Id);
            if(region == null)
            {
            return NotFound();
            }
          
            return Ok(_Mapper.Map<RegionDTO>(region));
        }
    }

}
