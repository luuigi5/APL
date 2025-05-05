namespace dashboard1
{
    partial class StructuresList
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
            this.Proprietà = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Proprietà
            // 
            this.Proprietà.AutoSize = true;
            this.Proprietà.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proprietà.ForeColor = System.Drawing.Color.Black;
            this.Proprietà.Location = new System.Drawing.Point(647, 43);
            this.Proprietà.Name = "Proprietà";
            this.Proprietà.Size = new System.Drawing.Size(108, 31);
            this.Proprietà.TabIndex = 14;
            this.Proprietà.Text = "Proprietà";
            // 
            // StructuresList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 679);
            this.Controls.Add(this.Proprietà);
            this.Name = "StructuresList";
            this.Text = "Form2";
            this.Controls.SetChildIndex(this.Proprietà, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Proprietà;
    }
}