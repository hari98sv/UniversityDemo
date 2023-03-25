using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDemo.Domain.Commands
{
    public class CreateCourseCommand : CourseCommand
    {
        public CreateCourseCommand(string name, string desciption, string imageUri)
        {
            Name = name;
            Description = desciption;
            ImageUri = imageUri;
        }
    }
}
