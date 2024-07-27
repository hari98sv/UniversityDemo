using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Domain.Models;

namespace UniversityDemo.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseByID(int id);
        void Add(Course course);
        void Update(Course course);
        void DeleteCourse(int id);
    }
}
