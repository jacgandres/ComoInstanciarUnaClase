using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace MotorReservas.Caching.Caching
{
    [Serializable]
    public class CacheRefreshAction : ICacheItemRefreshAction
    {
        public void Refresh(string key, object expiredValue, CacheItemRemovedReason removalReason)
        {
            // Item has been removed from cache. Perform desired actions here, based upon
            // the removal reason (e.g. refresh the cache with the item).
        }
    }
}
