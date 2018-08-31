using System;
using System.Runtime.Serialization;

namespace HiQo.StaffManagement.DAL.Exceptions
{
    public class SaveChangesException : Exception
    {
        public SaveChangesException()
        {
        }

        public SaveChangesException(string message) : base(message)
        {
        }

        public SaveChangesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaveChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
