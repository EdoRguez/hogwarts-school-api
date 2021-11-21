using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionApplicationController : ControllerBase
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public AdmissionApplicationController(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <remarks>
        /// Get all admission applications with optional query parameters
        /// </remarks>
        /// <response code="200">Array of admission applications</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AdmissionApplicationParameters parameters)
        {
            var admissions = await _repo.AdmissionApplicationRepository.GetAll(parameters, false);

            var dtos = _mapper.Map<IEnumerable<AdmissionApplicationDto>>(admissions);

            return Ok(dtos);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <remarks>
        /// Get a single admission application based on ID
        /// </remarks>
        /// <param name="id">Id of the admission application</param>
        /// <response code="200">Single admission application</response>
        /// <response code="404">No records where found</response>
        [HttpGet("{id}", Name = "AdmissionById")]
        public async Task<IActionResult> Get(int id)
        {
            var admission = await _repo.AdmissionApplicationRepository.Get(id, false);

            if (admission == null)
                return NotFound();

            var dto = _mapper.Map<AdmissionApplicationDto>(admission);

            return Ok(dto);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <remarks>
        /// Create an admission application following "AdmissionApplicationCreateDto" schema
        /// </remarks>
        /// <response code="201">Admission application created</response>
        /// <response code="400">Model is not valid or is null</response>
        /// <response code="404">Id house wasn't found</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdmissionApplicationCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Object sent cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var house = await _repo.HouseRepository.Get(dto.Id_House, false);
            if (house == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<AdmissionApplication>(dto);

            await _repo.AdmissionApplicationRepository.Create(model);
            await _repo.SaveAsync();

            model = await _repo.AdmissionApplicationRepository.Get(model.Id, false);

            var dtoToReturn = _mapper.Map<AdmissionApplicationDto>(model);

            return StatusCode(201, dtoToReturn);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <remarks>
        /// Update an admission application following "AdmissionApplicationUpdateDto" schema
        /// </remarks>
        /// <param name="id">Id of the admission application</param>
        /// <response code="204">Admission application updated</response>
        /// <response code="400">Model is not valid or is null</response>
        /// <response code="404">Id admission application or id house weren't found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdmissionApplicationUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Admission to update cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var house = await _repo.HouseRepository.Get(dto.Id_House, false);
            if (house == null)
            {
                return NotFound();
            }

            var model = await _repo.AdmissionApplicationRepository.Get(id, true);
            if (model == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, model);
            await _repo.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <remarks>
        /// Delete a single admission application based on ID
        /// </remarks>
        /// <param name="id">Id of the admission application</param>
        /// <response code="204">Admission application deleted</response>
        /// <response code="404">Id admission application wasn't found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _repo.AdmissionApplicationRepository.Get(id, false);
            if (model == null)
            {
                return NotFound();
            }

            _repo.AdmissionApplicationRepository.Delete(model);
            await _repo.SaveAsync();

            return NoContent();
        }

    }
}
