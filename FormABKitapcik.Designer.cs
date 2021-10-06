
namespace ODMSinavYazilimi
{
    partial class FormABKitapcik
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
            this.dgBranslar = new System.Windows.Forms.DataGridView();
            this.lblDersAdi = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dgvSoruKarsilastirma = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDersiSil = new System.Windows.Forms.Button();
            this.btnTumunuSil = new System.Windows.Forms.Button();
            this.lblSoruSayisi = new System.Windows.Forms.Label();
            this.lblSinif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSinavAdi = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgBranslar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoruKarsilastirma)).BeginInit();
            this.SuspendLayout();
            // 
            // dgBranslar
            // 
            this.dgBranslar.AllowUserToAddRows = false;
            this.dgBranslar.AllowUserToDeleteRows = false;
            this.dgBranslar.AllowUserToOrderColumns = true;
            this.dgBranslar.AllowUserToResizeColumns = false;
            this.dgBranslar.AllowUserToResizeRows = false;
            this.dgBranslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBranslar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgBranslar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBranslar.Location = new System.Drawing.Point(11, 63);
            this.dgBranslar.Margin = new System.Windows.Forms.Padding(2);
            this.dgBranslar.Name = "dgBranslar";
            this.dgBranslar.RowHeadersVisible = false;
            this.dgBranslar.RowHeadersWidth = 51;
            this.dgBranslar.RowTemplate.Height = 24;
            this.dgBranslar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBranslar.ShowEditingIcon = false;
            this.dgBranslar.ShowRowErrors = false;
            this.dgBranslar.Size = new System.Drawing.Size(270, 218);
            this.dgBranslar.TabIndex = 201;
            this.dgBranslar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBranslar_CellContentClick);
            this.dgBranslar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBranslar_CellContentClick);
            this.dgBranslar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBranslar_CellContentClick);
            // 
            // lblDersAdi
            // 
            this.lblDersAdi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDersAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDersAdi.Location = new System.Drawing.Point(96, 36);
            this.lblDersAdi.Name = "lblDersAdi";
            this.lblDersAdi.Size = new System.Drawing.Size(394, 18);
            this.lblDersAdi.TabIndex = 202;
            this.lblDersAdi.Text = "Ders Seçiniz : ";
            this.lblDersAdi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(286, 63);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(204, 218);
            this.textBox1.TabIndex = 203;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.Location = new System.Drawing.Point(400, 338);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(91, 36);
            this.btnKaydet.TabIndex = 204;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dgvSoruKarsilastirma
            // 
            this.dgvSoruKarsilastirma.AllowUserToAddRows = false;
            this.dgvSoruKarsilastirma.AllowUserToDeleteRows = false;
            this.dgvSoruKarsilastirma.AllowUserToOrderColumns = true;
            this.dgvSoruKarsilastirma.AllowUserToResizeColumns = false;
            this.dgvSoruKarsilastirma.AllowUserToResizeRows = false;
            this.dgvSoruKarsilastirma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoruKarsilastirma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSoruKarsilastirma.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSoruKarsilastirma.Location = new System.Drawing.Point(10, 410);
            this.dgvSoruKarsilastirma.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSoruKarsilastirma.Name = "dgvSoruKarsilastirma";
            this.dgvSoruKarsilastirma.RowHeadersVisible = false;
            this.dgvSoruKarsilastirma.RowHeadersWidth = 51;
            this.dgvSoruKarsilastirma.RowTemplate.Height = 24;
            this.dgvSoruKarsilastirma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoruKarsilastirma.ShowEditingIcon = false;
            this.dgvSoruKarsilastirma.ShowRowErrors = false;
            this.dgvSoruKarsilastirma.Size = new System.Drawing.Size(480, 240);
            this.dgvSoruKarsilastirma.TabIndex = 205;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 34);
            this.label1.TabIndex = 206;
            this.label1.Text = "Her satıra bir soru olacak şekilde A ve B kitapçığındaki soru numaralarını girini" +
    "z. Örneğin : A1,B5\r\nA kitapçığı 1 ve B kitapçığı 5. soru aynı sorudur.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 207;
            this.label2.Text = "Dersler :";
            // 
            // btnDersiSil
            // 
            this.btnDersiSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDersiSil.Location = new System.Drawing.Point(11, 338);
            this.btnDersiSil.Name = "btnDersiSil";
            this.btnDersiSil.Size = new System.Drawing.Size(130, 36);
            this.btnDersiSil.TabIndex = 208;
            this.btnDersiSil.Text = "Dersin Kayıtlarını Sil";
            this.btnDersiSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDersiSil.UseVisualStyleBackColor = true;
            this.btnDersiSil.Click += new System.EventHandler(this.btnDersiSil_Click);
            // 
            // btnTumunuSil
            // 
            this.btnTumunuSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTumunuSil.Location = new System.Drawing.Point(147, 338);
            this.btnTumunuSil.Name = "btnTumunuSil";
            this.btnTumunuSil.Size = new System.Drawing.Size(130, 36);
            this.btnTumunuSil.TabIndex = 209;
            this.btnTumunuSil.Text = "Tümünü Sil";
            this.btnTumunuSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTumunuSil.UseVisualStyleBackColor = true;
            this.btnTumunuSil.Click += new System.EventHandler(this.btnTumunuSil_Click);
            // 
            // lblSoruSayisi
            // 
            this.lblSoruSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoruSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoruSayisi.Location = new System.Drawing.Point(330, 384);
            this.lblSoruSayisi.Name = "lblSoruSayisi";
            this.lblSoruSayisi.Size = new System.Drawing.Size(160, 18);
            this.lblSoruSayisi.TabIndex = 210;
            this.lblSoruSayisi.Text = "Soru Sayısı : 0/0 ";
            this.lblSoruSayisi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSinif
            // 
            this.lblSinif.AutoSize = true;
            this.lblSinif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinif.Location = new System.Drawing.Point(160, 10);
            this.lblSinif.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinif.Name = "lblSinif";
            this.lblSinif.Size = new System.Drawing.Size(16, 17);
            this.lblSinif.TabIndex = 225;
            this.lblSinif.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(118, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 224;
            this.label3.Text = "Sınıf :";
            // 
            // lblSinavAdi
            // 
            this.lblSinavAdi.AutoSize = true;
            this.lblSinavAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinavAdi.Location = new System.Drawing.Point(269, 10);
            this.lblSinavAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinavAdi.Name = "lblSinavAdi";
            this.lblSinavAdi.Size = new System.Drawing.Size(13, 17);
            this.lblSinavAdi.TabIndex = 223;
            this.lblSinavAdi.Text = "-";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(86, 10);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 17);
            this.lblId.TabIndex = 222;
            this.lblId.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 221;
            this.label4.Text = "Sınav No :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(197, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 220;
            this.label5.Text = "Sınav Adı:";
            // 
            // FormABKitapcik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 635);
            this.Controls.Add(this.lblSinif);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSinavAdi);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSoruSayisi);
            this.Controls.Add(this.btnTumunuSil);
            this.Controls.Add(this.btnDersiSil);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSoruKarsilastirma);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDersAdi);
            this.Controls.Add(this.dgBranslar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormABKitapcik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "A-B Kitapçık Eşleştirme";
            this.Load += new System.EventHandler(this.FormABKitapcik_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBranslar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoruKarsilastirma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBranslar;
        private System.Windows.Forms.Label lblDersAdi;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dgvSoruKarsilastirma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDersiSil;
        private System.Windows.Forms.Button btnTumunuSil;
        private System.Windows.Forms.Label lblSoruSayisi;
        public System.Windows.Forms.Label lblSinif;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblSinavAdi;
        public System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}