namespace synText_Editor
{
    partial class frm_degistir
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
            this.btn_Iptal = new System.Windows.Forms.Button();
            this.btn_TumunuDegistir = new System.Windows.Forms.Button();
            this.txt_Aranan = new System.Windows.Forms.TextBox();
            this.lbl_Baslik = new System.Windows.Forms.Label();
            this.txt_Degistirilecek = new System.Windows.Forms.TextBox();
            this.lbl_Degistir = new System.Windows.Forms.Label();
            this.lbl_Sonuc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Iptal
            // 
            this.btn_Iptal.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Iptal.Location = new System.Drawing.Point(207, 91);
            this.btn_Iptal.Name = "btn_Iptal";
            this.btn_Iptal.Size = new System.Drawing.Size(58, 27);
            this.btn_Iptal.TabIndex = 3;
            this.btn_Iptal.Text = "İptal";
            this.btn_Iptal.UseVisualStyleBackColor = true;
            this.btn_Iptal.Click += new System.EventHandler(this.btn_Iptal_Click);
            // 
            // btn_TumunuDegistir
            // 
            this.btn_TumunuDegistir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_TumunuDegistir.Location = new System.Drawing.Point(271, 91);
            this.btn_TumunuDegistir.Name = "btn_TumunuDegistir";
            this.btn_TumunuDegistir.Size = new System.Drawing.Size(94, 27);
            this.btn_TumunuDegistir.TabIndex = 2;
            this.btn_TumunuDegistir.Text = "Tümünü Değiştir";
            this.btn_TumunuDegistir.UseVisualStyleBackColor = true;
            this.btn_TumunuDegistir.Click += new System.EventHandler(this.btn_TumunuDegistir_Click);
            // 
            // txt_Aranan
            // 
            this.txt_Aranan.Location = new System.Drawing.Point(92, 22);
            this.txt_Aranan.Name = "txt_Aranan";
            this.txt_Aranan.Size = new System.Drawing.Size(273, 20);
            this.txt_Aranan.TabIndex = 0;
            // 
            // lbl_Baslik
            // 
            this.lbl_Baslik.AutoSize = true;
            this.lbl_Baslik.Location = new System.Drawing.Point(20, 25);
            this.lbl_Baslik.Name = "lbl_Baslik";
            this.lbl_Baslik.Size = new System.Drawing.Size(47, 13);
            this.lbl_Baslik.TabIndex = 4;
            this.lbl_Baslik.Text = "Aranan :";
            // 
            // txt_Degistirilecek
            // 
            this.txt_Degistirilecek.Location = new System.Drawing.Point(92, 53);
            this.txt_Degistirilecek.Name = "txt_Degistirilecek";
            this.txt_Degistirilecek.Size = new System.Drawing.Size(273, 20);
            this.txt_Degistirilecek.TabIndex = 1;
            // 
            // lbl_Degistir
            // 
            this.lbl_Degistir.AutoSize = true;
            this.lbl_Degistir.Location = new System.Drawing.Point(20, 56);
            this.lbl_Degistir.Name = "lbl_Degistir";
            this.lbl_Degistir.Size = new System.Drawing.Size(66, 13);
            this.lbl_Degistir.TabIndex = 5;
            this.lbl_Degistir.Text = "Yeni Değer :";
            // 
            // lbl_Sonuc
            // 
            this.lbl_Sonuc.AutoSize = true;
            this.lbl_Sonuc.Location = new System.Drawing.Point(20, 97);
            this.lbl_Sonuc.Name = "lbl_Sonuc";
            this.lbl_Sonuc.Size = new System.Drawing.Size(151, 13);
            this.lbl_Sonuc.TabIndex = 6;
            this.lbl_Sonuc.Text = "Toplam 0 adet kayıt değiştirildi.";
            // 
            // frm_Degistir
            // 
            this.AcceptButton = this.btn_TumunuDegistir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 134);
            this.Controls.Add(this.lbl_Sonuc);
            this.Controls.Add(this.txt_Degistirilecek);
            this.Controls.Add(this.lbl_Degistir);
            this.Controls.Add(this.btn_Iptal);
            this.Controls.Add(this.btn_TumunuDegistir);
            this.Controls.Add(this.txt_Aranan);
            this.Controls.Add(this.lbl_Baslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Degistir";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Değiştir";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Degistir_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Iptal;
        private System.Windows.Forms.Button btn_TumunuDegistir;
        private System.Windows.Forms.TextBox txt_Aranan;
        private System.Windows.Forms.Label lbl_Baslik;
        private System.Windows.Forms.TextBox txt_Degistirilecek;
        private System.Windows.Forms.Label lbl_Degistir;
        private System.Windows.Forms.Label lbl_Sonuc;
    }
}