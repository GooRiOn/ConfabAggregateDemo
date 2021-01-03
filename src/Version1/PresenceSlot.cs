using System;

namespace AggregateDemo.Version1
{
    public record PresenceSlot(Guid talkId, Guid participantId, DateTime talkTime);
}