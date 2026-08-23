using Microsoft.EntityFrameworkCore;
using StudentMS.Application.Interfaces;
using StudentMS.Domain.Entities;
using StudentMS.Infrastructure.Persistence;

namespace StudentMS.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly StudentMsDbContext _context;

    public StudentRepository(StudentMsDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var student = await GetByIdAsync(id);
        if (student is not null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}   