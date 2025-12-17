using Flunt.Validations;
using MediatR;
using SmartRecruiters.Api.Application.Configuration.Events;

namespace SmartRecruiters.Api.Application.Configuration.Queries
{
    public interface IQuery : IRequest<IEvent>, IValidatable
    {
    }
}