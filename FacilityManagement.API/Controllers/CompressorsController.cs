﻿using AutoMapper;
using FacilityManagement.API.Models;
using FacilityManagement.API.Models.Repositories;
using FacilityManagement.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FacilityManagement.API.Controllers
{
    [Route("api/compressors")]
    [ApiController]
    public class CompressorsController : ControllerBase
    {
        private readonly ICompressorRepository _compressorRepository;
        private readonly IMapper _mapper;

        public CompressorsController(
            ICompressorRepository compressorRepository,
            IMapper mapper)
        {
            _compressorRepository = compressorRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<CompressorModel[]>> GetAll()
        {
            try
            {
                var results = await _compressorRepository.GetAllCompressorsAsync();

                return _mapper.Map<CompressorModel[]>(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompressorModel>> GetCompressorByIdAsync(int id, 
            bool includeTypes = false, bool includeSystems = false, bool includeParts = false)
        {
            var compressor = await _compressorRepository.GetCompressorByIdAsync(id, includeTypes, includeSystems, includeParts);

            if (compressor == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<CompressorModel>(compressor);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompressorAsync([FromBody] CompressorModel model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                // return 422 - Unprocessable Entity when validation fails
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var compressor = await _compressorRepository.GetCompressorByIdAsync(model.CompressorId);
            if (compressor == null)
            {
                return NotFound();
            }
            
            Mapper.Map(model, compressor);

            await _compressorRepository.UpdateCompressorAsync(compressor);

            return Ok(new { success = true, message = "Add new data success." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompressorAsync(int id)
        {
            var compressor = await _compressorRepository.GetCompressorByIdAsync(id, true);
            if (compressor == null)
            {
                return NotFound();
            }

            _compressorRepository.DeleteCompressor(compressor);

            return Ok(new { success = true, message = "Succ deleted." });
        }
    }
}
