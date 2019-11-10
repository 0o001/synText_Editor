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
    public partial class frm_ara : Form
    {
        public static SyntaxRichTextBox rtb;
        public frm_ara()
        {
            InitializeComponent();
        }
        private void btn_Ara_Click(object sender, EventArgs e)
        {
            lbl_Sonuc.Text = "Toplam " + rtb.Bul(txt_Ara.Text, Color.FromArgb(251, 192, 49)) + " adet kayıt bulundu.";
        }
        private void Kapat()
        {
            rtb.SelectAll();
            rtb.SelectionBackColor = rtb.BackColor;
            rtb.Select(0, 0);
        }

        private void btn_Iptal_Click(object sender, EventArgs e)
        {
            Kapat(); this.Close();
        }

        private void frm_Bul_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kapat();
        }
    }
}
