namespace dashboard1
{
    partial class BaseForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.addStructureButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.reservationsButton = new System.Windows.Forms.Button();
            this.structuresButton = new System.Windows.Forms.Button();
            this.trendsButton = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.Label();
            this.resize = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.dashboardButton);
            this.panel1.Controls.Add(this.addStructureButton);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.reservationsButton);
            this.panel1.Controls.Add(this.structuresButton);
            this.panel1.Controls.Add(this.trendsButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 610);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(82, 21);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(105, 88);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            // 
            // dashboardButton
            // 
            this.dashboardButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.dashboardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.dashboardButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.Location = new System.Drawing.Point(4, 159);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(242, 40);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "    Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = false;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // addStructureButton
            // 
            this.addStructureButton.AllowDrop = true;
            this.addStructureButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.addStructureButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addStructureButton.FlatAppearance.BorderSize = 0;
            this.addStructureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStructureButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.addStructureButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addStructureButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addStructureButton.Location = new System.Drawing.Point(0, 307);
            this.addStructureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStructureButton.Name = "addStructureButton";
            this.addStructureButton.Size = new System.Drawing.Size(246, 40);
            this.addStructureButton.TabIndex = 3;
            this.addStructureButton.Text = "   Aggiungi";
            this.addStructureButton.UseVisualStyleBackColor = false;
            this.addStructureButton.Click += new System.EventHandler(this.addStructureButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logoutButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.logoutButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(0, 407);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(246, 40);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // reservationsButton
            // 
            this.reservationsButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.reservationsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reservationsButton.FlatAppearance.BorderSize = 0;
            this.reservationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reservationsButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.reservationsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reservationsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reservationsButton.Location = new System.Drawing.Point(0, 259);
            this.reservationsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reservationsButton.Name = "reservationsButton";
            this.reservationsButton.Size = new System.Drawing.Size(246, 40);
            this.reservationsButton.TabIndex = 15;
            this.reservationsButton.Text = "        Prenotazioni";
            this.reservationsButton.UseVisualStyleBackColor = false;
            this.reservationsButton.Click += new System.EventHandler(this.reservationsButton_Click);
            // 
            // structuresButton
            // 
            this.structuresButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.structuresButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.structuresButton.FlatAppearance.BorderSize = 0;
            this.structuresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.structuresButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.structuresButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.structuresButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.structuresButton.Location = new System.Drawing.Point(0, 209);
            this.structuresButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.structuresButton.Name = "structuresButton";
            this.structuresButton.Size = new System.Drawing.Size(246, 40);
            this.structuresButton.TabIndex = 2;
            this.structuresButton.Text = "  Proprietà";
            this.structuresButton.UseVisualStyleBackColor = false;
            this.structuresButton.Click += new System.EventHandler(this.structuresButton_Click);
            // 
            // trendsButton
            // 
            this.trendsButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.trendsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trendsButton.FlatAppearance.BorderSize = 0;
            this.trendsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trendsButton.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.trendsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trendsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.trendsButton.Location = new System.Drawing.Point(0, 357);
            this.trendsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trendsButton.Name = "trendsButton";
            this.trendsButton.Size = new System.Drawing.Size(240, 40);
            this.trendsButton.TabIndex = 4;
            this.trendsButton.Text = "Trends";
            this.trendsButton.UseVisualStyleBackColor = false;
            this.trendsButton.Click += new System.EventHandler(this.trendsButton_Click);
            // 
            // header
            // 
            this.header.AccessibleName = "";
            this.header.BackColor = System.Drawing.Color.LightGray;
            this.header.Controls.Add(this.title);
            this.header.Controls.Add(this.nome);
            this.header.Controls.Add(this.resize);
            this.header.Controls.Add(this.close);
            this.header.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.header.Location = new System.Drawing.Point(238, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(823, 40);
            this.header.TabIndex = 13;
            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Black;
            this.title.Location = new System.Drawing.Point(326, 6);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 31);
            this.title.TabIndex = 3;
            // 
            // nome
            // 
            this.nome.AutoSize = true;
            this.nome.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.nome.ForeColor = System.Drawing.Color.Black;
            this.nome.Location = new System.Drawing.Point(21, 6);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(0, 32);
            this.nome.TabIndex = 2;
            // 
            // resize
            // 
            this.resize.AutoSize = true;
            this.resize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resize.ForeColor = System.Drawing.Color.Black;
            this.resize.Location = new System.Drawing.Point(768, 6);
            this.resize.Name = "resize";
            this.resize.Size = new System.Drawing.Size(20, 28);
            this.resize.TabIndex = 1;
            this.resize.Text = "-";
            this.resize.Click += new System.EventHandler(this.resize_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.ForeColor = System.Drawing.Color.Black;
            this.close.Location = new System.Drawing.Point(786, 8);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(24, 28);
            this.close.TabIndex = 0;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // BaseForm
            // 
            this.AccessibleName = "ptrov";
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button trendsButton;
        private System.Windows.Forms.Button structuresButton;
        private System.Windows.Forms.Button addStructureButton;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label resize;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label nome;
        private System.Windows.Forms.Button reservationsButton;
        protected System.Windows.Forms.Label title;
    }
}

