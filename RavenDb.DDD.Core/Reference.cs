using System;
using System.Threading.Tasks;

namespace RavenDb.DDD.Core
{
    public struct Reference<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        public string Id { get; }

        public bool CanLoad { get; }

        private Reference(string aggregateRootId)
        {
            if(string.IsNullOrWhiteSpace(aggregateRootId))
                throw new ArgumentNullException();

            Id = aggregateRootId;
            CanLoad = true;
        }

        public Task<TAggregateRoot> LoadAsync
        {
            get
            {
                if(CanLoad  == false || string.IsNullOrWhiteSpace(Id))
                    throw new InvalidOperationException($"Cannot Load Reference {Id}");

                return AggregateRootLoader.LoadAsync<TAggregateRoot>(Id);
            }
        } 

        public static Reference<TAggregateRoot> Create(TAggregateRoot aggregateRoot)
        {
            if(aggregateRoot == null)
                throw new ArgumentNullException();

            return new Reference<TAggregateRoot>(aggregateRoot.Id);
        }

        public static Reference<TAggregateRoot> Null
        {
            get { return (TAggregateRoot) null; }
        }

        public static implicit operator Reference<TAggregateRoot>(TAggregateRoot aggregateRoot)
        {
            return Create(aggregateRoot);
        }
    }
}
