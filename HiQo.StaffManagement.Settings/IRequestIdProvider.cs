using System;

namespace HiQo.StaffManagement.Settings
{
    public interface IRequestIdProvider
    {
        Guid GetRequestId();
    }
}
