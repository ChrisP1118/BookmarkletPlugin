using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using KeePass.Plugins;

namespace BookmarkletPlugin
{
    abstract class Action
    {
        protected Server _server;
        protected IPluginHost _host;
        protected HttpListenerContext _listenerContext;
        protected HttpListenerRequest _request;
        protected HttpListenerResponse _response;

        protected StringBuilder _responseString;

        public Action(Server server, HttpListenerContext listenerContext)
        {
            _server = server;
            _host = _server.Host;
            _listenerContext = listenerContext;
            _request = _listenerContext.Request;
            _response = _listenerContext.Response;
            _responseString = new StringBuilder();
        }

        public void SendResponse()
        {
            try
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(_responseString.ToString());
                _response.ContentLength64 = buffer.Length;
                _response.OutputStream.Write(buffer, 0, buffer.Length);
                _response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                // This might fail if the auto type was successful and the browser has already started loading the new page
            }
        }
    }
}
