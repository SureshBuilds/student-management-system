using Microsoft.AspNetCore.Mvc;
using StudentMS.Application.DTOs;
using StudentMS.Application.Services;

namespace StudentMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetById(Guid id)
    {
        var student = await _studentService.GetByIdAsync(id);
        if (student == null)
            return NotFound();
        return Ok(student);
    }


    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create(CreateStudentDto dto)
    {
        var student = await _studentService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut]
    public async Task<ActionResult<StudentDto>> Update(UpdateStudentDto dto)
    {
        var student = await _studentService.UpdateAsync(dto);
        if (student == null)
            return NotFound();
        return Ok(student);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _studentService.DeleteAsync(id);
        return NoContent();
    }
}

