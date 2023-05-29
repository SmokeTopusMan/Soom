using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soom_server
{
    internal class AlreadyFriendException : Exception
    {
        public AlreadyFriendException() : base() { }
    }
}
