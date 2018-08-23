using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
