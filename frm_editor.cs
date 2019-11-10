using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TheCodeKing.ActiveButtons.Controls;

namespace synText_Editor
{
    public partial class frm_editor : Form
    {
        SyntaxRichTextBox srt_ac;
        public frm_editor()
        {
            InitializeComponent();
            srt_ac = new SyntaxRichTextBox();
            YeniSekme(null, null);
            colorTabControl1.AllowDrop = true;
            colorTabControl1.DragEnter += new DragEventHandler(colorTabControl1_DragEnter);
            colorTabControl1.DragDrop += new DragEventHandler(colorTabControl1_DragDrop);
        }
        private void colorTabControl1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void colorTabControl1_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string File in FileList)
            {
                try
                {
                    YeniSekme(sender, e);
                    (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).LoadFile(File, RichTextBoxStreamType.PlainText);
                    //(colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox)
                    string baslik = File.Split('\\')[File.Split('\\').Length - 1];
                    if (baslik.Length > 15)
                        baslik = baslik.Substring(0, 15) + "...";
                    (colorTabControl1.SelectedTab.ToolTipText) = File;
                    this.Text = "SynText - " + colorTabControl1.SelectedTab.ToolTipText;
                    (colorTabControl1.SelectedTab.Text) = baslik;
                }
                catch
                {

                }
            }

        }
        private void frm_editor_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("language"))
            {
                DirectoryInfo klasor = new DirectoryInfo("language");
                //FileInfo tipinden bir değişken oluşturuyoruz.
                //çünkü di.GetFiles methodu, bize FileInfo tipinden bir dizi dönüyor.
                FileInfo[] dosyalar = klasor.GetFiles("*.xml");
                //foreach döngümüzle fgFiles içinde dönüyoruz.
                foreach (FileInfo dosyaBilgi in dosyalar)
                {
                    //fi.Name bize dosyanın adını dönüyor.
                    //fi.FullName ise bize dosyasının dizin bilgisini döner.
                    var item = cms_diller.Items.Add(dosyaBilgi.Name.Substring(0, dosyaBilgi.Name.LastIndexOf('.')));
                    item.Click += delegate
                    {
                        XmlTextReader oku = new XmlTextReader(dosyaBilgi.FullName);
                        try
                        {
                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
                            while (oku.Read()) //Dosyadaki veriler tükenene kadar okuma işlemi devam eder.
                            {
                                if (oku.NodeType == XmlNodeType.Element)//Düğümlerdeki veri element türünde ise okuma gerçekleşir.
                                {
                                    switch (oku.Name)//Elementlerin isimlerine göre okuma işlemi gerçekleşir.
                                    {
                                        case "keywords":
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).m_strKeywords = "";
                                            plainToolStripMenuItem_Click(sender, e);
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.Keywords.Clear();
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.Keywords.AddRange(oku.ReadString().Trim().Split(','));
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).CompileKeywords();
                                            break;
                                        case "keywordColor":
                                            string[] keywordRenk = oku.ReadString().Split(',');
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.KeywordColor = Color.FromArgb(int.Parse(keywordRenk[0]), int.Parse(keywordRenk[1]), int.Parse(keywordRenk[2]));
                                            break;
                                        case "comment":
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableComments = true;
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.Comment = oku.ReadString();
                                            break;
                                        case "commentColor":
                                            string[] commentRenk = oku.ReadString().Split(',');
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.CommentColor = Color.FromArgb(int.Parse(commentRenk[0]), int.Parse(commentRenk[1]), int.Parse(commentRenk[2]));
                                            break;
                                        case "longComment":
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.LongComment = oku.ReadString();
                                            break;
                                        case "stringEnable":
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableStrings = Convert.ToBoolean(oku.ReadString().Trim());
                                            break;
                                        case "stringColor":
                                            string[] stringRenk = oku.ReadString().Split(',');
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.StringColor = Color.FromArgb(int.Parse(stringRenk[0]), int.Parse(stringRenk[1]), int.Parse(stringRenk[2]));
                                            break;
                                        case "integerEnable":
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableIntegers = Convert.ToBoolean(oku.ReadString().Trim());
                                            break;
                                        case "integerColor":
                                            string[] integerRenk = oku.ReadString().Split(',');
                                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.IntegerColor = Color.FromArgb(int.Parse(integerRenk[0]), int.Parse(integerRenk[1]), int.Parse(integerRenk[2]));
                                            break;
                                        case "ingoreCaseKeywords":
                                            if (Convert.ToBoolean(oku.ReadString()))
                                                (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.RgxKeywords = System.Text.RegularExpressions.RegexOptions.IgnoreCase;
                                            else
                                                (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.RgxKeywords = System.Text.RegularExpressions.RegexOptions.None;
                                            break;
                                    }
                                }
                            }

                            oku.Close();

                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Text += "";
                            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xml Bağlantı Hatası : " + ex.Message);
                            plainToolStripMenuItem_Click(sender, e);
                        }
                    };
                }
                cms_diller.Items.Add("-");
                var dil = cms_diller.Items.Add("Dil Oluştur");
                dil.Click += delegate
                {
                    frm_dil ac = new frm_dil();
                    ac.StartPosition = FormStartPosition.CenterParent;
                    ac.ShowDialog();
                };
            }
        }

        private void colorTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ColorTabControl)sender).TabPages.Count == 0) this.Close(); // eğer bir tane sekme varsa sekme çarpısına formu kapatma işlemi
            try
            {
                if (!string.IsNullOrEmpty(colorTabControl1.SelectedTab.ToolTipText))
                    this.Text = "SynText - " + colorTabControl1.SelectedTab.ToolTipText;
                else
                    this.Text = "SynText";
            }
            catch
            {

            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EkleButon("+", YeniSekme, "Yeni Sekme", new Font("symbol", 15, FontStyle.Regular), FlatStyle.Flat, Color.FromKnownColor(KnownColor.Control));
            EkleButon("Yardım", Yardim, "Yardım", new Font("arial", 8, FontStyle.Regular), FlatStyle.Flat, Color.WhiteSmoke);
            //EkleButon("Ara", Dosya, "Dosya Aç", new Font("arial", 8, FontStyle.Regular), FlatStyle.Flat, Color.WhiteSmoke);
            EkleButon("Diller", Diller, "Diller", new Font("arial", 8, FontStyle.Regular), FlatStyle.Flat, Color.WhiteSmoke);
            EkleButon("Düzen", Duzen, "Düzen", new Font("arial", 8, FontStyle.Regular), FlatStyle.Flat, Color.WhiteSmoke);
            EkleButon("Dosya", Dosya, "Dosya", new Font("arial", 8, FontStyle.Regular), FlatStyle.Flat, Color.WhiteSmoke);
        }
        private void Dosya(object sender, EventArgs e)
        {
            cms_dosya.Show((sender as Button).Parent.Location.X, (sender as Button).Parent.Location.Y + (sender as Button).Parent.Height);
            //(sender as Button).Parent.Location.X, (sender as Button).Parent.Location.Y + (sender as Button).Parent.Height
        }
        private void Duzen(object sender, EventArgs e)
        {
            cms_duzen.Show((sender as Button).Parent.Location.X, (sender as Button).Parent.Location.Y + (sender as Button).Parent.Height);
        }
        private void Yardim(object sender, EventArgs e)
        {
            cms_yardim.Show((sender as Button).Parent.Location.X, (sender as Button).Parent.Location.Y + (sender as Button).Parent.Height);
        }
        private void Diller(object sender, EventArgs e)
        {
            cms_diller.Show((sender as Button).Parent.Location.X, (sender as Button).Parent.Location.Y + (sender as Button).Parent.Height);
        }
        public void YeniSekme(object sender, EventArgs e)
        {
            TabPage sayfa = new TabPage();
            sayfa.Text = "Yeni Sekme";
            sayfa.ForeColor = Color.White;
            srt_ac = new SyntaxRichTextBox();
            srt_ac.Dock = DockStyle.Fill;
            srt_ac.BorderStyle = BorderStyle.None;
            srt_ac.ScrollBars = RichTextBoxScrollBars.Both;
            srt_ac.WordWrap = false;
            srt_ac.ForeColor = Color.White;
            srt_ac.BackColor = Color.FromArgb(30, 30, 30);
            srt_ac.Settings.Keywords.Clear();
            srt_ac.Settings.KeywordColor = Color.White;
            srt_ac.Settings.Keywords.AddRange(new string[] { "null" });
            srt_ac.Settings.Comment = "";
            srt_ac.Settings.EnableStrings = false;
            srt_ac.Settings.EnableIntegers = false;
            srt_ac.AcceptsTab = true;
            srt_ac.MouseDown += delegate (object sender2, MouseEventArgs ev)
            {
                if (ev.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                    
                    MenuItem menuItem = new MenuItem("Kes");
                    menuItem.Click += delegate
                    {
                        try
                        {
                            srt_ac.Cut();
                        }
                        catch { }
                    };
                    contextMenu.MenuItems.Add(menuItem);
                    menuItem = new MenuItem("Kopyala");
                    menuItem.Click += delegate
                    {
                        try
                        {
                            Clipboard.SetText(srt_ac.SelectedText);
                        }
                        catch { }
                    };
                    contextMenu.MenuItems.Add(menuItem);
                    menuItem = new MenuItem("Yapıştır");
                    menuItem.Click += delegate
                    {
                        if (Clipboard.ContainsText())
                        {
                            srt_ac.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
                        }
                    };
                    contextMenu.MenuItems.Add(menuItem);
                    menuItem = new MenuItem("Hepsini Seç");
                    menuItem.Click += delegate
                    {
                        try
                        {
                            srt_ac.SelectAll();
                            srt_ac.Focus();
                        }
                        catch { }
                    };
                    contextMenu.MenuItems.Add(menuItem);
                    srt_ac.ContextMenu = contextMenu;
                }
            };
            srt_ac.KeyPress += delegate (object sender2, KeyPressEventArgs ev) {
                if (ev.KeyChar == 9)
                {
                    ev.Handled = false;
                }
            };
            srt_ac.CompileKeywords();
            sayfa.Controls.Add(srt_ac);//pagevievpagede usercontrolü aç
            colorTabControl1.Controls.Add(sayfa);//sekme olarak ekler
            colorTabControl1.SelectedTab = sayfa; //yeni sekme açıldığında aktif sayfa ol
        }
        int bos = 0;
        private void EkleButon(string yazi, EventHandler handler, string aciklama, Font fnt, FlatStyle flt, Color clr) //Yeni sekme + butonu oluşturmak
        {
            IActiveMenu menu = ActiveMenu.GetInstance(this);
            if (bos == 0)
            {
                ActiveButton btn = new ActiveButton();
                btn.Text = null;
                btn.Dock = DockStyle.Fill;
                btn.Visible = false;
                menu.Items.Add(btn);
                bos++;
            }
            ActiveButton button = new ActiveButton();
            button.Text = yazi;
            button.Font = fnt;//new Font("symbol", 12, FontStyle.Regular);
            button.Cursor = Cursors.Hand;
            if (button.Text == "")
                // button.Image = Properties.Resources.search_13_16;
                button.ForeColor = Color.Black;
            button.BackColor = clr;
            button.FlatStyle = flt;
            button.FlatAppearance.BorderSize = 0;
            //button.FlatAppearance.BorderColor = Color.FromArgb(30,30,30);
            //button.Image = Properties.Resources.ekle;
            menu.ToolTip.SetToolTip(button, aciklama);
            button.Click += handler;
            // = ContentAlignment.TopLeft;
            //button.Image = Properties.Resources.ekle;
            menu.Items.Add(button);
            if (bos == 1)
            {
                ActiveButton btn = new ActiveButton();
                btn.Text = null;
                btn.Dock = DockStyle.Fill;
                btn.Visible = false;
                menu.Items.Add(btn);
                bos++;
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
            catch
            {

            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd_ac = new OpenFileDialog();
            if (ofd_ac.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).LoadFile(ofd_ac.FileName, RichTextBoxStreamType.PlainText);
                    //(colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox)
                    string baslik = ofd_ac.FileName.Split('\\')[ofd_ac.FileName.Split('\\').Length - 1];
                    if (baslik.Length > 15)
                        baslik = baslik.Substring(0, 15) + "...";
                    (colorTabControl1.SelectedTab.ToolTipText) = ofd_ac.FileName;
                    this.Text = "SynText - " + colorTabControl1.SelectedTab.ToolTipText;
                    (colorTabControl1.SelectedTab.Text) = baslik;
                }
                catch
                {
                    MessageBox.Show("Dosya açılırken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_kaydet = new SaveFileDialog();
            if (!string.IsNullOrEmpty(colorTabControl1.SelectedTab.ToolTipText))
            {
                (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).SaveFile(colorTabControl1.SelectedTab.ToolTipText, RichTextBoxStreamType.PlainText);
                this.Text = "SynText" + " - " + sfd_kaydet.FileName;
            }
            else
            {
                if (sfd_kaydet.ShowDialog() == DialogResult.OK)
                {
                    (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).SaveFile(sfd_kaydet.FileName, RichTextBoxStreamType.PlainText);
                    (colorTabControl1.SelectedTab.ToolTipText) = sfd_kaydet.FileName;
                    this.Text = "SynText" + " - " + sfd_kaydet.FileName;
                }

            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Paste();
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ara.rtb = (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox);
            frm_ara frmAra = new frm_ara();
            frmAra.Show();
        }

        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_degistir.rtb = (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox);
            frm_degistir frmDegistir = new frm_degistir();
            frmDegistir.Show();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).SelectAll();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Undo();
        }

        private void plainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.KeywordColor = Color.White;
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.Keywords.Clear();
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.Comment = "";
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.LongComment = "";
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableComments = false;
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableStrings = false;
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Settings.EnableIntegers = false;
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).CompileKeywords();
            //(this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).AppendText("\n");
            (this.colorTabControl1.SelectedTab.Controls[0] as SyntaxRichTextBox).Text += "";
        }

        private void frm_editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O && e.Control)
            {
                açToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.N && e.Control)
                yeniToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.S && e.Control)
                kaydetToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.F4 && e.Alt)
                çıkışToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.F && e.Control)
                bulToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.H && e.Control)
                değiştirToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
            {

            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_hakkinda ac = new frm_hakkinda();
            ac.ShowDialog();
        }

        private void frm_editor_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && e.Modifiers == (Keys.Control))
            {
                colorTabControl1.SelectedTab.Dispose();
            }
            if (e.KeyCode == Keys.T && e.Modifiers == (Keys.Control))
            {
                YeniSekme(sender, e);
            }
        }
    }
}
