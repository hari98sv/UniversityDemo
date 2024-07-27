using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDemo.Domain.Commands
{
    public class UpdateCourseCommand : CourseCommand
    {
        public UpdateCourseCommand(int id, string name, string desciption, string imageUri)
        {
            Id = id;
            Name = name;
            Description = desciption;
            ImageUri = imageUri;
        }
    }
}
