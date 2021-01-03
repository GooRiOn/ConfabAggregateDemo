using System;
using System.Collections.Generic;
using System.Linq;

namespace AggregateDemo.Version2
{
    public class PresentationsSlot
    {
        public Guid Id { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }

        public IEnumerable<Presentation> Presentations => _presentations;

        private readonly HashSet<Presentation> _presentations = new HashSet<Presentation>();
        private readonly ICapacityPolicy _capacityPolicy;

        public PresentationsSlot(Guid id, DateTime startTime, DateTime endTime, ICapacityPolicy capacityPolicy)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            _capacityPolicy = capacityPolicy;
        }

        public void AddPresentation(Guid presentationId)
            => _presentations.Add(new Presentation(presentationId));

        public void AddParticipantToPresentation(Guid presentationId, Guid participantId, string participantEmail)
        {
            var presentation = _presentations.FirstOrDefault(p => p.Id == presentationId);

            if (presentation is null)
            {
                throw new Exception("No presentation found");
            }
            
            var hasCollidingPresentation = _presentations.Any(p => p.Participants.Any(pa => pa.Id == participantId));

            if (hasCollidingPresentation)
            {
                throw new Exception("Colliding presentation");
            }

            var capacity = _capacityPolicy.GetCapacity(presentationId);

            if (presentation.ParticipantsNumber + 1 > capacity)
            {
                throw new Exception("Maximum capacity reached");
            }
            
            presentation.AddParticipant(new Participant(participantId, participantEmail));
        }
    }
}