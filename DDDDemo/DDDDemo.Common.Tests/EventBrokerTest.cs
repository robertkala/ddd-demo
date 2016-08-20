using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.Common.Tests.Helpers;
using NSubstitute;
using NUnit.Framework;

namespace DDDDemo.Common.Tests
{
    [TestFixture]
    public class EventBrokerTest
    {
        private readonly Func<Type, object> _substituteCreatorFunction = type => Substitute.For(new[] { type }, new object[] { });

        [Test]
        public void CheckIfEventIsSameTypeForPublishAndSubscribe()
        {
            var objectsCreator = ObjectCreator.CreateNew(_substituteCreatorFunction);
            var eventBroker = new EventBrokerInProc(objectsCreator.InstanceCreatorFunction);

            eventBroker.SubscribeHandler<IEventHandler<TestEvent1>>();
            var testEven1 = new TestEvent1(new Random().Next());
            eventBroker.Publish(testEven1);

            Assert.AreEqual(objectsCreator.CreatedInstances.Count, 1);
            objectsCreator.CreatedInstances.Cast<IEventHandler<TestEvent1>>().Single().Received(1).Handle(testEven1);
        }
        [Test]
        public void CheckIfEventIsNotSameTypeForPublishAndSubscribe()
        {
            var objectsCreator = ObjectCreator.CreateNew(_substituteCreatorFunction);
            var eventBroker = new EventBrokerInProc(objectsCreator.InstanceCreatorFunction);

            eventBroker.SubscribeHandler<IEventHandler<TestEvent1>>();
            var testEven2 = new TestEvent2(new Random().Next());
            eventBroker.Publish(testEven2);

            Assert.AreEqual(objectsCreator.CreatedInstances.Count, 0);
        }
    }
}
