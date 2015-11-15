#RavenDb.DDD.Core

This project contains core classes and domain services to quickly start modelling your domain

* `AggregateRoot`
* `Reference`
* `DomainException`
* `Primitives`
* `Extensions`

#Setting up AggregateRootLoader

*step 1. Implement `ILoadAggregateRoot`
	class MyAggregateRootLoader : ILoadAggregateRoot 
	{
		public Task<TAggregateRoot> LoadAggregateRootAsync<TAggregateRoot>(string aggregateRootId)
		{
			var currentSession = ... (get current session);
			await currentSettion.LoadAsync<TAggregateRoot>(aggregateRootId);
		}
	}

*step 2. Set static `AggregateRootLoader`

	AggregateRootLoader.Current = new MyAggregateRootLoader(...)

#Setting up DomainEvents
Domain events are base upon Udi Dahans [Domain Events](http://udidahan.com/2009/06/14/domain-events-salvation/).

In order to support these event types a `IPublishDomainEvent` must be configured. This can be done by using your favorite IOC Container.
Here is an example using CastleWindsor

*Step 1. Register 'ISubscribeTo' classes

	container.Register(Classes.FromAssembly(...)
		.BasedOn(typeof(ISubscribeTo<>)
		.WithServiceAllInterfaces()
		.LifeStyleTransient())

*Step 2. Event publishing

	class MyEventPublisher : IPublishDomainEvent
	{
		IContainer container;

		public async Task Publish<TDomainEvent>(TDomainEvent domainEvent)
		{
			var handlers = container.ResolveAll<ISubscribeTo<TDomainEvent>>();
			foreach (var handler in handlers)
			{
				await handler.Handle(domainEvent);
				
				container.release(handler);
			}
		}
	}

*Step 3. Set static DomainEvents
	
	DomainEvents.Current = new MyEventPublisher(container);

#Reference
`Reference` is use to store a path to another aggregate root

#DomainException
Domain exceptions should be used whenever a business rule is violated. An example of this could be, that in a context of a trading application the user should not be allowed to create a trade within 24 before delivery and thus a `DomainException` should be thrown.

#Primitives
The primitives namespace contains generic value objects, which can be used to model your domain.

#Extensions
The Extensions namespace contains generic extension methods
