using System.Threading.Tasks;

namespace RavenDb.DDD.Core.Events
{
    /// <summary>
    /// Handle domain event
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    public interface ISubscribeTo<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handle(TDomainEvent domainEvent);
    }
}