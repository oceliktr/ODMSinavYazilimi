
namespace ODMSinavYazilimi
{
    partial class FormDegerlendirme
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDegerlendirme));
            this.cbExcelIlce = new System.Windows.Forms.CheckBox();
            this.btnDogruCevaplar = new System.Windows.Forms.Button();
            this.lblGecenSure = new System.Windows.Forms.Label();
            this.pbAna = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolSslKalanSure = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDegerlendirme1 = new System.Windows.Forms.Button();
            this.bgwDegerlendirme1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnABKitapcigi = new System.Windows.Forms.Button();
            this.lblSinif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSinavAdi = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bgwDegerlendirmeIlce = new System.ComponentModel.BackgroundWorker();
            this.cbExceleAktar = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbExcelIlce
            // 
            this.cbExcelIlce.AutoSize = true;
            this.cbExcelIlce.Location = new System.Drawing.Point(14, 221);
            this.cbExcelIlce.Margin = new System.Windows.Forms.Padding(2);
            this.cbExcelIlce.Name = "cbExcelIlce";
            this.cbExcelIlce.Size = new System.Drawing.Size(128, 17);
            this.cbExcelIlce.TabIndex = 212;
            this.cbExcelIlce.Text = "İlçe İlçe Excel Oluştur";
            this.cbExcelIlce.UseVisualStyleBackColor = true;
            // 
            // btnDogruCevaplar
            // 
            this.btnDogruCevaplar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDogruCevaplar.Location = new System.Drawing.Point(12, 153);
            this.btnDogruCevaplar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDogruCevaplar.Name = "btnDogruCevaplar";
            this.btnDogruCevaplar.Size = new System.Drawing.Size(155, 43);
            this.btnDogruCevaplar.TabIndex = 210;
            this.btnDogruCevaplar.Text = "Excel İçin Sonuçlar";
            this.btnDogruCevaplar.UseVisualStyleBackColor = true;
            this.btnDogruCevaplar.Click += new System.EventHandler(this.btnDogruCevaplar_Click);
            // 
            // lblGecenSure
            // 
            this.lblGecenSure.AutoSize = true;
            this.lblGecenSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGecenSure.Location = new System.Drawing.Point(516, 155);
            this.lblGecenSure.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGecenSure.Name = "lblGecenSure";
            this.lblGecenSure.Size = new System.Drawing.Size(148, 15);
            this.lblGecenSure.TabIndex = 209;
            this.lblGecenSure.Text = "Geçen süre : 00:00:00";
            // 
            // pbAna
            // 
            this.pbAna.Location = new System.Drawing.Point(9, 36);
            this.pbAna.Margin = new System.Windows.Forms.Padding(2);
            this.pbAna.Name = "pbAna";
            this.pbAna.Size = new System.Drawing.Size(654, 21);
            this.pbAna.TabIndex = 208;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(654, 58);
            this.label2.TabIndex = 207;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 60);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(654, 21);
            this.progressBar1.TabIndex = 206;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSslKalanSure});
            this.statusStrip1.Location = new System.Drawing.Point(0, 312);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 205;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolSslKalanSure
            // 
            this.toolSslKalanSure.Name = "toolSslKalanSure";
            this.toolSslKalanSure.Size = new System.Drawing.Size(16, 17);
            this.toolSslKalanSure.Text = "...";
            // 
            // btnDegerlendirme1
            // 
            this.btnDegerlendirme1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDegerlendirme1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDegerlendirme1.Location = new System.Drawing.Point(511, 171);
            this.btnDegerlendirme1.Margin = new System.Windows.Forms.Padding(2);
            this.btnDegerlendirme1.Name = "btnDegerlendirme1";
            this.btnDegerlendirme1.Size = new System.Drawing.Size(152, 43);
            this.btnDegerlendirme1.TabIndex = 204;
            this.btnDegerlendirme1.Text = "Değerlendirmeye Başla";
            this.btnDegerlendirme1.UseVisualStyleBackColor = true;
            this.btnDegerlendirme1.Click += new System.EventHandler(this.btnDegerlendirme1_Click);
            // 
            // bgwDegerlendirme1
            // 
            this.bgwDegerlendirme1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDegerlendirme1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnABKitapcigi
            // 
            this.btnABKitapcigi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnABKitapcigi.Location = new System.Drawing.Point(511, 267);
            this.btnABKitapcigi.Margin = new System.Windows.Forms.Padding(2);
            this.btnABKitapcigi.Name = "btnABKitapcigi";
            this.btnABKitapcigi.Size = new System.Drawing.Size(153, 43);
            this.btnABKitapcigi.TabIndex = 213;
            this.btnABKitapcigi.Text = "A-B Kitapçığı Soru Numaraları";
            this.btnABKitapcigi.UseVisualStyleBackColor = true;
            this.btnABKitapcigi.Click += new System.EventHandler(this.btnABKitapcigi_Click);
            // 
            // lblSinif
            // 
            this.lblSinif.AutoSize = true;
            this.lblSinif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinif.Location = new System.Drawing.Point(157, 10);
            this.lblSinif.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinif.Name = "lblSinif";
            this.lblSinif.Size = new System.Drawing.Size(16, 17);
            this.lblSinif.TabIndex = 219;
            this.lblSinif.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(115, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 218;
            this.label3.Text = "Sınıf :";
            // 
            // lblSinavAdi
            // 
            this.lblSinavAdi.AutoSize = true;
            this.lblSinavAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinavAdi.Location = new System.Drawing.Point(266, 10);
            this.lblSinavAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinavAdi.Name = "lblSinavAdi";
            this.lblSinavAdi.Size = new System.Drawing.Size(13, 17);
            this.lblSinavAdi.TabIndex = 217;
            this.lblSinavAdi.Text = "-";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(83, 10);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 17);
            this.lblId.TabIndex = 216;
            this.lblId.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 215;
            this.label1.Text = "Sınav No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(194, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 214;
            this.label4.Text = "Sınav Adı:";
            // 
            // bgwDegerlendirmeIlce
            // 
            this.bgwDegerlendirmeIlce.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDegerlendirmeIlce_DoWork);
            // 
            // cbExceleAktar
            // 
            this.cbExceleAktar.AutoSize = true;
            this.cbExceleAktar.Checked = true;
            this.cbExceleAktar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExceleAktar.Location = new System.Drawing.Point(14, 200);
            this.cbExceleAktar.Margin = new System.Windows.Forms.Padding(2);
            this.cbExceleAktar.Name = "cbExceleAktar";
            this.cbExceleAktar.Size = new System.Drawing.Size(119, 17);
            this.cbExceleAktar.TabIndex = 220;
            this.cbExceleAktar.Text = "Genel Excel Oluştur";
            this.cbExceleAktar.UseVisualStyleBackColor = true;
            // 
            // FormDegerlendirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 334);
            this.Controls.Add(this.cbExceleAktar);
            this.Controls.Add(this.lblSinif);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSinavAdi);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnABKitapcigi);
            this.Controls.Add(this.cbExcelIlce);
            this.Controls.Add(this.btnDogruCevaplar);
            this.Controls.Add(this.lblGecenSure);
            this.Controls.Add(this.pbAna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDegerlendirme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDegerlendirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sınav Değerlendirme Formu";
            this.Load += new System.EventHandler(this.FormDegerlendirme_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbExcelIlce;
        private System.Windows.Forms.Button btnDogruCevaplar;
        private System.Windows.Forms.Label lblGecenSure;
        private System.Windows.Forms.ProgressBar pbAna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolSslKalanSure;
        private System.Windows.Forms.Button btnDegerlendirme1;
        private System.ComponentModel.BackgroundWorker bgwDegerlendirme1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnABKitapcigi;
        public System.Windows.Forms.Label lblSinif;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblSinavAdi;
        public System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgwDegerlendirmeIlce;
        private System.Windows.Forms.CheckBox cbExceleAktar;
    }
}