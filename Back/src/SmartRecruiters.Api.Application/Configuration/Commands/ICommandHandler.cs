using MediatR;
using SmartRecruiters.Api.Application.Configuration.Events;

namespace SmartRecruiters.Api.Application.Configuration.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IEvent> where TCommand : ICommand
    {
    }
}