
namespace ODMSinavYazilimi
{
    partial class FormKutukIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKutukIslemleri));
            this.lblSinavAdi = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSinif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSinifSubetoExcel = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.dgvKutuk = new System.Windows.Forms.DataGridView();
            this.lblOgrSayisi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBilgi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKutuk)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSinavAdi
            // 
            this.lblSinavAdi.AutoSize = true;
            this.lblSinavAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinavAdi.Location = new System.Drawing.Point(427, 12);
            this.lblSinavAdi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinavAdi.Name = "lblSinavAdi";
            this.lblSinavAdi.Size = new System.Drawing.Size(13, 17);
            this.lblSinavAdi.TabIndex = 135;
            this.lblSinavAdi.Text = "-";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblId.Location = new System.Drawing.Point(78, 12);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 17);
            this.lblId.TabIndex = 134;
            this.lblId.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 133;
            this.label2.Text = "Sınav No :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(355, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 132;
            this.label1.Text = "Sınav Adı:";
            // 
            // lblSinif
            // 
            this.lblSinif.AutoSize = true;
            this.lblSinif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSinif.Location = new System.Drawing.Point(152, 12);
            this.lblSinif.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinif.Name = "lblSinif";
            this.lblSinif.Size = new System.Drawing.Size(16, 17);
            this.lblSinif.TabIndex = 137;
            this.lblSinif.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(110, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 136;
            this.label3.Text = "Sınıf :";
            // 
            // btnSinifSubetoExcel
            // 
            this.btnSinifSubetoExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinifSubetoExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnSinifSubetoExcel.Image")));
            this.btnSinifSubetoExcel.Location = new System.Drawing.Point(440, 40);
            this.btnSinifSubetoExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSinifSubetoExcel.Name = "btnSinifSubetoExcel";
            this.btnSinifSubetoExcel.Size = new System.Drawing.Size(150, 28);
            this.btnSinifSubetoExcel.TabIndex = 190;
            this.btnSinifSubetoExcel.Text = "Şube Sayılarını Çıkar";
            this.btnSinifSubetoExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSinifSubetoExcel.UseVisualStyleBackColor = true;
            this.btnSinifSubetoExcel.Click += new System.EventHandler(this.btnSinifSubetoExcel_Click);
            // 
            // btnAra
            // 
            this.btnAra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAra.Location = new System.Drawing.Point(351, 40);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(82, 28);
            this.btnAra.TabIndex = 189;
            this.btnAra.Text = "Bul";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtAra
            // 
            this.txtAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(8, 40);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(338, 26);
            this.txtAra.TabIndex = 188;
            // 
            // dgvKutuk
            // 
            this.dgvKutuk.AllowUserToAddRows = false;
            this.dgvKutuk.AllowUserToDeleteRows = false;
            this.dgvKutuk.AllowUserToOrderColumns = true;
            this.dgvKutuk.AllowUserToResizeColumns = false;
            this.dgvKutuk.AllowUserToResizeRows = false;
            this.dgvKutuk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKutuk.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvKutuk.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKutuk.Location = new System.Drawing.Point(8, 104);
            this.dgvKutuk.MultiSelect = false;
            this.dgvKutuk.Name = "dgvKutuk";
            this.dgvKutuk.RowHeadersVisible = false;
            this.dgvKutuk.RowHeadersWidth = 51;
            this.dgvKutuk.RowTemplate.Height = 24;
            this.dgvKutuk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKutuk.ShowEditingIcon = false;
            this.dgvKutuk.ShowRowErrors = false;
            this.dgvKutuk.Size = new System.Drawing.Size(960, 555);
            this.dgvKutuk.TabIndex = 187;
            // 
            // lblOgrSayisi
            // 
            this.lblOgrSayisi.AutoSize = true;
            this.lblOgrSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOgrSayisi.Location = new System.Drawing.Point(303, 12);
            this.lblOgrSayisi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOgrSayisi.Name = "lblOgrSayisi";
            this.lblOgrSayisi.Size = new System.Drawing.Size(16, 17);
            this.lblOgrSayisi.TabIndex = 192;
            this.lblOgrSayisi.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(193, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 18);
            this.label5.TabIndex = 191;
            this.label5.Text = "Öğrenci Sayısı :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(595, 42);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(373, 24);
            this.progressBar1.TabIndex = 193;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.Location = new System.Drawing.Point(440, 73);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(454, 14);
            this.lblBilgi.TabIndex = 194;
            this.lblBilgi.Text = "Liste kurum internet sitesindeki listeyi getirir. Değişiklikleri almak için günce" +
    "lle butonuna tıklayın.";
            this.lblBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormKutukIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 670);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblOgrSayisi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSinifSubetoExcel);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.dgvKutuk);
            this.Controls.Add(this.lblSinif);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSinavAdi);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKutukIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kütük İşlemleri";
            this.Load += new System.EventHandler(this.FormKutukIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKutuk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblSinavAdi;
        public System.Windows.Forms.Label lblId;
        public System.Windows.Forms.Label lblSinif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSinifSubetoExcel;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.DataGridView dgvKutuk;
        public System.Windows.Forms.Label lblOgrSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblBilgi;
    }
}