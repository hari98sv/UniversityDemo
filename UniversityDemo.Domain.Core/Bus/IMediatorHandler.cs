﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDemo.Domain.Core.Commands;

namespace UniversityDemo.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task CreateCommand<T>(T command) where T : Command;
        Task UpdateCommand<T>(T command) where T : Command;
    }
}
