using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? CourseCategoryId { get; set; }
        public string CourseConfirm { get; set; }
        public string CourseImg { get; set; }
        public int? CourseInsanId { get; set; }
        public int? CoursePrice { get; set; }
    }
}
