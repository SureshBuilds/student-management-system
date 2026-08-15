using StudentMS.Domain.Common;
using StudentMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Domain.Entities
{
    public class Student: BaseEntity
    {
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public DateTime DateOfBirth { get; private set; }
        private Student() { }
        public Student(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("FIrst name is required.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name is required.");
            if (!string.IsNullOrWhiteSpace(email) || email.Contains('@')) 
                throw new DomainException("Email is required.");
            if (dateOfBirth == default || dateOfBirth>=DateTime.UtcNow)
                throw new DomainException("A valid date of birth in the past is required.");
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public string FullName => $"{FirstName} {LastName}";
        public void UpdateContactDetails(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                throw new DomainException("A valid Email is required.");
            Email = email;
        }
        public void Rename(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("First name is required.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name is required.");
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
