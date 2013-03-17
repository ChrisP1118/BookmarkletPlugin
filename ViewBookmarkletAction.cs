using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;
using System.Net;
using System.Web;

namespace BookmarkletPlugin
{
    class ViewBookmarkletAction : Action
    {
        public ViewBookmarkletAction(Server server, HttpListenerContext listenerContext)
            : base(server, listenerContext)
        {
            string html = Properties.Resources.ViewBookmarklet;
            string bookmarklet = Properties.Resources.Bookmarklet;

            string name = HttpUtility.UrlDecode(_request.QueryString["name"]);
            string favoredUsername = HttpUtility.UrlDecode(_request.QueryString["favoredUsername"]);

            bookmarklet = bookmarklet.Replace("{port}", _server.Port.ToString()).Replace("{favoredUsername}", favoredUsername).Replace("\r", "").Replace("\n", " ");
            while (bookmarklet.Contains("  "))
                bookmarklet = bookmarklet.Replace("  ", " ");
            bookmarklet = Uri.EscapeDataString(bookmarklet);

            _responseString.AppendLine(html.Replace("{name}", name).Replace("{bookmarklet}", bookmarklet));
        }
    }
}
