using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace synText_Editor
{
    public partial class frm_hakkinda : Form
    {
        public frm_hakkinda()
        {
            InitializeComponent();
        }

        private void lnk_ltd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.nullovy.com");
        }
    }
}
