
namespace ODMSinavYazilimi
{
    partial class FormSorular
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
            this.dgSorular = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgSorular)).BeginInit();
            this.SuspendLayout();
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
            this.dgSorular.Location = new System.Drawing.Point(11, 11);
            this.dgSorular.Margin = new System.Windows.Forms.Padding(2);
            this.dgSorular.Name = "dgSorular";
            this.dgSorular.RowHeadersVisible = false;
            this.dgSorular.RowHeadersWidth = 51;
            this.dgSorular.RowTemplate.Height = 24;
            this.dgSorular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSorular.ShowEditingIcon = false;
            this.dgSorular.ShowRowErrors = false;
            this.dgSorular.Size = new System.Drawing.Size(599, 631);
            this.dgSorular.TabIndex = 202;
            // 
            // FormSorular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 653);
            this.Controls.Add(this.dgSorular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSorular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sorular";
            this.Load += new System.EventHandler(this.FormSorular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSorular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSorular;
    }
}