namespace RavenDb.DDD.Core
{
    /// <summary>
    /// Publishes domain event
    /// </summary>
    public interface IPublishDomainEvent
    {
        void Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
    }
}
