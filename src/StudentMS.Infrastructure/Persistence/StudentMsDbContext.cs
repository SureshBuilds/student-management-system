using Microsoft.EntityFrameworkCore;
using StudentMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentMS.Infrastructure.Persistence;

    public class StudentMsDbContext :DbContext
    {
        public StudentMsDbContext(DbContextOptions<StudentMsDbContext> options): base(options)
        {
        }
        public DbSet<Student> Students=>Set<Student>();
        public DbSet<Course> Courses=> Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentMsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed
        }
    }
