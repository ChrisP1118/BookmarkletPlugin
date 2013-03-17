using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using KeePassLib;
using KeePass.Plugins;
using System.Globalization;

namespace BookmarkletPlugin
{
    class AutoTypeAction : Action
    {
        private delegate void PerformAutoType(PwEntry pwEntry, PwDatabase pwDatabase);

        public AutoTypeAction(Server server, HttpListenerContext listenerContext)
            : base(server, listenerContext)
        {
            string url = NormalizeURL(HttpUtility.UrlDecode(_request.QueryString["url"] ?? ""));
            string favoredUserName = HttpUtility.UrlDecode(_request.QueryString["favoredUserName"] ?? "").ToLower();

            string actionResult = "Unknown";
            string actionError = "";

            List<PwEntry> entries = new List<PwEntry>();
            if (_host.Database.IsOpen)
            {
                // Find all entries at this domain
                if (url.Length > 0)
                    FindURL(entries, _host.Database.RootGroup, url.ToLower());

                // If there are more than one, check for favored user name
                if (entries.Count > 1 && favoredUserName != "")
                {

                    List<PwEntry> newEntries = new List<PwEntry>();
                    foreach (PwEntry entry in entries)
                        if (entry.Strings.Get(PwDefs.UserNameField).ReadString().ToLower() == favoredUserName)
                            newEntries.Add(entry);

                    if (newEntries.Count > 0)
                        entries = newEntries;
                }
            }
            else
                actionError = "There's no open KeePass database.";

            if (entries.Count == 1)
            {
                PwEntry entry = entries[0];
                //KeePass.Util.AutoType.PerformIntoCurrentWindow(entry, _host.MainWindow.DocumentManager.SafeFindContainerOf(entry));
                _host.MainWindow.Invoke(new PerformAutoType(DoAutoType), new Object[] { entry, _host.Database });

                actionResult = "AutoType";
            }
            else if (entries.Count == 0)
            {
                actionError = "No entry could be found in KeePass that uses this URL or one close to it.";
            }
            else
            {
                actionError = "There are multiple entries in KeePass that use this URL or one close to it.";
            }

            if (actionError != "")
                actionResult = "Error";

            _response.StatusCode = 200;

            _responseString.AppendLine(@"jsonCallback ({");
            _responseString.AppendLine(@"  ""actionResult"": """ + actionResult + @"""");
            if (actionError != "")
                _responseString.AppendLine(@", ""actionError"": """ + actionError + @"""");
            _responseString.AppendLine(@"});");
        }

        private void DoAutoType(PwEntry pwEntry, PwDatabase pwDatabase)
        {
            KeePass.Util.AutoType.PerformIntoCurrentWindow(pwEntry, pwDatabase);
        }

        private void FindURL(List<PwEntry> entries, PwGroup group, string url)
        {
            foreach (PwEntry entry in group.Entries)
            {
                string entryUrl = NormalizeURL(entry.Strings.Get(PwDefs.UrlField).ReadString().ToLower());
                if (entryUrl.Length > 0 && (entryUrl.StartsWith(url) || url.StartsWith(entryUrl)))
                    entries.Add(entry);
            }

            foreach (PwGroup subGroup in group.Groups)
                FindURL(entries, subGroup, url);
        }

        private static string NormalizeURL(string url)
        {
            url = url.ToLower();
            if (url.StartsWith("http://"))
                url = url.Substring(7);
            if (url.StartsWith("https://"))
                url = url.Substring(8);
            if (url.IndexOf("?") > 0)
                url = url.Substring(0, url.IndexOf("?"));

            return url;
        }
    }
}
