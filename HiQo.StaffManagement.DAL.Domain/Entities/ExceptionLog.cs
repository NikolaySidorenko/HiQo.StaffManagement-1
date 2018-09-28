using System;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class ExceptionLog
    {
        public int ExceptionLogId { get; set; }
        public Guid LogId { get; set; }
        public DateTime Time { get; set; }
        public string Url { get; set; }
        public string ExceptionClass { get; set; }
        public string Message { get; set; }
    }
}
