using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Application.DTOs
{
    public class UpdateCourseDto
    {
        public Guid Id {  get; set; }
        public string Title { get; set; } = default!;
        public string Code { get; set; } = default!;
        public decimal Credits { get; set; }
    }
}
