using System;

namespace AggregateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var participant1Id = Guid.NewGuid();
            var participant2Id = Guid.NewGuid();
            var participant3Id = Guid.NewGuid();
            var participant4Id = Guid.NewGuid();
            var participant5Id = Guid.NewGuid();
            var participant6Id = Guid.NewGuid();
            
            var talk1Id = Guid.NewGuid();
            var talk2Id = Guid.NewGuid();

            var talk1Time = new DateTime(2021, 1, 1, 13, 0, 0);
            var talk2Time = new DateTime(2021, 1, 1, 13, 0, 0);

            var slot1 = new PresenceSlot(talk1Id, participant1Id, talk1Time);
            var slot2 = new PresenceSlot(talk1Id, participant2Id, talk1Time);
            var slot3 = new PresenceSlot(talk1Id, participant3Id, talk1Time);
            var slot4 = new PresenceSlot(talk1Id, participant4Id, talk1Time);
            var slot5 = new PresenceSlot(talk1Id, participant5Id, talk1Time);
            var slot6 = new PresenceSlot(talk1Id, participant6Id, talk1Time);

            var presenceSlot = new PresenceSlot(talk2Id, participant1Id, talk2Time);

            var presence = new Presence(Guid.NewGuid(), new DummyPolicy());
            
            presence.AddSlot(slot1);
            presence.AddSlot(presenceSlot);
            
            presence.AddSlot(slot2);
            presence.AddSlot(slot3);
            presence.AddSlot(slot4);
            presence.AddSlot(slot5);
            presence.AddSlot(slot6);
        }
    }
}