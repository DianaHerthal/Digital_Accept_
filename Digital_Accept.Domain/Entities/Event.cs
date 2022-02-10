namespace Digital_Accept.Domain.Entities
{
    public class Event : BaseEntity
    {
        public Event(string description, EventType eventType)
        {
            EventType = eventType;
            Description = description;
            DateHourEvent = DateTime.Now;
        }

        private Event()
        {
            //Needs for Entity Framework
        }

        public long DocumentId { get; private set; }

        public EventType EventType { get; private set; }

        public string Description { get; private set; }

        public DateTime DateHourEvent { get; private set; }

        public Document Document { get; private set; }
    }
}
