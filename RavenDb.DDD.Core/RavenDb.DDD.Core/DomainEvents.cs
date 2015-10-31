using System;
using System.Threading.Tasks;

namespace RavenDb.DDD.Core
{
    /// <summary>
    /// Statically access Domain event subsystem
    /// </summary>
    public class DomainEvents
    {
        private static IPublishDomainEvent _current = new ThrowingDomainService();

        public static IPublishDomainEvent Current
        {
            get { return _current; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Cannot set current event publisher to null");

                _current = value;
            }
        }

        public static Task Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
        {
            return Current.Publish(domainEvent);
        }
    }
}