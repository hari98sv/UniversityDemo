﻿using System;
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

        void Create(CourseViewModel courseViewModel);
    }
}
