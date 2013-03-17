using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using KeePass.Plugins;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Web;
using KeePassLib;
using System.Globalization;

namespace BookmarkletPlugin
{
    public class Server
    {
        private IPluginHost _host;
        private HttpListener _listener;
        private int _port;
        private Thread _clientListenerThread;

        public Server(int port, IPluginHost host)
        {
            _port = port;
            _host = host;
        }

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Start();
            _listener.Prefixes.Add("http://localhost:" + _port.ToString() + "/");

            _clientListenerThread = new Thread(new ThreadStart(ListenForClients));
            _clientListenerThread.Start();
        }

        public void Stop()
        {
            _clientListenerThread.Abort();
            _listener.Abort();
        }

        public void ListenForClients()
        {
            while (true)
            {
                HttpListenerContext request = _listener.GetContext();
                ThreadPool.QueueUserWorkItem(ProcessRequest, request);
            }
        }

        public IPluginHost Host
        {
            get { return _host; }
        }

        public int Port
        {
            get { return _port; }
        }

        public void ProcessRequest(object listenerContextObject)
        {
            HttpListenerContext listenerContext = (HttpListenerContext)listenerContextObject;

            if (!listenerContext.Request.IsLocal)
                return;

            string actionName = HttpUtility.UrlDecode(listenerContext.Request.QueryString["action"]);

            Action action;
            if (actionName == "autoType")
                action = new AutoTypeAction(this, listenerContext);
            else if (actionName == "createBookmarklet")
                action = new CreateBookmarkletAction(this, listenerContext);
            else if (actionName == "viewBookmarklet")
                action = new ViewBookmarkletAction(this, listenerContext);
            else
                action = new UnknownAction(this, listenerContext);

            action.SendResponse();
        }
    }
}
