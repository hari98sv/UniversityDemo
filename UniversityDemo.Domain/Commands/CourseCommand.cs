using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Domain.Core.Commands;

namespace UniversityDemo.Domain.Commands
{
    public abstract class CourseCommand : Command
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUri { get; protected set; }
    }
}
