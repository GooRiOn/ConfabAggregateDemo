using System;

namespace AggregateDemo
{
    public class DummyPolicy : ICapacityPolicy
    {
        public int? GetCapacity(Guid talkId) => 5;
    }
}