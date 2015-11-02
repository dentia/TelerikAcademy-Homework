namespace StudentSystem.Services.Models
{
    using System;

    public class TestModel
    {
        public int Id { get; set; }

        public virtual Guid CourseId { get; set; }
    }
}