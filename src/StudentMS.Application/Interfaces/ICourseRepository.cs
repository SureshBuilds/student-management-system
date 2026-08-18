using StudentMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Course course);
    }
}

