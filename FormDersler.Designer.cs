
namespace ODMSinavYazilimi
{
    partial class FormDersler
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
            ((System.ComponentModel.ISupportInitialize)(this.dgBranslar)).BeginInit();
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
            this.dgBranslar.Location = new System.Drawing.Point(11, 11);
            this.dgBranslar.Margin = new System.Windows.Forms.Padding(2);
            this.dgBranslar.Name = "dgBranslar";
            this.dgBranslar.RowHeadersVisible = false;
            this.dgBranslar.RowHeadersWidth = 51;
            this.dgBranslar.RowTemplate.Height = 24;
            this.dgBranslar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBranslar.ShowEditingIcon = false;
            this.dgBranslar.ShowRowErrors = false;
            this.dgBranslar.Size = new System.Drawing.Size(310, 397);
            this.dgBranslar.TabIndex = 201;
            // 
            // FormDersler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 425);
            this.Controls.Add(this.dgBranslar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDersler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dersler";
            this.Load += new System.EventHandler(this.FormDersler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBranslar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgBranslar;
    }
}