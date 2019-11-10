namespace synText_Editor
{
    partial class frm_dil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dil));
            this.btn_iceAktar = new System.Windows.Forms.Button();
            this.btn_disaAktar = new System.Windows.Forms.Button();
            this.clr_kelime = new System.Windows.Forms.ColorDialog();
            this.grp_kelime = new System.Windows.Forms.GroupBox();
            this.lbl_kelimeRenk = new System.Windows.Forms.Label();
            this.pcr_kelimeRenk = new System.Windows.Forms.PictureBox();
            this.txt_kelimeler = new System.Windows.Forms.TextBox();
            this.pcr_yorum = new System.Windows.Forms.PictureBox();
            this.pcr_yazi = new System.Windows.Forms.PictureBox();
            this.lbl_yorum = new System.Windows.Forms.Label();
            this.lbl_tirnak = new System.Windows.Forms.Label();
            this.chk_tirnak = new System.Windows.Forms.CheckBox();
            this.lbl_sayi = new System.Windows.Forms.Label();
            this.pcr_sayi = new System.Windows.Forms.PictureBox();
            this.chk_sayi = new System.Windows.Forms.CheckBox();
            this.grp_yorum = new System.Windows.Forms.GroupBox();
            this.txt_kisa = new System.Windows.Forms.TextBox();
            this.txt_uzun = new System.Windows.Forms.TextBox();
            this.chk_kucukBuyuk = new System.Windows.Forms.CheckBox();
            this.lbl_kisa = new System.Windows.Forms.Label();
            this.lbl_uzun = new System.Windows.Forms.Label();
            this.grp_kelime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_kelimeRenk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_yorum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_yazi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_sayi)).BeginInit();
            this.grp_yorum.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_iceAktar
            // 
            this.btn_iceAktar.Location = new System.Drawing.Point(12, 12);
            this.btn_iceAktar.Name = "btn_iceAktar";
            this.btn_iceAktar.Size = new System.Drawing.Size(75, 23);
            this.btn_iceAktar.TabIndex = 1;
            this.btn_iceAktar.Text = "İçe Aktar";
            this.btn_iceAktar.UseVisualStyleBackColor = true;
            this.btn_iceAktar.Click += new System.EventHandler(this.btn_iceAktar_Click);
            // 
            // btn_disaAktar
            // 
            this.btn_disaAktar.Location = new System.Drawing.Point(93, 12);
            this.btn_disaAktar.Name = "btn_disaAktar";
            this.btn_disaAktar.Size = new System.Drawing.Size(75, 23);
            this.btn_disaAktar.TabIndex = 2;
            this.btn_disaAktar.Text = "Dışa Aktar";
            this.btn_disaAktar.UseVisualStyleBackColor = true;
            this.btn_disaAktar.Click += new System.EventHandler(this.btn_disaAktar_Click);
            // 
            // grp_kelime
            // 
            this.grp_kelime.Controls.Add(this.lbl_kelimeRenk);
            this.grp_kelime.Controls.Add(this.pcr_kelimeRenk);
            this.grp_kelime.Controls.Add(this.txt_kelimeler);
            this.grp_kelime.Location = new System.Drawing.Point(12, 41);
            this.grp_kelime.Name = "grp_kelime";
            this.grp_kelime.Size = new System.Drawing.Size(296, 147);
            this.grp_kelime.TabIndex = 3;
            this.grp_kelime.TabStop = false;
            this.grp_kelime.Text = "Kelimeler";
            // 
            // lbl_kelimeRenk
            // 
            this.lbl_kelimeRenk.AutoSize = true;
            this.lbl_kelimeRenk.Location = new System.Drawing.Point(40, 119);
            this.lbl_kelimeRenk.Name = "lbl_kelimeRenk";
            this.lbl_kelimeRenk.Size = new System.Drawing.Size(69, 13);
            this.lbl_kelimeRenk.TabIndex = 5;
            this.lbl_kelimeRenk.Text = "Kelime Rengi";
            this.lbl_kelimeRenk.Click += new System.EventHandler(this.pcr_kelimeRenk_Click);
            // 
            // pcr_kelimeRenk
            // 
            this.pcr_kelimeRenk.BackColor = System.Drawing.Color.Black;
            this.pcr_kelimeRenk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcr_kelimeRenk.Location = new System.Drawing.Point(6, 110);
            this.pcr_kelimeRenk.Name = "pcr_kelimeRenk";
            this.pcr_kelimeRenk.Size = new System.Drawing.Size(32, 31);
            this.pcr_kelimeRenk.TabIndex = 4;
            this.pcr_kelimeRenk.TabStop = false;
            this.pcr_kelimeRenk.Click += new System.EventHandler(this.pcr_kelimeRenk_Click);
            // 
            // txt_kelimeler
            // 
            this.txt_kelimeler.Location = new System.Drawing.Point(6, 19);
            this.txt_kelimeler.Multiline = true;
            this.txt_kelimeler.Name = "txt_kelimeler";
            this.txt_kelimeler.Size = new System.Drawing.Size(285, 85);
            this.txt_kelimeler.TabIndex = 0;
            // 
            // pcr_yorum
            // 
            this.pcr_yorum.BackColor = System.Drawing.Color.Black;
            this.pcr_yorum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcr_yorum.Location = new System.Drawing.Point(6, 86);
            this.pcr_yorum.Name = "pcr_yorum";
            this.pcr_yorum.Size = new System.Drawing.Size(32, 31);
            this.pcr_yorum.TabIndex = 6;
            this.pcr_yorum.TabStop = false;
            this.pcr_yorum.Click += new System.EventHandler(this.pcr_kelimeRenk_Click);
            // 
            // pcr_yazi
            // 
            this.pcr_yazi.BackColor = System.Drawing.Color.Black;
            this.pcr_yazi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcr_yazi.Location = new System.Drawing.Point(18, 204);
            this.pcr_yazi.Name = "pcr_yazi";
            this.pcr_yazi.Size = new System.Drawing.Size(32, 31);
            this.pcr_yazi.TabIndex = 7;
            this.pcr_yazi.TabStop = false;
            this.pcr_yazi.Click += new System.EventHandler(this.pcr_kelimeRenk_Click);
            // 
            // lbl_yorum
            // 
            this.lbl_yorum.AutoSize = true;
            this.lbl_yorum.Location = new System.Drawing.Point(40, 95);
            this.lbl_yorum.Name = "lbl_yorum";
            this.lbl_yorum.Size = new System.Drawing.Size(68, 13);
            this.lbl_yorum.TabIndex = 6;
            this.lbl_yorum.Text = "Yorum Rengi";
            // 
            // lbl_tirnak
            // 
            this.lbl_tirnak.AutoSize = true;
            this.lbl_tirnak.Location = new System.Drawing.Point(52, 213);
            this.lbl_tirnak.Name = "lbl_tirnak";
            this.lbl_tirnak.Size = new System.Drawing.Size(68, 13);
            this.lbl_tirnak.TabIndex = 8;
            this.lbl_tirnak.Text = "Tırnak Rengi";
            // 
            // chk_tirnak
            // 
            this.chk_tirnak.AutoSize = true;
            this.chk_tirnak.Checked = true;
            this.chk_tirnak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_tirnak.Location = new System.Drawing.Point(178, 212);
            this.chk_tirnak.Name = "chk_tirnak";
            this.chk_tirnak.Size = new System.Drawing.Size(125, 17);
            this.chk_tirnak.TabIndex = 9;
            this.chk_tirnak.Text = "Tırnak işaretlerini tanı";
            this.chk_tirnak.UseVisualStyleBackColor = true;
            // 
            // lbl_sayi
            // 
            this.lbl_sayi.AutoSize = true;
            this.lbl_sayi.Location = new System.Drawing.Point(52, 264);
            this.lbl_sayi.Name = "lbl_sayi";
            this.lbl_sayi.Size = new System.Drawing.Size(58, 13);
            this.lbl_sayi.TabIndex = 11;
            this.lbl_sayi.Text = "Sayı Rengi";
            // 
            // pcr_sayi
            // 
            this.pcr_sayi.BackColor = System.Drawing.Color.Black;
            this.pcr_sayi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcr_sayi.Location = new System.Drawing.Point(18, 255);
            this.pcr_sayi.Name = "pcr_sayi";
            this.pcr_sayi.Size = new System.Drawing.Size(32, 31);
            this.pcr_sayi.TabIndex = 10;
            this.pcr_sayi.TabStop = false;
            this.pcr_sayi.Click += new System.EventHandler(this.pcr_kelimeRenk_Click);
            // 
            // chk_sayi
            // 
            this.chk_sayi.AutoSize = true;
            this.chk_sayi.Checked = true;
            this.chk_sayi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_sayi.Location = new System.Drawing.Point(178, 263);
            this.chk_sayi.Name = "chk_sayi";
            this.chk_sayi.Size = new System.Drawing.Size(79, 17);
            this.chk_sayi.TabIndex = 12;
            this.chk_sayi.Text = "Sayıları tanı";
            this.chk_sayi.UseVisualStyleBackColor = true;
            // 
            // grp_yorum
            // 
            this.grp_yorum.Controls.Add(this.lbl_uzun);
            this.grp_yorum.Controls.Add(this.lbl_kisa);
            this.grp_yorum.Controls.Add(this.txt_uzun);
            this.grp_yorum.Controls.Add(this.txt_kisa);
            this.grp_yorum.Controls.Add(this.pcr_yorum);
            this.grp_yorum.Controls.Add(this.lbl_yorum);
            this.grp_yorum.Location = new System.Drawing.Point(12, 292);
            this.grp_yorum.Name = "grp_yorum";
            this.grp_yorum.Size = new System.Drawing.Size(291, 123);
            this.grp_yorum.TabIndex = 13;
            this.grp_yorum.TabStop = false;
            this.grp_yorum.Text = "Yorum Satırı";
            // 
            // txt_kisa
            // 
            this.txt_kisa.Location = new System.Drawing.Point(73, 19);
            this.txt_kisa.Name = "txt_kisa";
            this.txt_kisa.Size = new System.Drawing.Size(212, 20);
            this.txt_kisa.TabIndex = 0;
            // 
            // txt_uzun
            // 
            this.txt_uzun.Location = new System.Drawing.Point(73, 45);
            this.txt_uzun.Multiline = true;
            this.txt_uzun.Name = "txt_uzun";
            this.txt_uzun.Size = new System.Drawing.Size(212, 36);
            this.txt_uzun.TabIndex = 1;
            // 
            // chk_kucukBuyuk
            // 
            this.chk_kucukBuyuk.AutoSize = true;
            this.chk_kucukBuyuk.Checked = true;
            this.chk_kucukBuyuk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_kucukBuyuk.Location = new System.Drawing.Point(18, 427);
            this.chk_kucukBuyuk.Name = "chk_kucukBuyuk";
            this.chk_kucukBuyuk.Size = new System.Drawing.Size(139, 17);
            this.chk_kucukBuyuk.TabIndex = 14;
            this.chk_kucukBuyuk.Text = "Büyük/Küçük Harf Tanı";
            this.chk_kucukBuyuk.UseVisualStyleBackColor = true;
            // 
            // lbl_kisa
            // 
            this.lbl_kisa.AutoSize = true;
            this.lbl_kisa.Location = new System.Drawing.Point(14, 22);
            this.lbl_kisa.Name = "lbl_kisa";
            this.lbl_kisa.Size = new System.Drawing.Size(53, 13);
            this.lbl_kisa.TabIndex = 7;
            this.lbl_kisa.Text = "Tek Satır:";
            // 
            // lbl_uzun
            // 
            this.lbl_uzun.AutoSize = true;
            this.lbl_uzun.Location = new System.Drawing.Point(6, 57);
            this.lbl_uzun.Name = "lbl_uzun";
            this.lbl_uzun.Size = new System.Drawing.Size(61, 13);
            this.lbl_uzun.TabIndex = 8;
            this.lbl_uzun.Text = "Çoklu Satır:";
            // 
            // frm_dil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(322, 450);
            this.Controls.Add(this.chk_kucukBuyuk);
            this.Controls.Add(this.grp_yorum);
            this.Controls.Add(this.chk_sayi);
            this.Controls.Add(this.lbl_sayi);
            this.Controls.Add(this.pcr_sayi);
            this.Controls.Add(this.chk_tirnak);
            this.Controls.Add(this.lbl_tirnak);
            this.Controls.Add(this.pcr_yazi);
            this.Controls.Add(this.grp_kelime);
            this.Controls.Add(this.btn_disaAktar);
            this.Controls.Add(this.btn_iceAktar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_dil";
            this.Text = "Dil Oluştur";
            this.grp_kelime.ResumeLayout(false);
            this.grp_kelime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_kelimeRenk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_yorum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_yazi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcr_sayi)).EndInit();
            this.grp_yorum.ResumeLayout(false);
            this.grp_yorum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_iceAktar;
        private System.Windows.Forms.Button btn_disaAktar;
        private System.Windows.Forms.ColorDialog clr_kelime;
        private System.Windows.Forms.GroupBox grp_kelime;
        private System.Windows.Forms.TextBox txt_kelimeler;
        private System.Windows.Forms.Label lbl_kelimeRenk;
        private System.Windows.Forms.PictureBox pcr_kelimeRenk;
        private System.Windows.Forms.PictureBox pcr_yorum;
        private System.Windows.Forms.PictureBox pcr_yazi;
        private System.Windows.Forms.Label lbl_yorum;
        private System.Windows.Forms.Label lbl_tirnak;
        private System.Windows.Forms.CheckBox chk_tirnak;
        private System.Windows.Forms.Label lbl_sayi;
        private System.Windows.Forms.PictureBox pcr_sayi;
        private System.Windows.Forms.CheckBox chk_sayi;
        private System.Windows.Forms.GroupBox grp_yorum;
        private System.Windows.Forms.Label lbl_uzun;
        private System.Windows.Forms.Label lbl_kisa;
        private System.Windows.Forms.TextBox txt_uzun;
        private System.Windows.Forms.TextBox txt_kisa;
        private System.Windows.Forms.CheckBox chk_kucukBuyuk;
    }
}