namespace BikeZone.Podobrasci
{
    partial class Evidencija_Stavke_Racuna
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
            this.Odustani_btn = new System.Windows.Forms.Button();
            this.Pohrani_btn = new System.Windows.Forms.Button();
            this.Kolicina_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProizvodiUsluge_combobox = new System.Windows.Forms.ComboBox();
            this.Usluga_checkbox = new System.Windows.Forms.CheckBox();
            this.Popravljen_checkbox = new System.Windows.Forms.CheckBox();
            this.DatumPopravka_datepicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Odustani_btn
            // 
            this.Odustani_btn.Location = new System.Drawing.Point(220, 179);
            this.Odustani_btn.Name = "Odustani_btn";
            this.Odustani_btn.Size = new System.Drawing.Size(75, 23);
            this.Odustani_btn.TabIndex = 15;
            this.Odustani_btn.Text = "Odustani";
            this.Odustani_btn.UseVisualStyleBackColor = true;
            this.Odustani_btn.Click += new System.EventHandler(this.Odustani_btn_Click);
            // 
            // Pohrani_btn
            // 
            this.Pohrani_btn.Location = new System.Drawing.Point(139, 179);
            this.Pohrani_btn.Name = "Pohrani_btn";
            this.Pohrani_btn.Size = new System.Drawing.Size(75, 23);
            this.Pohrani_btn.TabIndex = 14;
            this.Pohrani_btn.Text = "Pohrani";
            this.Pohrani_btn.UseVisualStyleBackColor = true;
            this.Pohrani_btn.Click += new System.EventHandler(this.Pohrani_btn_Click);
            // 
            // Kolicina_textbox
            // 
            this.Kolicina_textbox.Location = new System.Drawing.Point(98, 81);
            this.Kolicina_textbox.Name = "Kolicina_textbox";
            this.Kolicina_textbox.Size = new System.Drawing.Size(75, 20);
            this.Kolicina_textbox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Količina:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Proizvod:";
            // 
            // ProizvodiUsluge_combobox
            // 
            this.ProizvodiUsluge_combobox.FormattingEnabled = true;
            this.ProizvodiUsluge_combobox.Location = new System.Drawing.Point(98, 52);
            this.ProizvodiUsluge_combobox.Name = "ProizvodiUsluge_combobox";
            this.ProizvodiUsluge_combobox.Size = new System.Drawing.Size(197, 21);
            this.ProizvodiUsluge_combobox.TabIndex = 7;
            // 
            // Usluga_checkbox
            // 
            this.Usluga_checkbox.AutoSize = true;
            this.Usluga_checkbox.Location = new System.Drawing.Point(98, 29);
            this.Usluga_checkbox.Name = "Usluga_checkbox";
            this.Usluga_checkbox.Size = new System.Drawing.Size(59, 17);
            this.Usluga_checkbox.TabIndex = 6;
            this.Usluga_checkbox.Text = "Usluga";
            this.Usluga_checkbox.UseVisualStyleBackColor = true;
            this.Usluga_checkbox.CheckedChanged += new System.EventHandler(this.Usluga_checkbox_CheckedChanged);
            // 
            // Popravljen_checkbox
            // 
            this.Popravljen_checkbox.AutoSize = true;
            this.Popravljen_checkbox.Enabled = false;
            this.Popravljen_checkbox.Location = new System.Drawing.Point(97, 120);
            this.Popravljen_checkbox.Name = "Popravljen_checkbox";
            this.Popravljen_checkbox.Size = new System.Drawing.Size(76, 17);
            this.Popravljen_checkbox.TabIndex = 6;
            this.Popravljen_checkbox.Text = "Popravljen";
            this.Popravljen_checkbox.UseVisualStyleBackColor = true;
            this.Popravljen_checkbox.CheckedChanged += new System.EventHandler(this.Popravljen_checkbox_CheckedChanged);
            // 
            // DatumPopravka_datepicker
            // 
            this.DatumPopravka_datepicker.Enabled = false;
            this.DatumPopravka_datepicker.Location = new System.Drawing.Point(97, 144);
            this.DatumPopravka_datepicker.Name = "DatumPopravka_datepicker";
            this.DatumPopravka_datepicker.Size = new System.Drawing.Size(133, 20);
            this.DatumPopravka_datepicker.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(32, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "Datum popravka:";
            // 
            // Evidencija_Stavke_Racuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 214);
            this.Controls.Add(this.DatumPopravka_datepicker);
            this.Controls.Add(this.Odustani_btn);
            this.Controls.Add(this.Pohrani_btn);
            this.Controls.Add(this.Kolicina_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProizvodiUsluge_combobox);
            this.Controls.Add(this.Popravljen_checkbox);
            this.Controls.Add(this.Usluga_checkbox);
            this.Name = "Evidencija_Stavke_Racuna";
            this.Text = "Evidencija stavke računa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Odustani_btn;
        private System.Windows.Forms.Button Pohrani_btn;
        private System.Windows.Forms.TextBox Kolicina_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProizvodiUsluge_combobox;
        private System.Windows.Forms.CheckBox Usluga_checkbox;
        private System.Windows.Forms.CheckBox Popravljen_checkbox;
        private System.Windows.Forms.DateTimePicker DatumPopravka_datepicker;
        private System.Windows.Forms.Label label3;
    }
}