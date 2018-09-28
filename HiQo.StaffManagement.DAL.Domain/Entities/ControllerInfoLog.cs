using System;

namespace HiQo.StaffManagement.DAL.Domain.Entities
{
    public class ControllerInfoLog
    {
        public int ControllerInfoLogId { get; set; }
        public Guid LogId { get; set; }
        public DateTime Time { get; set; }
        public string Url { get; set; }
        public string Parameters { get; set; }
    }
}
