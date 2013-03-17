using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Forms;
using KeePass.Resources;

using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Collections;
using KeePass.Ecas;
using System.Collections.Specialized;
using System.Configuration;
using BookmarkletPlugin.Properties;

// The namespace name must be the same as the filename of the
// plugin without its extension.
// For example, if you compile a plugin 'SamplePlugin.dll', the
// namespace must be named 'SamplePlugin'.
namespace BookmarkletPlugin
{
	/// <summary>
	/// This is the main plugin class. It must be named exactly
	/// like the namespace and must be derived from
	/// <c>KeePassPlugin</c>.
	/// </summary>
    public sealed class BookmarkletPluginExt : Plugin
	{
		// The sample plugin remembers its host in this variable.
		private IPluginHost _host = null;
        private int _port;
        private Server _server = null;
        private ToolStripSeparator _tsmiSep1;
        private ToolStripMenuItem _tsmiSettings;
        private ToolStripMenuItem _tsmiCreateBookmarklet;

		/// <summary>
		/// The <c>Initialize</c> function is called by KeePass when
		/// you should initialize your plugin (create menu items, etc.).
		/// </summary>
		/// <param name="host">Plugin host interface. By using this
		/// interface, you can access the KeePass main window and the
		/// currently opened database.</param>
		/// <returns>You must return <c>true</c> in order to signal
		/// successful initialization. If you return <c>false</c>,
		/// KeePass unloads your plugin (without calling the
		/// <c>Terminate</c> function of your plugin).</returns>
		public override bool Initialize(IPluginHost host)
		{
			_host = host;
            _port = (int)Settings.Default["Port"];

            _tsmiSep1 = new ToolStripSeparator();

            _tsmiSettings = new ToolStripMenuItem();
            _tsmiSettings.Text = "Bookmarklet Plugin Settings";
            _tsmiSettings.Click += OnSettingsClick;

            _tsmiCreateBookmarklet = new ToolStripMenuItem();
            _tsmiCreateBookmarklet.Text = "Create Bookmarklet";
            _tsmiCreateBookmarklet.Click += OnCreateBookmarkletClick;

            _host.MainWindow.ToolsMenu.DropDownItems.Add(_tsmiSep1);
            _host.MainWindow.ToolsMenu.DropDownItems.Add(_tsmiSettings);
            _host.MainWindow.ToolsMenu.DropDownItems.Add(_tsmiCreateBookmarklet);

            _server = new Server(_port, _host);
            _server.Start();

			return true; // Initialization successful
		}

		/// <summary>
		/// The <c>Terminate</c> function is called by KeePass when
		/// you should free all resources, close open files/streams,
		/// etc. It is also recommended that you remove all your
		/// plugin menu items from the KeePass menu.
		/// </summary>
		public override void Terminate()
		{
            _server.Stop();

            _host.MainWindow.ToolsMenu.DropDownItems.Remove(_tsmiSep1);
            _host.MainWindow.ToolsMenu.DropDownItems.Remove(_tsmiSettings);
		}


        public void OnSettingsClick(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.txtPort.Text = _port.ToString();

            if (frmSettings.ShowDialog() == DialogResult.OK)
            {
                _server.Stop();

                _port = int.Parse(frmSettings.txtPort.Text);

                Settings.Default["Port"] = _port;
                Settings.Default.Save();

                _server = new Server(_port, _host);
                _server.Start();
            }
        }

        public void OnCreateBookmarkletClick(object sender, EventArgs e)
        {
            Process.Start("http://localhost:" + _port + "/?action=createBookmarklet");
        }
    }
}
