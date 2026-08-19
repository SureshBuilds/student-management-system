using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.DTOs
{
    public class CreateEnrollmentDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
