namespace BikeZone.Podobrasci
{
    partial class Evidencija_Stavke_Primke
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
            this.Bicikl_checkbox = new System.Windows.Forms.CheckBox();
            this.Proizvodi_combobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cijena_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Kolicina_textbox = new System.Windows.Forms.TextBox();
            this.Pohrani_btn = new System.Windows.Forms.Button();
            this.Odustani_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bicikl_checkbox
            // 
            this.Bicikl_checkbox.AutoSize = true;
            this.Bicikl_checkbox.Location = new System.Drawing.Point(98, 26);
            this.Bicikl_checkbox.Name = "Bicikl_checkbox";
            this.Bicikl_checkbox.Size = new System.Drawing.Size(51, 17);
            this.Bicikl_checkbox.TabIndex = 0;
            this.Bicikl_checkbox.Text = "Bicikl";
            this.Bicikl_checkbox.UseVisualStyleBackColor = true;
            this.Bicikl_checkbox.CheckedChanged += new System.EventHandler(this.Bicikl_checkbox_CheckedChanged);
            // 
            // Proizvodi_combobox
            // 
            this.Proizvodi_combobox.FormattingEnabled = true;
            this.Proizvodi_combobox.Location = new System.Drawing.Point(98, 49);
            this.Proizvodi_combobox.Name = "Proizvodi_combobox";
            this.Proizvodi_combobox.Size = new System.Drawing.Size(197, 21);
            this.Proizvodi_combobox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proizvod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Količina:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jedinična cijena:";
            // 
            // Cijena_textbox
            // 
            this.Cijena_textbox.Location = new System.Drawing.Point(98, 105);
            this.Cijena_textbox.Name = "Cijena_textbox";
            this.Cijena_textbox.Size = new System.Drawing.Size(75, 20);
            this.Cijena_textbox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "kn";
            // 
            // Kolicina_textbox
            // 
            this.Kolicina_textbox.Location = new System.Drawing.Point(98, 78);
            this.Kolicina_textbox.Name = "Kolicina_textbox";
            this.Kolicina_textbox.Size = new System.Drawing.Size(75, 20);
            this.Kolicina_textbox.TabIndex = 3;
            // 
            // Pohrani_btn
            // 
            this.Pohrani_btn.Location = new System.Drawing.Point(137, 162);
            this.Pohrani_btn.Name = "Pohrani_btn";
            this.Pohrani_btn.Size = new System.Drawing.Size(75, 23);
            this.Pohrani_btn.TabIndex = 4;
            this.Pohrani_btn.Text = "Pohrani";
            this.Pohrani_btn.UseVisualStyleBackColor = true;
            this.Pohrani_btn.Click += new System.EventHandler(this.Pohrani_btn_Click);
            // 
            // Odustani_btn
            // 
            this.Odustani_btn.Location = new System.Drawing.Point(218, 162);
            this.Odustani_btn.Name = "Odustani_btn";
            this.Odustani_btn.Size = new System.Drawing.Size(75, 23);
            this.Odustani_btn.TabIndex = 5;
            this.Odustani_btn.Text = "Odustani";
            this.Odustani_btn.UseVisualStyleBackColor = true;
            this.Odustani_btn.Click += new System.EventHandler(this.Odustani_btn_Click);
            // 
            // Evidencija_Stavke_Primke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 197);
            this.Controls.Add(this.Odustani_btn);
            this.Controls.Add(this.Pohrani_btn);
            this.Controls.Add(this.Kolicina_textbox);
            this.Controls.Add(this.Cijena_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Proizvodi_combobox);
            this.Controls.Add(this.Bicikl_checkbox);
            this.Name = "Evidencija_Stavke_Primke";
            this.Text = "Evidencija stavke primke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Bicikl_checkbox;
        private System.Windows.Forms.ComboBox Proizvodi_combobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Cijena_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Kolicina_textbox;
        private System.Windows.Forms.Button Pohrani_btn;
        private System.Windows.Forms.Button Odustani_btn;
    }
}