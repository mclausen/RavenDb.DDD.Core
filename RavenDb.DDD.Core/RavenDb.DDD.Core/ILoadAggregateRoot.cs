using System.Threading.Tasks;

namespace RavenDb.DDD.Core
{
    public interface ILoadAggregateRoot
    {
        /// <summary>
        /// Load the aggregateRoot
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="aggregateRootId"></param>
        /// <returns>Instance of <see cref="AggregateRoot"/></returns>
        Task<TAggregateRoot> LoadAggregateRootAsync<TAggregateRoot>(string aggregateRootId) where TAggregateRoot : AggregateRoot;
    }
}
