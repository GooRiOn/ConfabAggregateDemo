using System;
using System.Collections.Generic;

namespace AggregateDemo.Version2
{
    public class Presentation
    {
        public Guid Id { get; init; }
        public IEnumerable<Participant> Participants => _participants;
        public int ParticipantsNumber => _participants.Count;

        private readonly HashSet<Participant> _participants = new();

        public Presentation(Guid id)
            => Id = id;

        public void AddParticipant(Participant participant)
            => _participants.Add(participant);
    }
}