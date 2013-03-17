using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;
using System.Net;

namespace BookmarkletPlugin
{
    class CreateBookmarkletAction : Action
    {
        public CreateBookmarkletAction(Server server, HttpListenerContext listenerContext)
            : base(server, listenerContext)
        {
            string html = Properties.Resources.CreateBookmarklet;

            _responseString.AppendLine(html.Replace("{action}", "http://localhost:" + _server.Port.ToString() + "/"));
        }
    }
}
