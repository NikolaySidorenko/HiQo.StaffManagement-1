using System;
using HiQo.StaffManagement.Settings;

namespace HiQo.StaffManagement.Core.RequestProvider
{
    public class RequestIdProvider : IRequestIdProvider 
    {
        private Lazy<Guid> _requestId;

        public Guid GetRequestId()
        {
            if (_requestId == null || _requestId.IsValueCreated == false)
            {
                _requestId = new Lazy<Guid>(Guid.NewGuid);
            }

            return _requestId.Value;
        }
    }
}
