﻿using System;
using System.Threading.Tasks;

namespace RavenDb.DDD.Core
{
    public static class AggregateRootLoader
    {
        private static ILoadAggregateRoot _current = new ThrowingDomainService();

        public static ILoadAggregateRoot Current
        {
            get { return _current; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("Cannot set aggregateRootLoader to null");

                _current = value;
            }
        }

        public static Task<TAggregateRoot> LoadAsync<TAggregateRoot>(string aggregateRootId) where TAggregateRoot : AggregateRoot
        {
            return Current.LoadAggregateRootAsync<TAggregateRoot>(aggregateRootId);
        }
    }
}
