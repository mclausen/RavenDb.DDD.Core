using System;

namespace RavenDb.DDD.Core
{
    public abstract class AggregateRoot : IEquatable<AggregateRoot>
    {
        public string Id { get; protected set; }
        public bool Equals(AggregateRoot other)
        {
            return other != null
                   && other.GetType() == GetType()
                   && string.Equals(other.Id, Id, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return $"{GetType().Name} # {Id}";
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}
