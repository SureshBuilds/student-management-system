using StudentMS.Domain.Common;
using  StudentMS.Domain.Exceptions;
namespace StudentMS.Domain.Entities;

    public class Course : BaseEntity
{
    public string Title { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public decimal Credits { get; private set; }

    private Course() { }
    public Course(string title, string code, decimal credits)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Title is required.");
        if (string.IsNullOrWhiteSpace(code))
            throw new DomainException("Code is required.");
        if (credits <= 0)
            throw new DomainException("Credits must be greater than zero.");
        Title = title;
        Code = code;
        Credits = credits;
    }

}
