using System.Threading.Tasks;

namespace RavenDb.DDD.Core
{
    /// <summary>
    /// Publishes domain event
    /// </summary>
    public interface IPublishDomainEvent
    {
        Task Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
    }
}
