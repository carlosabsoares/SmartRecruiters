using Flunt.Validations;
using MediatR;
using SmartRecruiters.Api.Application.Configuration.Events;

namespace SmartRecruiters.Api.Application.Configuration.Commands
{
    public interface ICommand : IRequest<IEvent>, IValidatable
    {
    }
}