﻿using JustBehave;
using NUnit.Framework;
using JustSaying.TestingFramework;

namespace JustSaying.AwsTools.IntegrationTests
{
    public class WhenICreateAQueueByName : WhenCreatingQueuesByName
    {
        private bool _isQueueCreated;

        protected override void When()
        {
            _isQueueCreated = SystemUnderTest.Create(60, attempt: 0, visibilityTimeoutSeconds: 30);
        }

        [Then]
        public void TheQueueISCreated()
        {
            Assert.IsTrue(_isQueueCreated);
        }

        [Then, Explicit("Extremely long running test")]
        public void DeadLetterQueueIsCreated()
        {
            Patiently.AssertThat(() => SystemUnderTest.ErrorQueue.Exists(), 40.Seconds());
        }
    }
}