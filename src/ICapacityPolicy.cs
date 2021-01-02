using System;

namespace AggregateDemo
{
    public interface ICapacityPolicy
    {
        int? GetCapacity(Guid talkId);
    }
}