using NUnit.Framework;
using RavenDb.DDD.Core.Extensions;

namespace RavenDb.DDD.Core.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void ShuffleDoesShuffleCollection()
        {
            var list = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            Assert.That(list, Is.Ordered);

            list.Shuffle();
            Assert.That(list, Is.Not.Ordered);
        }
    }
}
