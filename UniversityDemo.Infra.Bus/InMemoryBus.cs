using MediatR;
using System;
using System.Threading.Tasks;
using UniversityDemo.Domain.Core.Bus;
using UniversityDemo.Domain.Core.Commands;

namespace UniversityDemo.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task CreateCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task UpdateCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
