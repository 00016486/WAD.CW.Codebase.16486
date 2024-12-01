using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW.Codebase._16486.DTOModels;
using WAD.CW.Codebase._16486.Interfaces;

namespace WAD.CW.Codebase._16486.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorsController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorsController(IVisitorRepository visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorDto>>> GetVisitors()
        {
            var visitors = await _visitorRepository.GetAllAsync();
            var visitorDtos = _mapper.Map<List<VisitorDto>>(visitors);
            return Ok(visitorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorDto>> GetVisitorById(int id)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);
            if (visitor == null)
                return NotFound(new { message = "Visitor not found." });

            var visitorDto = _mapper.Map<VisitorDto>(visitor);
            return Ok(visitorDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVisitor(CreateVisitorDto createVisitorDto)
        {
            var visitor = _mapper.Map<Visitor>(createVisitorDto);
            await _visitorRepository.AddAsync(visitor);

            return Ok(new { message = "Visitor added successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitor(int id, UpdateVisitorDto updateVisitorDto)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);
            if (visitor == null)
                return NotFound(new { message = "Visitor not found." });

            _mapper.Map(updateVisitorDto, visitor);
            await _visitorRepository.UpdateAsync(visitor);

            return Ok(new { message = "Visitor updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var visitor = await _visitorRepository.GetByIdAsync(id);
            if (visitor == null)
                return NotFound(new { message = "Visitor not found." });

            await _visitorRepository.DeleteAsync(id);
            return Ok(new { message = "Visitor deleted successfully." });
        }

        [HttpGet("by-receptionist/{receptionistId}")]
        public async Task<ActionResult<IEnumerable<VisitorDto>>> GetVisitorsByReceptionist(int receptionistId)
        {
            var visitors = await _visitorRepository.GetVisitorsByReceptionistIdAsync(receptionistId);
            var visitorDtos = _mapper.Map<List<VisitorDto>>(visitors);
            return Ok(visitorDtos);
        }
    }
}