using System;
using System.Runtime.Serialization;

namespace RavenDb.DDD.Core
{
    [Serializable]
    public class DomainException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
