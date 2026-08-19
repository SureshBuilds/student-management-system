using StudentMS.Application.DTOs;
using StudentMS.Application.Interfaces;
using StudentMS.Domain.Entities;
using StudentMS.Domain.Enums;
using StudentMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.Services;

public class EnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto dto)
    {
        var student = await _studentRepository.GetByIdAsync(dto.StudentId);
        if (student is null)
            throw new DomainException("Student not found");
        
        var course= await _courseRepository.GetByIdAsync(dto.CourseId);
        if (course is null)
            throw new DomainException("Course not found");

        var existing =await _enrollmentRepository.GetByStudentAndCourseAsync(dto.StudentId, dto.CourseId);
        if (existing is not null && existing.Status == EnrollmentStatus.Active)
            throw new DomainException("Student is already enrolled in this course");

        var enrollment = new Enrollment(student, course);
        await _enrollmentRepository.AddAsync(enrollment);

        return MapToDto(enrollment);

    }


    public async Task<EnrollmentDto?> CompleteAsync(Guid enrollmentId)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
        if (enrollment is null) return null;

        enrollment.Complete();
        await _enrollmentRepository.UpdateAsync(enrollment);

        return MapToDto(enrollment);
    }
    
    public async Task<EnrollmentDto?> GetByIdAsync(Guid enrollmentId)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
        if (enrollment is null) return null;
        return MapToDto(enrollment);
    }
    
    public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
    {
        var enrollments = await _enrollmentRepository.GetAllAsync();
        return enrollments.Select(MapToDto);
    }   

    public async Task<EnrollmentDto?> DropAsync(Guid enrollmentId)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
        if (enrollment is null) return null;
        enrollment.Drop();
        await _enrollmentRepository.UpdateAsync(enrollment);
        return MapToDto(enrollment);
    }

    private static EnrollmentDto MapToDto(Enrollment enrollment)
    {
        // Mapping logic from Enrollment entity to EnrollmentDto
        return new EnrollmentDto
        {
            Id = enrollment.Id,
            StudentId = enrollment.StudentId,
            StudentName = enrollment.Student.FullName,
            CourseId = enrollment.CourseId,
            CourseTitle = enrollment.Course.Title,
            Status = enrollment.Status.ToString(),
            EnrolledOn = enrollment.EnrolledOn
        };
    }
}
