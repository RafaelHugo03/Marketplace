using FluentValidation.Results;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using MediatR;

namespace Marketplace.Infra.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediatr;

        public InMemoryBus(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        public Task PublishEvent<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await mediatr.Send(command);
        }
    }
}