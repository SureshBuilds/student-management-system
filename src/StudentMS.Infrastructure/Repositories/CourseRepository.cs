using Microsoft.EntityFrameworkCore;
using StudentMS.Application.Interfaces;
using StudentMS.Domain.Entities;
using StudentMS.Infrastructure.Persistence;

namespace StudentMS.Infrastructure.Repositories;
public class CourseRepository : ICourseRepository
{
    private readonly StudentMsDbContext _context;
    public CourseRepository(StudentMsDbContext context)
    {
        _context = context;
    }
    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }
    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var course = await GetByIdAsync(id);
        if (course is not null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}