﻿using JustSaying.AwsTools.QueueCreation;
using JustBehave;
using NUnit.Framework;
using JustSaying.Lookups;

namespace JustSaying.UnitTests.Lookups.SqsEndpointNames
{
    public class WhenRequestingAnEndpointName : BehaviourTest<SqsSubscribtionEndpointProvider>
    {
        private readonly SqsConfiguration _sqsConfiguration = new SqsConfiguration();

        private string _result;

        protected override SqsSubscribtionEndpointProvider CreateSystemUnderTest()
        {
            return new SqsSubscribtionEndpointProvider(_sqsConfiguration);
        }

        protected override void Given()
        {
            _sqsConfiguration.QueueName = "OrderDispatch";
        }

        protected override void When()
        {
            _result = SystemUnderTest.GetLocationName();
        }

        [Then]
        public void TopicIsReturned()
        {
            Assert.AreEqual("orderdispatch", _result);
        }
    }
}
