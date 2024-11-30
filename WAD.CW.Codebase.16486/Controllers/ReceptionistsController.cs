using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW.Codebase._16486.DTOModels;
using WAD.CW.Codebase._16486.Interfaces;

namespace WAD.CW.Codebase._16486.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptionistsController : ControllerBase
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IMapper _mapper;

        public ReceptionistsController(IReceptionistRepository receptionistRepository, IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceptionistDto>>> GetReceptionists()
        {
            var receptionists = await _receptionistRepository.GetAllAsync();
            var receptionistDtos = _mapper.Map<List<ReceptionistDto>>(receptionists);
            return Ok(receptionistDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceptionistDto>> GetReceptionistById(int id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);
            if (receptionist == null)
                return NotFound();

            var receptionistDto = _mapper.Map<ReceptionistDto>(receptionist);
            return Ok(receptionistDto);
        }

        [HttpPost]
        public async Task<ActionResult<ReceptionistDto>> CreateReceptionist(CreateReceptionistDto createReceptionistDto)
        {
            var receptionist = _mapper.Map<Receptionist>(createReceptionistDto);
            await _receptionistRepository.AddAsync(receptionist);

            var receptionistDto = _mapper.Map<ReceptionistDto>(receptionist);
            return CreatedAtAction(nameof(GetReceptionistById), new { id = receptionistDto.Id }, receptionistDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceptionist(int id, UpdateReceptionistDto updateReceptionistDto)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);
            if (receptionist == null)
                return NotFound();

            _mapper.Map(updateReceptionistDto, receptionist);
            await _receptionistRepository.UpdateAsync(receptionist);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceptionist(int id)
        {
            var receptionist = await _receptionistRepository.GetByIdAsync(id);
            if (receptionist == null)
                return NotFound();

            await _receptionistRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
