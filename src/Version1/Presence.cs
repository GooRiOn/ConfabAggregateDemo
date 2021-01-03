using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregateDemo.Version1
{
    public class Presence
    {
        public Guid Id { get; init; }
        public ISet<PresenceSlot> Slots => _slots;

        private readonly HashSet<PresenceSlot> _slots = new HashSet<PresenceSlot>();
        private readonly ICapacityPolicy _capacityPolicy;

        public Presence(Guid id, ICapacityPolicy capacityPolicy)
        {
            Id = id;
            _capacityPolicy = capacityPolicy;
        }

        public void AddSlot(PresenceSlot slot)
        {
            var isCollidingTalkForParticipant = _slots.Any(s => 
                s.participantId == slot.participantId && s.talkTime.TimeOfDay == slot.talkTime.TimeOfDay);

            if (isCollidingTalkForParticipant)
            {
                throw new Exception("Participant already have talk in the same time");
            }

            var capacityForTalk = _capacityPolicy.GetCapacity(slot.talkId);

            if (capacityForTalk is not null)
            {
                var allParticipants = _slots.Count(s => s.talkId == slot.talkId);

                if (capacityForTalk <= allParticipants)
                {
                    throw new Exception("Too many participants");
                }
            }

            _slots.Add(slot);
        }
        
    }
}