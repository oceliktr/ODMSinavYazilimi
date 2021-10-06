
namespace ODMSinavYazilimi
{
    partial class FormAna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAna));
            this.cbSinavlar = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDonemAdi = new System.Windows.Forms.Label();
            this.lblVeriGirisi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDegerlenirmeKarne = new System.Windows.Forms.Button();
            this.btnTextOlustur = new System.Windows.Forms.Button();
            this.btnCkOlustur = new System.Windows.Forms.Button();
            this.btnKutuk = new System.Windows.Forms.Button();
            this.lnbLblSorular = new System.Windows.Forms.LinkLabel();
            this.lnkLblKutuk = new System.Windows.Forms.LinkLabel();
            this.lnkLblDersler = new System.Windows.Forms.LinkLabel();
            this.lnkLblDonemveSinavBilgileri = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDersler = new System.Windows.Forms.Button();
            this.btnSorular = new System.Windows.Forms.Button();
            this.btnManuelSinav = new System.Windows.Forms.Button();
            this.lnkManuelKutukEkle = new System.Windows.Forms.LinkLabel();
            this.lnkJsonFolderOpen = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSinavlar
            // 
            this.cbSinavlar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSinavlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbSinavlar.FormattingEnabled = true;
            this.cbSinavlar.Location = new System.Drawing.Point(113, 110);
            this.cbSinavlar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSinavlar.Name = "cbSinavlar";
            this.cbSinavlar.Size = new System.Drawing.Size(398, 26);
            this.cbSinavlar.TabIndex = 126;
            this.cbSinavlar.SelectedIndexChanged += new System.EventHandler(this.cbSinavlar_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(13, 112);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 125;
            this.label9.Text = "Sınav Seçiniz:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 127;
            this.label1.Text = "Dönem Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(85, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 18);
            this.label2.TabIndex = 128;
            this.label2.Text = "Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(37, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 129;
            this.label3.Text = "Veri Girişi:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(113, 25);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(13, 17);
            this.lblId.TabIndex = 130;
            this.lblId.Text = "-";
            // 
            // lblDonemAdi
            // 
            this.lblDonemAdi.AutoSize = true;
            this.lblDonemAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDonemAdi.Location = new System.Drawing.Point(113, 54);
            this.lblDonemAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDonemAdi.Name = "lblDonemAdi";
            this.lblDonemAdi.Size = new System.Drawing.Size(13, 17);
            this.lblDonemAdi.TabIndex = 131;
            this.lblDonemAdi.Text = "-";
            // 
            // lblVeriGirisi
            // 
            this.lblVeriGirisi.AutoSize = true;
            this.lblVeriGirisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVeriGirisi.Location = new System.Drawing.Point(113, 84);
            this.lblVeriGirisi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVeriGirisi.Name = "lblVeriGirisi";
            this.lblVeriGirisi.Size = new System.Drawing.Size(13, 17);
            this.lblVeriGirisi.TabIndex = 132;
            this.lblVeriGirisi.Text = "-";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(510, 38);
            this.label5.TabIndex = 136;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // btnDegerlenirmeKarne
            // 
            this.btnDegerlenirmeKarne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDegerlenirmeKarne.Enabled = false;
            this.btnDegerlenirmeKarne.Location = new System.Drawing.Point(314, 145);
            this.btnDegerlenirmeKarne.Name = "btnDegerlenirmeKarne";
            this.btnDegerlenirmeKarne.Size = new System.Drawing.Size(95, 35);
            this.btnDegerlenirmeKarne.TabIndex = 140;
            this.btnDegerlenirmeKarne.Text = "Değerlendirme";
            this.btnDegerlenirmeKarne.UseVisualStyleBackColor = true;
            this.btnDegerlenirmeKarne.Click += new System.EventHandler(this.btnDegerlenirmeKarne_Click);
            // 
            // btnTextOlustur
            // 
            this.btnTextOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTextOlustur.Location = new System.Drawing.Point(111, 186);
            this.btnTextOlustur.Name = "btnTextOlustur";
            this.btnTextOlustur.Size = new System.Drawing.Size(95, 35);
            this.btnTextOlustur.TabIndex = 139;
            this.btnTextOlustur.Text = "Text Oluştur";
            this.btnTextOlustur.UseVisualStyleBackColor = true;
            this.btnTextOlustur.Click += new System.EventHandler(this.btnTextOlustur_Click);
            // 
            // btnCkOlustur
            // 
            this.btnCkOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCkOlustur.Enabled = false;
            this.btnCkOlustur.Location = new System.Drawing.Point(213, 145);
            this.btnCkOlustur.Name = "btnCkOlustur";
            this.btnCkOlustur.Size = new System.Drawing.Size(95, 35);
            this.btnCkOlustur.TabIndex = 138;
            this.btnCkOlustur.Text = "CK Oluştur";
            this.btnCkOlustur.UseVisualStyleBackColor = true;
            this.btnCkOlustur.Click += new System.EventHandler(this.btnCkOlustur_Click);
            // 
            // btnKutuk
            // 
            this.btnKutuk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKutuk.Enabled = false;
            this.btnKutuk.Location = new System.Drawing.Point(111, 145);
            this.btnKutuk.Name = "btnKutuk";
            this.btnKutuk.Size = new System.Drawing.Size(95, 35);
            this.btnKutuk.TabIndex = 137;
            this.btnKutuk.Text = "Kütük İşlemleri";
            this.btnKutuk.UseVisualStyleBackColor = true;
            this.btnKutuk.Click += new System.EventHandler(this.btnKutuk_Click);
            // 
            // lnbLblSorular
            // 
            this.lnbLblSorular.AutoSize = true;
            this.lnbLblSorular.Location = new System.Drawing.Point(2, 99);
            this.lnbLblSorular.Name = "lnbLblSorular";
            this.lnbLblSorular.Size = new System.Drawing.Size(40, 13);
            this.lnbLblSorular.TabIndex = 144;
            this.lnbLblSorular.TabStop = true;
            this.lnbLblSorular.Text = "Sorular";
            this.lnbLblSorular.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnbLblSorular_LinkClicked);
            // 
            // lnkLblKutuk
            // 
            this.lnkLblKutuk.AutoSize = true;
            this.lnkLblKutuk.Location = new System.Drawing.Point(2, 72);
            this.lnkLblKutuk.Name = "lnkLblKutuk";
            this.lnkLblKutuk.Size = new System.Drawing.Size(35, 13);
            this.lnkLblKutuk.TabIndex = 143;
            this.lnkLblKutuk.TabStop = true;
            this.lnkLblKutuk.Text = "Kütük";
            this.lnkLblKutuk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblKutuk_LinkClicked);
            // 
            // lnkLblDersler
            // 
            this.lnkLblDersler.AutoSize = true;
            this.lnkLblDersler.Location = new System.Drawing.Point(2, 45);
            this.lnkLblDersler.Name = "lnkLblDersler";
            this.lnkLblDersler.Size = new System.Drawing.Size(40, 13);
            this.lnkLblDersler.TabIndex = 142;
            this.lnkLblDersler.TabStop = true;
            this.lnkLblDersler.Text = "Dersler";
            this.lnkLblDersler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblDersler_LinkClicked);
            // 
            // lnkLblDonemveSinavBilgileri
            // 
            this.lnkLblDonemveSinavBilgileri.AutoSize = true;
            this.lnkLblDonemveSinavBilgileri.Location = new System.Drawing.Point(2, 18);
            this.lnkLblDonemveSinavBilgileri.Name = "lnkLblDonemveSinavBilgileri";
            this.lnkLblDonemveSinavBilgileri.Size = new System.Drawing.Size(118, 13);
            this.lnkLblDonemveSinavBilgileri.TabIndex = 141;
            this.lnkLblDonemveSinavBilgileri.TabStop = true;
            this.lnkLblDonemveSinavBilgileri.Text = "Dönem ve sınav bilgileri";
            this.lnkLblDonemveSinavBilgileri.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblDonemveSinavBilgileri_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(125, 18);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 24);
            this.progressBar1.TabIndex = 194;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkJsonFolderOpen);
            this.groupBox1.Controls.Add(this.lnkManuelKutukEkle);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.lnkLblDonemveSinavBilgileri);
            this.groupBox1.Controls.Add(this.lnbLblSorular);
            this.groupBox1.Controls.Add(this.lnkLblDersler);
            this.groupBox1.Controls.Add(this.lnkLblKutuk);
            this.groupBox1.Location = new System.Drawing.Point(12, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 118);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İndirme işlemleri erzurumodm.meb.gov.tr";
            // 
            // btnDersler
            // 
            this.btnDersler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDersler.Location = new System.Drawing.Point(212, 186);
            this.btnDersler.Name = "btnDersler";
            this.btnDersler.Size = new System.Drawing.Size(95, 35);
            this.btnDersler.TabIndex = 196;
            this.btnDersler.Text = "Dersler";
            this.btnDersler.UseVisualStyleBackColor = true;
            this.btnDersler.Click += new System.EventHandler(this.btnDersler_Click);
            // 
            // btnSorular
            // 
            this.btnSorular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSorular.Enabled = false;
            this.btnSorular.Location = new System.Drawing.Point(415, 145);
            this.btnSorular.Name = "btnSorular";
            this.btnSorular.Size = new System.Drawing.Size(95, 35);
            this.btnSorular.TabIndex = 197;
            this.btnSorular.Text = "Sorular";
            this.btnSorular.UseVisualStyleBackColor = true;
            this.btnSorular.Click += new System.EventHandler(this.btnSorular_Click);
            // 
            // btnManuelSinav
            // 
            this.btnManuelSinav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManuelSinav.Location = new System.Drawing.Point(314, 186);
            this.btnManuelSinav.Name = "btnManuelSinav";
            this.btnManuelSinav.Size = new System.Drawing.Size(196, 35);
            this.btnManuelSinav.TabIndex = 198;
            this.btnManuelSinav.Text = "Manuel Sınav İşlemleri";
            this.btnManuelSinav.UseVisualStyleBackColor = true;
            this.btnManuelSinav.Click += new System.EventHandler(this.btnManuelSinav_Click);
            // 
            // lnkManuelKutukEkle
            // 
            this.lnkManuelKutukEkle.AutoSize = true;
            this.lnkManuelKutukEkle.Location = new System.Drawing.Point(125, 71);
            this.lnkManuelKutukEkle.Name = "lnkManuelKutukEkle";
            this.lnkManuelKutukEkle.Size = new System.Drawing.Size(114, 13);
            this.lnkManuelKutukEkle.TabIndex = 195;
            this.lnkManuelKutukEkle.TabStop = true;
            this.lnkManuelKutukEkle.Text = "Excel\'den Kütük Yükle";
            this.lnkManuelKutukEkle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManuelKutukEkle_LinkClicked);
            // 
            // lnkJsonFolderOpen
            // 
            this.lnkJsonFolderOpen.AutoSize = true;
            this.lnkJsonFolderOpen.Location = new System.Drawing.Point(125, 99);
            this.lnkJsonFolderOpen.Name = "lnkJsonFolderOpen";
            this.lnkJsonFolderOpen.Size = new System.Drawing.Size(120, 13);
            this.lnkJsonFolderOpen.TabIndex = 196;
            this.lnkJsonFolderOpen.TabStop = true;
            this.lnkJsonFolderOpen.Text = "JSON Dosya Dizinini Aç";
            this.lnkJsonFolderOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkJsonFolderOpen_LinkClicked);
            // 
            // FormAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 401);
            this.Controls.Add(this.btnManuelSinav);
            this.Controls.Add(this.btnSorular);
            this.Controls.Add(this.btnDersler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblVeriGirisi);
            this.Controls.Add(this.lblDonemAdi);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSinavlar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnDegerlenirmeKarne);
            this.Controls.Add(this.btnTextOlustur);
            this.Controls.Add(this.btnCkOlustur);
            this.Controls.Add(this.btnKutuk);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Erzurum Ölçme Değerlendirme Merkezi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbSinavlar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDonemAdi;
        private System.Windows.Forms.Label lblVeriGirisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDegerlenirmeKarne;
        private System.Windows.Forms.Button btnTextOlustur;
        private System.Windows.Forms.Button btnCkOlustur;
        private System.Windows.Forms.Button btnKutuk;
        private System.Windows.Forms.LinkLabel lnbLblSorular;
        private System.Windows.Forms.LinkLabel lnkLblKutuk;
        private System.Windows.Forms.LinkLabel lnkLblDersler;
        private System.Windows.Forms.LinkLabel lnkLblDonemveSinavBilgileri;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDersler;
        private System.Windows.Forms.Button btnSorular;
        private System.Windows.Forms.Button btnManuelSinav;
        private System.Windows.Forms.LinkLabel lnkManuelKutukEkle;
        private System.Windows.Forms.LinkLabel lnkJsonFolderOpen;
    }
}

