using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo_raknet.Utils
{
	public static class Utils
	{
		public static ushort UDP_CLIENT_MTU = 1400;

        public static long GetTimeStampLong()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSinceEpoch = DateTime.UtcNow - unixEpoch;
            long milliseconds = (long)timeSinceEpoch.TotalMilliseconds;
            return milliseconds;
        }
	}
}
