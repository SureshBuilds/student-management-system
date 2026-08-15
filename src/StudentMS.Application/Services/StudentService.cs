using StudentMS.Application.DTOs;
using StudentMS.Application.Interfaces;
using StudentMS.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.Services;

public class StudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<StudentDto?> GetByIdAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student is null) return null;
        return MapToDto(student);

    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return students.Select(MapToDto);

    }

    public async Task<StudentDto> CreateAsync(CreateStudentDto dto)
    {
        var student = new Student(dto.FirstName, dto.LastName, dto.Email, dto.DateOfBirth);
        await _studentRepository.AddAsync(student);
        return MapToDto(student);
    }


    public async Task<StudentDto?> UpdateAsync(UpdateStudentDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(dto.Id);
        if (student is null) return null;
        student.Rename(dto.FirstName, dto.LastName);
        student.UpdateContactDetails(dto.Email);

        await _studentRepository.UpdateAsync(student);
        return MapToDto(student);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _studentRepository.DeleteAsync(id);
    }

    private static StudentDto MapToDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            DateOfBirth = student.DateOfBirth,
        };
    }




}
