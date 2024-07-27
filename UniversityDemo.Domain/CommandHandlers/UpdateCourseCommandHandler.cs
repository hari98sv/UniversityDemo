using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversityDemo.Domain.Commands;
using UniversityDemo.Domain.Interfaces;
using UniversityDemo.Domain.Models;

namespace UniversityDemo.Domain.CommandHandlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<CourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<bool> Handle(CourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ImageUri = request.ImageUri
            };

            _courseRepository.Update(course);

            return Task.FromResult(true);

        }
    }
}
