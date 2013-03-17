using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookmarkletPlugin
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int port = 0;
            if (!int.TryParse(txtPort.Text, out port) || port == 0 || port >= 65535)
            {
                MessageBox.Show("Invalid port");
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
