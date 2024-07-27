using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Application.ViewModels;

namespace UniversityDemo.Application.Interfaces
{
    public interface ICourseService
    {
        CourseViewModel GetCourses();
        CourseViewModel GetCourseById(int id);

        void Create(CourseViewModel courseViewModel);
        void Update(CourseViewModel courseViewModel);
        void DeleteCourse(int id);
    }
}
