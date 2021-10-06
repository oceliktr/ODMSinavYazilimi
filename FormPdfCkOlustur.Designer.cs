
namespace ODMSinavYazilimi
{
    partial class FormPdfCkOlustur
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
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbOkullar = new System.Windows.Forms.ComboBox();
            this.cbIlceler = new System.Windows.Forms.ComboBox();
            this.lbBirinciOturum = new System.Windows.Forms.ListBox();
            this.lbIkinciOturum = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBaslik = new System.Windows.Forms.TextBox();
            this.lblIkinciOturum = new System.Windows.Forms.Label();
            this.lblBirinciOturum = new System.Windows.Forms.Label();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.cboxSablon = new System.Windows.Forms.CheckBox();
            this.btnGozat = new System.Windows.Forms.Button();
            this.BgwPdfOlustur = new System.ComponentModel.BackgroundWorker();
            this.txtSablon = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbKagitBoyutu = new System.Windows.Forms.ComboBox();
            this.btnCkPdfOlustur = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbUcuncuOturum = new System.Windows.Forms.ListBox();
            this.lblUcuncuOturum = new System.Windows.Forms.Label();
            this.lbDorduncuOturum = new System.Windows.Forms.ListBox();
            this.lblDorduncuOturum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sağaAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solaAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yukarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aşağıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(371, 436);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 238;
            this.label9.Text = "Okul :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(11, 436);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 18);
            this.label10.TabIndex = 237;
            this.label10.Text = "İlçe :";
            // 
            // cbOkullar
            // 
            this.cbOkullar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbOkullar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOkullar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbOkullar.FormattingEnabled = true;
            this.cbOkullar.Location = new System.Drawing.Point(423, 431);
            this.cbOkullar.Name = "cbOkullar";
            this.cbOkullar.Size = new System.Drawing.Size(385, 28);
            this.cbOkullar.TabIndex = 236;
            this.cbOkullar.SelectedIndexChanged += new System.EventHandler(this.cbOkullar_SelectedIndexChanged);
            // 
            // cbIlceler
            // 
            this.cbIlceler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIlceler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIlceler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbIlceler.FormattingEnabled = true;
            this.cbIlceler.Location = new System.Drawing.Point(53, 431);
            this.cbIlceler.Name = "cbIlceler";
            this.cbIlceler.Size = new System.Drawing.Size(300, 28);
            this.cbIlceler.TabIndex = 235;
            this.cbIlceler.SelectedIndexChanged += new System.EventHandler(this.cbIlceler_SelectedIndexChanged);
            // 
            // lbBirinciOturum
            // 
            this.lbBirinciOturum.ContextMenuStrip = this.contextMenuStrip1;
            this.lbBirinciOturum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbBirinciOturum.Enabled = false;
            this.lbBirinciOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbBirinciOturum.FormattingEnabled = true;
            this.lbBirinciOturum.ItemHeight = 18;
            this.lbBirinciOturum.Location = new System.Drawing.Point(9, 40);
            this.lbBirinciOturum.Margin = new System.Windows.Forms.Padding(2);
            this.lbBirinciOturum.Name = "lbBirinciOturum";
            this.lbBirinciOturum.Size = new System.Drawing.Size(185, 220);
            this.lbBirinciOturum.TabIndex = 197;
            // 
            // lbIkinciOturum
            // 
            this.lbIkinciOturum.ContextMenuStrip = this.contextMenuStrip2;
            this.lbIkinciOturum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbIkinciOturum.Enabled = false;
            this.lbIkinciOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbIkinciOturum.FormattingEnabled = true;
            this.lbIkinciOturum.ItemHeight = 18;
            this.lbIkinciOturum.Location = new System.Drawing.Point(212, 40);
            this.lbIkinciOturum.Margin = new System.Windows.Forms.Padding(2);
            this.lbIkinciOturum.Name = "lbIkinciOturum";
            this.lbIkinciOturum.Size = new System.Drawing.Size(185, 220);
            this.lbIkinciOturum.TabIndex = 198;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(-232, 304);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 18);
            this.label5.TabIndex = 209;
            this.label5.Text = "CK Başlık (En fazla 4 satır)";
            this.label5.Visible = false;
            // 
            // txtBaslik
            // 
            this.txtBaslik.Location = new System.Drawing.Point(9, 319);
            this.txtBaslik.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaslik.Multiline = true;
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(788, 67);
            this.txtBaslik.TabIndex = 208;
            this.txtBaslik.Text = "T.C.\r\nERZURUM VALİLİĞİ\r\nİL MİLLİ EĞİTİM MÜDÜRLÜĞÜ\r\nÜnite Kazanım Değerlendirme Sı" +
    "navı Cevap Anahtarı";
            this.txtBaslik.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIkinciOturum
            // 
            this.lblIkinciOturum.AutoSize = true;
            this.lblIkinciOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIkinciOturum.Location = new System.Drawing.Point(212, 18);
            this.lblIkinciOturum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIkinciOturum.Name = "lblIkinciOturum";
            this.lblIkinciOturum.Size = new System.Drawing.Size(158, 18);
            this.lblIkinciOturum.TabIndex = 207;
            this.lblIkinciOturum.Text = "İkinci Oturum Dersleri :";
            // 
            // lblBirinciOturum
            // 
            this.lblBirinciOturum.AutoSize = true;
            this.lblBirinciOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBirinciOturum.Location = new System.Drawing.Point(9, 18);
            this.lblBirinciOturum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBirinciOturum.Name = "lblBirinciOturum";
            this.lblBirinciOturum.Size = new System.Drawing.Size(165, 18);
            this.lblBirinciOturum.TabIndex = 206;
            this.lblBirinciOturum.Text = "Birinci Oturum Dersleri :";
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgi.Location = new System.Drawing.Point(11, 475);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(16, 13);
            this.lblBilgi.TabIndex = 222;
            this.lblBilgi.Text = "...";
            this.lblBilgi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboxSablon
            // 
            this.cboxSablon.AutoSize = true;
            this.cboxSablon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboxSablon.Location = new System.Drawing.Point(11, 543);
            this.cboxSablon.Margin = new System.Windows.Forms.Padding(2);
            this.cboxSablon.Name = "cboxSablon";
            this.cboxSablon.Size = new System.Drawing.Size(94, 17);
            this.cboxSablon.TabIndex = 233;
            this.cboxSablon.Text = "Şablona Baskı";
            this.cboxSablon.UseVisualStyleBackColor = true;
            this.cboxSablon.CheckedChanged += new System.EventHandler(this.cboxSablon_CheckedChanged);
            // 
            // btnGozat
            // 
            this.btnGozat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGozat.Enabled = false;
            this.btnGozat.Location = new System.Drawing.Point(703, 543);
            this.btnGozat.Margin = new System.Windows.Forms.Padding(2);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(105, 22);
            this.btnGozat.TabIndex = 231;
            this.btnGozat.Text = "Gözat";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // BgwPdfOlustur
            // 
            this.BgwPdfOlustur.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwPdfOlustur_DoWork);
            // 
            // txtSablon
            // 
            this.txtSablon.Enabled = false;
            this.txtSablon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSablon.Location = new System.Drawing.Point(115, 543);
            this.txtSablon.Margin = new System.Windows.Forms.Padding(2);
            this.txtSablon.Name = "txtSablon";
            this.txtSablon.Size = new System.Drawing.Size(584, 21);
            this.txtSablon.TabIndex = 232;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(590, 471);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 230;
            this.label6.Text = "Kağıt Boyutu :";
            // 
            // cbKagitBoyutu
            // 
            this.cbKagitBoyutu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbKagitBoyutu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKagitBoyutu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbKagitBoyutu.FormattingEnabled = true;
            this.cbKagitBoyutu.Location = new System.Drawing.Point(703, 468);
            this.cbKagitBoyutu.Name = "cbKagitBoyutu";
            this.cbKagitBoyutu.Size = new System.Drawing.Size(105, 24);
            this.cbKagitBoyutu.TabIndex = 229;
            // 
            // btnCkPdfOlustur
            // 
            this.btnCkPdfOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCkPdfOlustur.Location = new System.Drawing.Point(703, 505);
            this.btnCkPdfOlustur.Margin = new System.Windows.Forms.Padding(2);
            this.btnCkPdfOlustur.Name = "btnCkPdfOlustur";
            this.btnCkPdfOlustur.Size = new System.Drawing.Size(105, 23);
            this.btnCkPdfOlustur.TabIndex = 224;
            this.btnCkPdfOlustur.Text = "CK Oluştur";
            this.btnCkPdfOlustur.UseVisualStyleBackColor = true;
            this.btnCkPdfOlustur.Click += new System.EventHandler(this.btnCkPdfOlustur_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 505);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(688, 23);
            this.progressBar1.TabIndex = 223;
            // 
            // lbUcuncuOturum
            // 
            this.lbUcuncuOturum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbUcuncuOturum.Enabled = false;
            this.lbUcuncuOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbUcuncuOturum.FormattingEnabled = true;
            this.lbUcuncuOturum.ItemHeight = 18;
            this.lbUcuncuOturum.Location = new System.Drawing.Point(412, 40);
            this.lbUcuncuOturum.Margin = new System.Windows.Forms.Padding(2);
            this.lbUcuncuOturum.Name = "lbUcuncuOturum";
            this.lbUcuncuOturum.Size = new System.Drawing.Size(185, 220);
            this.lbUcuncuOturum.TabIndex = 210;
            // 
            // lblUcuncuOturum
            // 
            this.lblUcuncuOturum.AutoSize = true;
            this.lblUcuncuOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUcuncuOturum.Location = new System.Drawing.Point(412, 18);
            this.lblUcuncuOturum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUcuncuOturum.Name = "lblUcuncuOturum";
            this.lblUcuncuOturum.Size = new System.Drawing.Size(176, 18);
            this.lblUcuncuOturum.TabIndex = 211;
            this.lblUcuncuOturum.Text = "Üçüncü Oturum Dersleri :";
            // 
            // lbDorduncuOturum
            // 
            this.lbDorduncuOturum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDorduncuOturum.Enabled = false;
            this.lbDorduncuOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDorduncuOturum.FormattingEnabled = true;
            this.lbDorduncuOturum.ItemHeight = 18;
            this.lbDorduncuOturum.Location = new System.Drawing.Point(612, 40);
            this.lbDorduncuOturum.Margin = new System.Windows.Forms.Padding(2);
            this.lbDorduncuOturum.Name = "lbDorduncuOturum";
            this.lbDorduncuOturum.Size = new System.Drawing.Size(185, 220);
            this.lbDorduncuOturum.TabIndex = 212;
            // 
            // lblDorduncuOturum
            // 
            this.lblDorduncuOturum.AutoSize = true;
            this.lblDorduncuOturum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDorduncuOturum.Location = new System.Drawing.Point(612, 18);
            this.lblDorduncuOturum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDorduncuOturum.Name = "lblDorduncuOturum";
            this.lblDorduncuOturum.Size = new System.Drawing.Size(190, 18);
            this.lblDorduncuOturum.TabIndex = 213;
            this.lblDorduncuOturum.Text = "Dördüncü Oturum Dersleri :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 229;
            this.label2.Text = "Dersler optik formdaki sıraya göre sıralanmalıdır.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbDorduncuOturum);
            this.groupBox1.Controls.Add(this.lblBirinciOturum);
            this.groupBox1.Controls.Add(this.lblDorduncuOturum);
            this.groupBox1.Controls.Add(this.lblIkinciOturum);
            this.groupBox1.Controls.Add(this.lbUcuncuOturum);
            this.groupBox1.Controls.Add(this.txtBaslik);
            this.groupBox1.Controls.Add(this.lblUcuncuOturum);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbBirinciOturum);
            this.groupBox1.Controls.Add(this.lbIkinciOturum);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 402);
            this.groupBox1.TabIndex = 230;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Oturumlar";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yukarıToolStripMenuItem,
            this.aşağıToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sağaAktarToolStripMenuItem,
            this.solaAktarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.silToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 126);
            // 
            // sağaAktarToolStripMenuItem
            // 
            this.sağaAktarToolStripMenuItem.Name = "sağaAktarToolStripMenuItem";
            this.sağaAktarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sağaAktarToolStripMenuItem.Text = "Sağa Aktar";
            this.sağaAktarToolStripMenuItem.Click += new System.EventHandler(this.sağaAktarToolStripMenuItem_Click);
            // 
            // solaAktarToolStripMenuItem
            // 
            this.solaAktarToolStripMenuItem.Enabled = false;
            this.solaAktarToolStripMenuItem.Name = "solaAktarToolStripMenuItem";
            this.solaAktarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.solaAktarToolStripMenuItem.Text = "Sola Aktar";
            // 
            // yukarıToolStripMenuItem
            // 
            this.yukarıToolStripMenuItem.Name = "yukarıToolStripMenuItem";
            this.yukarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yukarıToolStripMenuItem.Text = "Yukarı";
            this.yukarıToolStripMenuItem.Click += new System.EventHandler(this.yukarıToolStripMenuItem_Click);
            // 
            // aşağıToolStripMenuItem
            // 
            this.aşağıToolStripMenuItem.Name = "aşağıToolStripMenuItem";
            this.aşağıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aşağıToolStripMenuItem.Text = "Aşağı";
            this.aşağıToolStripMenuItem.Click += new System.EventHandler(this.aşağıToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator2,
            this.toolStripMenuItem7});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(181, 148);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Yukarı";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "Aşağı";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "Sağa Aktar";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "Sola Aktar";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem7.Text = "Sil";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // FormPdfCkOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 581);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbOkullar);
            this.Controls.Add(this.cbIlceler);
            this.Controls.Add(this.lblBilgi);
            this.Controls.Add(this.cboxSablon);
            this.Controls.Add(this.btnGozat);
            this.Controls.Add(this.txtSablon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbKagitBoyutu);
            this.Controls.Add(this.btnCkPdfOlustur);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPdfCkOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CK Oluşturma İşlemleri";
            this.Load += new System.EventHandler(this.FormPdfCkOlustur_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbOkullar;
        private System.Windows.Forms.ComboBox cbIlceler;
        private System.Windows.Forms.ListBox lbBirinciOturum;
        private System.Windows.Forms.ListBox lbIkinciOturum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBaslik;
        private System.Windows.Forms.Label lblIkinciOturum;
        private System.Windows.Forms.Label lblBirinciOturum;
        private System.Windows.Forms.Label lblBilgi;
        private System.Windows.Forms.CheckBox cboxSablon;
        private System.Windows.Forms.Button btnGozat;
        private System.ComponentModel.BackgroundWorker BgwPdfOlustur;
        private System.Windows.Forms.TextBox txtSablon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbKagitBoyutu;
        private System.Windows.Forms.Button btnCkPdfOlustur;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDorduncuOturum;
        private System.Windows.Forms.Label lblDorduncuOturum;
        private System.Windows.Forms.ListBox lbUcuncuOturum;
        private System.Windows.Forms.Label lblUcuncuOturum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sağaAktarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solaAktarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yukarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aşağıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
    }
}