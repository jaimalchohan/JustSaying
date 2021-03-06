﻿using JustSaying.AwsTools.QueueCreation;
using NUnit.Framework;

namespace JustSaying.AwsTools.IntegrationTests
{
    public class WhenUpdatingRedrivePolicy : WhenCreatingQueuesByName
    {
        private int _oldMaximumReceives;
        private int _newMaximumReceived;

        protected override void Given()
        {
            _oldMaximumReceives = 1;
            _newMaximumReceived = 2;

            base.Given();
        }

        protected override void When()
        {

            SystemUnderTest.Create(60, attempt: 0, visibilityTimeoutSeconds: 30, createErrorQueue: false, retryCountBeforeSendingToErrorQueue: _oldMaximumReceives);

            SystemUnderTest.UpdateRedrivePolicy(new RedrivePolicy(_newMaximumReceived, SystemUnderTest.ErrorQueue.Arn));
        }

        [Test]
        public void TheRedrivePolicyIsUpdatedWithTheNewValue()
        {
            Assert.AreEqual(_newMaximumReceived, SystemUnderTest.RedrivePolicy.MaximumReceives);
        }
    }
}