using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Application.Interfaces;
using UniversityDemo.Application.ViewModels;
using UniversityDemo.Domain.Commands;
using UniversityDemo.Domain.Core.Bus;
using UniversityDemo.Domain.Interfaces;
using UniversityDemo.Domain.Models;

namespace UniversityDemo.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _bus;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus)
        {
            _courseRepository = courseRepository;
            _bus = bus;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            var createCourseCommand = new CreateCourseCommand(
                                            courseViewModel.Name,
                                            courseViewModel.Description,
                                            courseViewModel.ImageUri);

            _bus.CreateCommand(createCourseCommand);
        }

        public void Update(CourseViewModel courseViewModel)
        {
            var updateCourseCommand = new UpdateCourseCommand(
                                            courseViewModel.Id,
                                            courseViewModel.Name,
                                            courseViewModel.Description,
                                            courseViewModel.ImageUri);

            _bus.UpdateCommand(updateCourseCommand);
        }

        public CourseViewModel GetCourses()
        {
            var res = new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };

            return res; 
        }
        
        public CourseViewModel GetCourseById(int id)
        {
            var course = _courseRepository.GetCourseByID(id);

            var res = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                ImageUri = course.ImageUri
            };

            return res; 
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
        }
    }
}
