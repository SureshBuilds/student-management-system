using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.DTOs
{
    public  class EnrollmentDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime EnrolledOn{ get; set; }


    }
}
