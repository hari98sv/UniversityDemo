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

            _bus.SendCommand(createCourseCommand);
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                Courses = _courseRepository.GetCourses()
            };
        }
    }
}
