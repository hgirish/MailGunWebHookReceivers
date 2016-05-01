using System;

namespace GhWebHooks.Models
{
    public class EmailTrackerModel
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
      
        public string Timestamp { get; set; }
        public string EventName { get; set; }
        public string Recipient { get; set; }
        public string MessageHeaders { get; set; }
        public string Domain { get; set; }
        public string MessageId { get; set; }
        public string Myvar1 { get; set; }
        public string Myvar2 { get; set; }
        public string BodyPlain { get; set; }
        public string Code { get; set; }
        public string Error { get; set; }
        public string Notification { get; set; }
        public string Tag { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }

        public EmailTrackerModel()
        {
            Created = DateTime.UtcNow;
        }
    }
}