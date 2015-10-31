using System.Threading.Tasks;

namespace RavenDb.DDD.Core.Events
{
    /// <summary>
    /// Publishes domain event
    /// </summary>
    public interface IPublishDomainEvent
    {
        Task Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
    }
}
