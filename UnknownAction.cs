using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;
using System.Net;

namespace BookmarkletPlugin
{
    class UnknownAction : Action
    {
        public UnknownAction(Server server, HttpListenerContext listenerContext)
            : base(server, listenerContext)
        {
            _responseString.AppendLine("Unknown action");
        }
    }
}
