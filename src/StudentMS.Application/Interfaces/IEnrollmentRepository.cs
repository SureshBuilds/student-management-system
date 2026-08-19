using StudentMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetByIdAsync(Guid id);
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment?> GetByStudentAndCourseAsync(Guid studentId, Guid courseId);
        Task AddAsync(Enrollment enrollment);
        Task UpdateAsync(Enrollment enrollment);

    }
}
