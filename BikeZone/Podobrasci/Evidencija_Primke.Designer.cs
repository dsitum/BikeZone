namespace BikeZone.Podobrasci
{
    partial class Evidencija_Primke
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
            this.StavkePrimke_datagrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Placeno_checkbox = new System.Windows.Forms.CheckBox();
            this.EvidencijaPrimke_btn = new System.Windows.Forms.Button();
            this.Odustani_btn = new System.Windows.Forms.Button();
            this.PodaciOPrimci = new System.Windows.Forms.GroupBox();
            this.DatumZaprimanja_datepicker = new System.Windows.Forms.DateTimePicker();
            this.Dobavljaci_combobox = new System.Windows.Forms.ComboBox();
            this.DodajStavkuPrimke_btn = new System.Windows.Forms.Button();
            this.UrediStavkuPrimke_btn = new System.Windows.Forms.Button();
            this.ObrišiStavkuPrimke_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StavkePrimke_datagrid)).BeginInit();
            this.PodaciOPrimci.SuspendLayout();
            this.SuspendLayout();
            // 
            // StavkePrimke_datagrid
            // 
            this.StavkePrimke_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StavkePrimke_datagrid.Location = new System.Drawing.Point(15, 169);
            this.StavkePrimke_datagrid.Name = "StavkePrimke_datagrid";
            this.StavkePrimke_datagrid.Size = new System.Drawing.Size(480, 200);
            this.StavkePrimke_datagrid.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stavke primke:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dobavljač:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datum zaprimanja:";
            // 
            // Placeno_checkbox
            // 
            this.Placeno_checkbox.AutoSize = true;
            this.Placeno_checkbox.Location = new System.Drawing.Point(105, 76);
            this.Placeno_checkbox.Name = "Placeno_checkbox";
            this.Placeno_checkbox.Size = new System.Drawing.Size(65, 17);
            this.Placeno_checkbox.TabIndex = 8;
            this.Placeno_checkbox.Text = "Plaćeno";
            this.Placeno_checkbox.UseVisualStyleBackColor = true;
            // 
            // EvidencijaPrimke_btn
            // 
            this.EvidencijaPrimke_btn.Location = new System.Drawing.Point(321, 17);
            this.EvidencijaPrimke_btn.Name = "EvidencijaPrimke_btn";
            this.EvidencijaPrimke_btn.Size = new System.Drawing.Size(75, 23);
            this.EvidencijaPrimke_btn.TabIndex = 9;
            this.EvidencijaPrimke_btn.Text = "button1";
            this.EvidencijaPrimke_btn.UseVisualStyleBackColor = true;
            this.EvidencijaPrimke_btn.Click += new System.EventHandler(this.EvidencijaPrimke_btn_Click);
            // 
            // Odustani_btn
            // 
            this.Odustani_btn.Location = new System.Drawing.Point(401, 17);
            this.Odustani_btn.Name = "Odustani_btn";
            this.Odustani_btn.Size = new System.Drawing.Size(75, 23);
            this.Odustani_btn.TabIndex = 9;
            this.Odustani_btn.Text = "Odustani";
            this.Odustani_btn.UseVisualStyleBackColor = true;
            this.Odustani_btn.Click += new System.EventHandler(this.Odustani_btn_Click);
            // 
            // PodaciOPrimci
            // 
            this.PodaciOPrimci.Controls.Add(this.DatumZaprimanja_datepicker);
            this.PodaciOPrimci.Controls.Add(this.Dobavljaci_combobox);
            this.PodaciOPrimci.Controls.Add(this.label1);
            this.PodaciOPrimci.Controls.Add(this.Odustani_btn);
            this.PodaciOPrimci.Controls.Add(this.Placeno_checkbox);
            this.PodaciOPrimci.Controls.Add(this.EvidencijaPrimke_btn);
            this.PodaciOPrimci.Controls.Add(this.label3);
            this.PodaciOPrimci.Location = new System.Drawing.Point(15, 12);
            this.PodaciOPrimci.Name = "PodaciOPrimci";
            this.PodaciOPrimci.Size = new System.Drawing.Size(486, 100);
            this.PodaciOPrimci.TabIndex = 10;
            this.PodaciOPrimci.TabStop = false;
            this.PodaciOPrimci.Text = "groupBox1";
            // 
            // DatumZaprimanja_datepicker
            // 
            this.DatumZaprimanja_datepicker.Location = new System.Drawing.Point(105, 50);
            this.DatumZaprimanja_datepicker.Name = "DatumZaprimanja_datepicker";
            this.DatumZaprimanja_datepicker.Size = new System.Drawing.Size(134, 20);
            this.DatumZaprimanja_datepicker.TabIndex = 10;
            // 
            // Dobavljaci_combobox
            // 
            this.Dobavljaci_combobox.FormattingEnabled = true;
            this.Dobavljaci_combobox.Location = new System.Drawing.Point(105, 20);
            this.Dobavljaci_combobox.Name = "Dobavljaci_combobox";
            this.Dobavljaci_combobox.Size = new System.Drawing.Size(195, 21);
            this.Dobavljaci_combobox.TabIndex = 9;
            // 
            // DodajStavkuPrimke_btn
            // 
            this.DodajStavkuPrimke_btn.Location = new System.Drawing.Point(230, 140);
            this.DodajStavkuPrimke_btn.Name = "DodajStavkuPrimke_btn";
            this.DodajStavkuPrimke_btn.Size = new System.Drawing.Size(83, 23);
            this.DodajStavkuPrimke_btn.TabIndex = 11;
            this.DodajStavkuPrimke_btn.Text = "Dodaj stavku";
            this.DodajStavkuPrimke_btn.UseVisualStyleBackColor = true;
            this.DodajStavkuPrimke_btn.Click += new System.EventHandler(this.DodajStavkuPrimke_btn_Click);
            // 
            // UrediStavkuPrimke_btn
            // 
            this.UrediStavkuPrimke_btn.Location = new System.Drawing.Point(319, 140);
            this.UrediStavkuPrimke_btn.Name = "UrediStavkuPrimke_btn";
            this.UrediStavkuPrimke_btn.Size = new System.Drawing.Size(83, 23);
            this.UrediStavkuPrimke_btn.TabIndex = 11;
            this.UrediStavkuPrimke_btn.Text = "Uredi stavku";
            this.UrediStavkuPrimke_btn.UseVisualStyleBackColor = true;
            this.UrediStavkuPrimke_btn.Click += new System.EventHandler(this.UrediStavkuPrimke_btn_Click);
            // 
            // ObrišiStavkuPrimke_btn
            // 
            this.ObrišiStavkuPrimke_btn.Location = new System.Drawing.Point(408, 140);
            this.ObrišiStavkuPrimke_btn.Name = "ObrišiStavkuPrimke_btn";
            this.ObrišiStavkuPrimke_btn.Size = new System.Drawing.Size(83, 23);
            this.ObrišiStavkuPrimke_btn.TabIndex = 11;
            this.ObrišiStavkuPrimke_btn.Text = "Obriši stavku";
            this.ObrišiStavkuPrimke_btn.UseVisualStyleBackColor = true;
            this.ObrišiStavkuPrimke_btn.Click += new System.EventHandler(this.ObrisiStavkuPrimke_btn_Click);
            // 
            // Evidencija_Primke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 379);
            this.Controls.Add(this.ObrišiStavkuPrimke_btn);
            this.Controls.Add(this.UrediStavkuPrimke_btn);
            this.Controls.Add(this.DodajStavkuPrimke_btn);
            this.Controls.Add(this.StavkePrimke_datagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PodaciOPrimci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Evidencija_Primke";
            this.Text = "Evidencija_Primke";
            ((System.ComponentModel.ISupportInitialize)(this.StavkePrimke_datagrid)).EndInit();
            this.PodaciOPrimci.ResumeLayout(false);
            this.PodaciOPrimci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StavkePrimke_datagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Placeno_checkbox;
        private System.Windows.Forms.Button EvidencijaPrimke_btn;
        private System.Windows.Forms.Button Odustani_btn;
        private System.Windows.Forms.GroupBox PodaciOPrimci;
        private System.Windows.Forms.ComboBox Dobavljaci_combobox;
        private System.Windows.Forms.DateTimePicker DatumZaprimanja_datepicker;
        private System.Windows.Forms.Button DodajStavkuPrimke_btn;
        private System.Windows.Forms.Button UrediStavkuPrimke_btn;
        private System.Windows.Forms.Button ObrišiStavkuPrimke_btn;
    }
}