using System;

namespace AggregateDemo
{
    public record PresenceSlot(Guid talkId, Guid participantId, DateTime talkTime);
}