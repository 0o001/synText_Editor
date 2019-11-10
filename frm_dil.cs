using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace synText_Editor
{
    public partial class frm_dil : Form
    {
        public frm_dil()
        {
            InitializeComponent();
        }

        private void pcr_kelimeRenk_Click(object sender, EventArgs e)
        {
            if(clr_kelime.ShowDialog() == DialogResult.OK)
            {
                (sender as PictureBox).BackColor = clr_kelime.Color;
            }
        }

        private void btn_disaAktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd_kaydet = new SaveFileDialog();
            sfd_kaydet.Filter = "*.xml|*.xml";
            if (sfd_kaydet.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xmlOlustur = new XmlTextWriter(sfd_kaydet.FileName, UTF8Encoding.UTF8);
                xmlOlustur.Formatting = Formatting.Indented;
                try
                {
                    xmlOlustur.WriteStartDocument();
                    xmlOlustur.WriteComment("synText Dil Dosyası");
                    xmlOlustur.WriteStartElement("syntax");
                    if (string.IsNullOrEmpty(txt_kelimeler.Text))
                        xmlOlustur.WriteElementString("keywords", " ");
                    else
                        xmlOlustur.WriteElementString("keywords", txt_kelimeler.Text);
                    xmlOlustur.WriteElementString("keywordColor", pcr_kelimeRenk.BackColor.R + ", " + pcr_kelimeRenk.BackColor.G + ", " + pcr_kelimeRenk.BackColor.B);
                    if (string.IsNullOrEmpty(txt_kisa.Text))
                        xmlOlustur.WriteElementString("comment", " ");
                    else
                        xmlOlustur.WriteElementString("comment", txt_kisa.Text);
                    if (string.IsNullOrEmpty(txt_uzun.Text))
                        xmlOlustur.WriteElementString("longComment", " ");
                    else
                        xmlOlustur.WriteElementString("longComment", txt_uzun.Text);
                    xmlOlustur.WriteElementString("commentColor", pcr_yorum.BackColor.R + ", " + pcr_yorum.BackColor.G + ", " + pcr_yorum.BackColor.B);
                    xmlOlustur.WriteElementString("stringEnable", chk_tirnak.Checked.ToString());
                    xmlOlustur.WriteElementString("stringColor", pcr_yazi.BackColor.R + ", " + pcr_yazi.BackColor.G + ", " + pcr_yazi.BackColor.B);
                    xmlOlustur.WriteElementString("integerEnable", chk_sayi.Checked.ToString());
                    xmlOlustur.WriteElementString("integerColor", pcr_sayi.BackColor.R + ", " + pcr_sayi.BackColor.G + ", " + pcr_sayi.BackColor.B);
                    xmlOlustur.WriteElementString("ingoreCaseKeywords", chk_kucukBuyuk.Checked.ToString());
                    xmlOlustur.WriteEndElement();
                    xmlOlustur.Close();
                    MessageBox.Show("Dil Başarılı Bir Şekilde Oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Dil Oluşturulma Sırasında Bir Hata Oluştu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_iceAktar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf_ac = new OpenFileDialog();
            opf_ac.Filter = "*.xml|*.xml";
            if(opf_ac.ShowDialog() == DialogResult.OK)
            {
                XmlTextReader oku = new XmlTextReader(opf_ac.FileName);
                try
                {
                    while (oku.Read())
                    {
                        if (oku.NodeType == XmlNodeType.Element)
                        {
                            switch (oku.Name)
                            {
                                case "keywords":
                                    txt_kelimeler.Text = oku.ReadString();
                                    break;
                                case "keywordColor":
                                    string[] keywordRenk = oku.ReadString().Split(',');
                                    pcr_kelimeRenk.BackColor = Color.FromArgb(int.Parse(keywordRenk[0]), int.Parse(keywordRenk[1]), int.Parse(keywordRenk[2]));
                                    break;
                                case "comment":
                                    txt_kisa.Text = oku.ReadString();
                                    break;
                                case "longComment":
                                    txt_uzun.Text = oku.ReadString();
                                    break;
                                case "commentColor":
                                    string[] commentRenk = oku.ReadString().Split(',');
                                    pcr_yorum.BackColor = Color.FromArgb(int.Parse(commentRenk[0]), int.Parse(commentRenk[1]), int.Parse(commentRenk[2]));
                                    break;
                                case "stringEnable":
                                    chk_tirnak.Checked = Convert.ToBoolean(oku.ReadString());
                                    break;
                                case "stringColor":
                                    string[] stringRenk = oku.ReadString().Split(',');
                                    pcr_yazi.BackColor = Color.FromArgb(int.Parse(stringRenk[0]), int.Parse(stringRenk[1]), int.Parse(stringRenk[2]));
                                    break;
                                case "integerEnable":
                                    chk_sayi.Checked = Convert.ToBoolean(oku.ReadString());
                                    break;
                                case "integerColor":
                                    string[] integerRenk = oku.ReadString().Split(',');
                                    pcr_sayi.BackColor = Color.FromArgb(int.Parse(integerRenk[0]), int.Parse(integerRenk[1]), int.Parse(integerRenk[2]));
                                    break;
                                case "ingoreCaseKeywords":
                                    chk_kucukBuyuk.Checked = Convert.ToBoolean(oku.ReadString());
                                    break;
                            }
                        }
                    }
                    oku.Close();
                }
                catch
                {
                    MessageBox.Show("Dil Okuma Sırasında Bir Hata Oluştu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
