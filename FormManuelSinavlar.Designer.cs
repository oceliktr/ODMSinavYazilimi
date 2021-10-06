
namespace ODMSinavYazilimi
{
    partial class FormManuelSinavlar
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
            this.dgSinavlar = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seçiliSınavıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExceldenYukle = new System.Windows.Forms.Button();
            this.dgSorular = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgSinavlar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSorular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSinavlar
            // 
            this.dgSinavlar.AllowUserToAddRows = false;
            this.dgSinavlar.AllowUserToDeleteRows = false;
            this.dgSinavlar.AllowUserToOrderColumns = true;
            this.dgSinavlar.AllowUserToResizeColumns = false;
            this.dgSinavlar.AllowUserToResizeRows = false;
            this.dgSinavlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSinavlar.ContextMenuStrip = this.contextMenuStrip1;
            this.dgSinavlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgSinavlar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgSinavlar.Location = new System.Drawing.Point(27, 36);
            this.dgSinavlar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSinavlar.Name = "dgSinavlar";
            this.dgSinavlar.RowHeadersVisible = false;
            this.dgSinavlar.RowHeadersWidth = 51;
            this.dgSinavlar.RowTemplate.Height = 24;
            this.dgSinavlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSinavlar.ShowEditingIcon = false;
            this.dgSinavlar.ShowRowErrors = false;
            this.dgSinavlar.Size = new System.Drawing.Size(927, 268);
            this.dgSinavlar.TabIndex = 201;
            this.dgSinavlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSinavlar_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seçiliSınavıSilToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 28);
            // 
            // seçiliSınavıSilToolStripMenuItem
            // 
            this.seçiliSınavıSilToolStripMenuItem.Name = "seçiliSınavıSilToolStripMenuItem";
            this.seçiliSınavıSilToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.seçiliSınavıSilToolStripMenuItem.Text = "Seçili Sınavı Sil";
            this.seçiliSınavıSilToolStripMenuItem.Click += new System.EventHandler(this.seçiliSınavıSilToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 202;
            this.label1.Text = "Manuel Sınavlar :";
            // 
            // btnExceldenYukle
            // 
            this.btnExceldenYukle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExceldenYukle.Location = new System.Drawing.Point(721, 310);
            this.btnExceldenYukle.Margin = new System.Windows.Forms.Padding(4);
            this.btnExceldenYukle.Name = "btnExceldenYukle";
            this.btnExceldenYukle.Size = new System.Drawing.Size(232, 68);
            this.btnExceldenYukle.TabIndex = 205;
            this.btnExceldenYukle.Text = "Excel\'den Sınav Yükle";
            this.btnExceldenYukle.UseVisualStyleBackColor = true;
            this.btnExceldenYukle.Click += new System.EventHandler(this.btnExceldenYukle_Click);
            // 
            // dgSorular
            // 
            this.dgSorular.AllowUserToAddRows = false;
            this.dgSorular.AllowUserToDeleteRows = false;
            this.dgSorular.AllowUserToOrderColumns = true;
            this.dgSorular.AllowUserToResizeColumns = false;
            this.dgSorular.AllowUserToResizeRows = false;
            this.dgSorular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSorular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgSorular.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgSorular.Location = new System.Drawing.Point(960, 36);
            this.dgSorular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgSorular.Name = "dgSorular";
            this.dgSorular.RowHeadersVisible = false;
            this.dgSorular.RowHeadersWidth = 51;
            this.dgSorular.RowTemplate.Height = 24;
            this.dgSorular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSorular.ShowEditingIcon = false;
            this.dgSorular.ShowRowErrors = false;
            this.dgSorular.Size = new System.Drawing.Size(825, 342);
            this.dgSorular.TabIndex = 209;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(956, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 210;
            this.label2.Text = "Sorular :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(515, 17);
            this.label3.TabIndex = 211;
            this.label3.Text = "Örnek fotoğrafta gösterildiği gibi excel dosyasını oluşturup sınav yükleyebilirsi" +
    "niz.";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(27, 310);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 30);
            this.button1.TabIndex = 212;
            this.button1.Text = "Örnek Dosya Aç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ODMSinavYazilimi.Properties.Resources.manuelsinavekleme;
            this.pictureBox1.Location = new System.Drawing.Point(27, 385);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(936, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 213;
            this.pictureBox1.TabStop = false;
            // 
            // FormManuelSinavlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1799, 927);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgSorular);
            this.Controls.Add(this.btnExceldenYukle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgSinavlar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManuelSinavlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manuel Sınavlar Modülü";
            this.Load += new System.EventHandler(this.FormManuelSinavlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSinavlar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSorular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSinavlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExceldenYukle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem seçiliSınavıSilToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgSorular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}