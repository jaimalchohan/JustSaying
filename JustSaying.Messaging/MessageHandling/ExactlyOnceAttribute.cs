﻿using System;

namespace JustSaying.Messaging.MessageHandling
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExactlyOnceAttribute : Attribute{ }
}