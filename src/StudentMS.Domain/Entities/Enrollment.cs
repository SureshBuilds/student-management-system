using StudentMS.Domain.Common;
using StudentMS.Domain.Enums;
using StudentMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Domain.Entities;

    public class Enrollment:BaseEntity
    {
        public Student Student { get; private set; } = default!;
        public Guid StudentId { get; private set; }


        public Course Course { get; private set; } = default!;
        public Guid CourseId { get; set; }


        public EnrollmentStatus Status { get; private set; }
        public DateTime EnrolledOn { get; private set; }

        private Enrollment() { }
        public Enrollment(Student student, Course course)
        {
            if (student is null)
                throw new DomainException("Student is required.");
            if (course is null)
                throw new DomainException("Course is required.");

            Student= student;
            StudentId = student.Id;
            Course= course;
            CourseId = course.Id;
            Status = EnrollmentStatus.Active;
            EnrolledOn= DateTime.Now;

        }
        public void Complete() 
        {
            if (Status != EnrollmentStatus.Active)
                throw new DomainException("Only an active enrollment can be completed.");
            Status = EnrollmentStatus.Completed;

        }
        public void Drop()
        {
            if (Status != EnrollmentStatus.Active)
                throw new DomainException("Only an active enrollment can be dropped.");
            Status= EnrollmentStatus.Dropped;

        }



    }

