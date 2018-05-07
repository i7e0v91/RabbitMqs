using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public static class Protocol
    {
        public static byte[] FormatBody(string message)
        {
            if (message == null)
                return new byte[0];
            return System.Text.Encoding.UTF8.GetBytes(message);
        }

        public static string ParseBody(byte[] body)
        {
            if (body == null || body.Length == 0)
                return string.Empty;
            return System.Text.Encoding.UTF8.GetString(body);
        }
    }
}
