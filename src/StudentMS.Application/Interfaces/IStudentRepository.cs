using StudentMS.Application.DTOs;
using StudentMS.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.Interfaces;
public interface IStudentRepository
{
         Task<Student?> GetByIdAsync(Guid id);
         Task<IEnumerable<Student>> GetAllAsync();
         Task AddAsync(Student student);
         Task UpdateAsync(Student student);
         Task DeleteAsync(Guid id);
}

