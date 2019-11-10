namespace synText_Editor
{
    partial class frm_ara
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
            this.lbl_Baslik = new System.Windows.Forms.Label();
            this.txt_Ara = new System.Windows.Forms.TextBox();
            this.btn_Ara = new System.Windows.Forms.Button();
            this.lbl_Sonuc = new System.Windows.Forms.Label();
            this.btn_Iptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Baslik
            // 
            this.lbl_Baslik.AutoSize = true;
            this.lbl_Baslik.Location = new System.Drawing.Point(23, 22);
            this.lbl_Baslik.Name = "lbl_Baslik";
            this.lbl_Baslik.Size = new System.Drawing.Size(47, 13);
            this.lbl_Baslik.TabIndex = 0;
            this.lbl_Baslik.Text = "Aranan :";
            // 
            // txt_Ara
            // 
            this.txt_Ara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Ara.Location = new System.Drawing.Point(74, 19);
            this.txt_Ara.Name = "txt_Ara";
            this.txt_Ara.Size = new System.Drawing.Size(246, 20);
            this.txt_Ara.TabIndex = 1;
            // 
            // btn_Ara
            // 
            this.btn_Ara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ara.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Ara.Location = new System.Drawing.Point(233, 51);
            this.btn_Ara.Name = "btn_Ara";
            this.btn_Ara.Size = new System.Drawing.Size(87, 25);
            this.btn_Ara.TabIndex = 2;
            this.btn_Ara.Text = "Ara";
            this.btn_Ara.UseVisualStyleBackColor = true;
            this.btn_Ara.Click += new System.EventHandler(this.btn_Ara_Click);
            // 
            // lbl_Sonuc
            // 
            this.lbl_Sonuc.AutoSize = true;
            this.lbl_Sonuc.Location = new System.Drawing.Point(73, 117);
            this.lbl_Sonuc.Name = "lbl_Sonuc";
            this.lbl_Sonuc.Size = new System.Drawing.Size(0, 13);
            this.lbl_Sonuc.TabIndex = 3;
            // 
            // btn_Iptal
            // 
            this.btn_Iptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Iptal.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Iptal.Location = new System.Drawing.Point(166, 51);
            this.btn_Iptal.Name = "btn_Iptal";
            this.btn_Iptal.Size = new System.Drawing.Size(61, 25);
            this.btn_Iptal.TabIndex = 5;
            this.btn_Iptal.Text = "İptal";
            this.btn_Iptal.UseVisualStyleBackColor = true;
            this.btn_Iptal.Click += new System.EventHandler(this.btn_Iptal_Click);
            // 
            // frm_Bul
            // 
            this.AcceptButton = this.btn_Ara;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(343, 87);
            this.Controls.Add(this.btn_Iptal);
            this.Controls.Add(this.lbl_Sonuc);
            this.Controls.Add(this.btn_Ara);
            this.Controls.Add(this.txt_Ara);
            this.Controls.Add(this.lbl_Baslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Bul";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bul";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Bul_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Baslik;
        private System.Windows.Forms.TextBox txt_Ara;
        private System.Windows.Forms.Button btn_Ara;
        private System.Windows.Forms.Label lbl_Sonuc;
        private System.Windows.Forms.Button btn_Iptal;
    }
}