namespace dashboard1
{
    partial class AddStructure
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
            this.rooms = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.Label();
            this.Indirizzo = new System.Windows.Forms.Label();
            this.Città = new System.Windows.Forms.Label();
            this.NomeStruttura = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.cityInput = new System.Windows.Forms.TextBox();
            this.addressInput = new System.Windows.Forms.TextBox();
            this.typeInput = new System.Windows.Forms.TextBox();
            this.roomsInput = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.imglink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rooms
            // 
            this.rooms.AutoSize = true;
            this.rooms.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.rooms.ForeColor = System.Drawing.Color.Black;
            this.rooms.Location = new System.Drawing.Point(339, 349);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(177, 32);
            this.rooms.TabIndex = 15;
            this.rooms.Text = "Numero stanze";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.type.ForeColor = System.Drawing.Color.Black;
            this.type.Location = new System.Drawing.Point(823, 293);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(160, 32);
            this.type.TabIndex = 16;
            this.type.Text = "Tipo Struttura";
            // 
            // Indirizzo
            // 
            this.Indirizzo.AutoSize = true;
            this.Indirizzo.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.Indirizzo.ForeColor = System.Drawing.Color.Black;
            this.Indirizzo.Location = new System.Drawing.Point(337, 294);
            this.Indirizzo.Name = "Indirizzo";
            this.Indirizzo.Size = new System.Drawing.Size(104, 32);
            this.Indirizzo.TabIndex = 17;
            this.Indirizzo.Text = "Indirizzo";
            // 
            // Città
            // 
            this.Città.AutoSize = true;
            this.Città.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.Città.ForeColor = System.Drawing.Color.Black;
            this.Città.Location = new System.Drawing.Point(823, 238);
            this.Città.Name = "Città";
            this.Città.Size = new System.Drawing.Size(63, 32);
            this.Città.TabIndex = 18;
            this.Città.Text = "Città";
            // 
            // NomeStruttura
            // 
            this.NomeStruttura.AutoSize = true;
            this.NomeStruttura.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.NomeStruttura.ForeColor = System.Drawing.Color.Black;
            this.NomeStruttura.Location = new System.Drawing.Point(337, 236);
            this.NomeStruttura.Name = "NomeStruttura";
            this.NomeStruttura.Size = new System.Drawing.Size(179, 32);
            this.NomeStruttura.TabIndex = 19;
            this.NomeStruttura.Text = "Nome Struttura";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(522, 236);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(235, 34);
            this.nameInput.TabIndex = 20;
            // 
            // cityInput
            // 
            this.cityInput.Location = new System.Drawing.Point(1002, 234);
            this.cityInput.Name = "cityInput";
            this.cityInput.Size = new System.Drawing.Size(235, 34);
            this.cityInput.TabIndex = 21;
            // 
            // addressInput
            // 
            this.addressInput.Location = new System.Drawing.Point(522, 292);
            this.addressInput.Name = "addressInput";
            this.addressInput.Size = new System.Drawing.Size(235, 34);
            this.addressInput.TabIndex = 22;
            // 
            // typeInput
            // 
            this.typeInput.Location = new System.Drawing.Point(1002, 295);
            this.typeInput.Name = "typeInput";
            this.typeInput.Size = new System.Drawing.Size(235, 34);
            this.typeInput.TabIndex = 23;
            // 
            // roomsInput
            // 
            this.roomsInput.Location = new System.Drawing.Point(522, 349);
            this.roomsInput.Name = "roomsInput";
            this.roomsInput.Size = new System.Drawing.Size(235, 34);
            this.roomsInput.TabIndex = 24;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(725, 437);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 38);
            this.button6.TabIndex = 25;
            this.button6.Text = "Aggiungi";
            this.button6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // imglink
            // 
            this.imglink.Location = new System.Drawing.Point(1002, 351);
            this.imglink.Name = "imglink";
            this.imglink.Size = new System.Drawing.Size(235, 34);
            this.imglink.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(823, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "Link Immagine";
            // 
            // AddStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 679);
            this.Controls.Add(this.imglink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.roomsInput);
            this.Controls.Add(this.typeInput);
            this.Controls.Add(this.addressInput);
            this.Controls.Add(this.cityInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.NomeStruttura);
            this.Controls.Add(this.Città);
            this.Controls.Add(this.Indirizzo);
            this.Controls.Add(this.type);
            this.Controls.Add(this.rooms);
            this.Name = "AddStructure";
            this.Text = "Form2";
            this.Controls.SetChildIndex(this.rooms, 0);
            this.Controls.SetChildIndex(this.type, 0);
            this.Controls.SetChildIndex(this.Indirizzo, 0);
            this.Controls.SetChildIndex(this.Città, 0);
            this.Controls.SetChildIndex(this.NomeStruttura, 0);
            this.Controls.SetChildIndex(this.nameInput, 0);
            this.Controls.SetChildIndex(this.cityInput, 0);
            this.Controls.SetChildIndex(this.addressInput, 0);
            this.Controls.SetChildIndex(this.typeInput, 0);
            this.Controls.SetChildIndex(this.roomsInput, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.imglink, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label rooms;
        private System.Windows.Forms.Label type;
        private System.Windows.Forms.Label Indirizzo;
        private System.Windows.Forms.Label Città;
        private System.Windows.Forms.Label NomeStruttura;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox cityInput;
        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.TextBox typeInput;
        private System.Windows.Forms.TextBox roomsInput;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox imglink;
        private System.Windows.Forms.Label label2;
    }
}