using Microsoft.AspNetCore.Mvc;
using StudentMS.Application.DTOs;
using StudentMS.Application.Services;

namespace StudentMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase  
    {
        private readonly EnrollmentService _enrollmentService;
        public EnrollmentController(EnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> Create(CreateEnrollmentDto dto)
        {
            var enrollment = await _enrollmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, enrollment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetById(Guid id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult<EnrollmentDto>> Complete(Guid id)
        {
            var enrollment = await _enrollmentService.CompleteAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost("{id}/drop")]
        public async Task<ActionResult<EnrollmentDto>> Drop(Guid id)
        {
            var enrollment = await _enrollmentService.DropAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

    }
}
