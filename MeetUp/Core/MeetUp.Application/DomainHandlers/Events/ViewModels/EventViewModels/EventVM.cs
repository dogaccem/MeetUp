namespace MeetUp.Application.DomainHandlers.Events.ViewModels.EventViewModels
{
    public class EventVM
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public int CountAttendees { get; set; }
    }
}
