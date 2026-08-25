using StudentMS.Application.DTOs;
using StudentMS.Application.Interfaces;
using StudentMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentMS.Application.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto?> GetByIdAsync(Guid id)
        {
            var course=await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;
            return MapToDto(course);

        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(MapToDto);
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var course = new Course(dto.Title, dto.Code, dto.Credits);
            await _courseRepository.AddAsync(course);
            return MapToDto(course);
        }

        public async Task<CourseDto?> UpdateAsync(UpdateCourseDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(dto.Id);
            if (course == null) return null;
            course.UpdateDetails(dto.Title, dto.Code, dto.Credits);
            await _courseRepository.UpdateAsync(course);
            return MapToDto(course);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        private static CourseDto MapToDto(Course course)
        {
            return new CourseDto
            {
                Id= course.Id,
                Title = course.Title,
                Code= course.Code,
                Credits= course.Credits
            };
        }
    }
}
