using MediatR;
using SmartRecruiters.Api.Application.Configuration.Events;

namespace SmartRecruiters.Api.Application.Configuration.Queries
{
    public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, IEvent> where TQuery : IQuery
    {
    }
}