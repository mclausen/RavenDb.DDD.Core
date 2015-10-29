﻿using System;

namespace RavenDb.DDD.Core
{
    /// <summary>
    /// Default throwing domain service
    /// </summary>
    public class ThrowingDomainService : ILoadAggregateRoot, IPublishDomainEvent
    {
        public TAggregateRoot LoadAggregateRoot<TAggregateRoot>(string aggregateRootId) where TAggregateRoot : AggregateRoot
        {
            throw new InvalidOperationException($"Tried to load {aggregateRootId}, but no {typeof(ILoadAggregateRoot).Name} was installed");
        }

        public void Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
        {
            throw new InvalidOperationException($"Could not publish {domainEvent.GetType().Name}, but no {typeof(IPublishDomainEvent)} was installed");
        }
    }
}
