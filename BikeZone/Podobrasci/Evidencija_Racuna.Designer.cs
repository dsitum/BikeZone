namespace BikeZone.Podobrasci
{
    partial class Evidencija_Racuna
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
            this.ObrišiStavkuRacuna_btn = new System.Windows.Forms.Button();
            this.UrediStavkuRacuna_btn = new System.Windows.Forms.Button();
            this.DodajStavkuRacuna_btn = new System.Windows.Forms.Button();
            this.StavkeRacuna_datagrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.PodaciORacunu = new System.Windows.Forms.GroupBox();
            this.DatumProdaje_datepicker = new System.Windows.Forms.DateTimePicker();
            this.Kupci_combobox = new System.Windows.Forms.ComboBox();
            this.Prodavaci_combobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Odustani_btn = new System.Windows.Forms.Button();
            this.EvidencijaRacuna_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StavkeRacuna_datagrid)).BeginInit();
            this.PodaciORacunu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObrišiStavkuRacuna_btn
            // 
            this.ObrišiStavkuRacuna_btn.Location = new System.Drawing.Point(405, 151);
            this.ObrišiStavkuRacuna_btn.Name = "ObrišiStavkuRacuna_btn";
            this.ObrišiStavkuRacuna_btn.Size = new System.Drawing.Size(83, 23);
            this.ObrišiStavkuRacuna_btn.TabIndex = 15;
            this.ObrišiStavkuRacuna_btn.Text = "Obriši stavku";
            this.ObrišiStavkuRacuna_btn.UseVisualStyleBackColor = true;
            this.ObrišiStavkuRacuna_btn.Click += new System.EventHandler(this.ObrisiStavkuRacuna_btn_Click);
            // 
            // UrediStavkuRacuna_btn
            // 
            this.UrediStavkuRacuna_btn.Location = new System.Drawing.Point(316, 151);
            this.UrediStavkuRacuna_btn.Name = "UrediStavkuRacuna_btn";
            this.UrediStavkuRacuna_btn.Size = new System.Drawing.Size(83, 23);
            this.UrediStavkuRacuna_btn.TabIndex = 16;
            this.UrediStavkuRacuna_btn.Text = "Uredi stavku";
            this.UrediStavkuRacuna_btn.UseVisualStyleBackColor = true;
            this.UrediStavkuRacuna_btn.Click += new System.EventHandler(this.UrediStavkuRacuna_btn_Click);
            // 
            // DodajStavkuRacuna_btn
            // 
            this.DodajStavkuRacuna_btn.Location = new System.Drawing.Point(227, 151);
            this.DodajStavkuRacuna_btn.Name = "DodajStavkuRacuna_btn";
            this.DodajStavkuRacuna_btn.Size = new System.Drawing.Size(83, 23);
            this.DodajStavkuRacuna_btn.TabIndex = 17;
            this.DodajStavkuRacuna_btn.Text = "Dodaj stavku";
            this.DodajStavkuRacuna_btn.UseVisualStyleBackColor = true;
            this.DodajStavkuRacuna_btn.Click += new System.EventHandler(this.DodajStavkuRacuna_btn_Click);
            // 
            // StavkeRacuna_datagrid
            // 
            this.StavkeRacuna_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StavkeRacuna_datagrid.Location = new System.Drawing.Point(12, 180);
            this.StavkeRacuna_datagrid.Name = "StavkeRacuna_datagrid";
            this.StavkeRacuna_datagrid.Size = new System.Drawing.Size(480, 200);
            this.StavkeRacuna_datagrid.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Stavke računa:";
            // 
            // PodaciORacunu
            // 
            this.PodaciORacunu.Controls.Add(this.DatumProdaje_datepicker);
            this.PodaciORacunu.Controls.Add(this.Kupci_combobox);
            this.PodaciORacunu.Controls.Add(this.Prodavaci_combobox);
            this.PodaciORacunu.Controls.Add(this.label4);
            this.PodaciORacunu.Controls.Add(this.label1);
            this.PodaciORacunu.Controls.Add(this.Odustani_btn);
            this.PodaciORacunu.Controls.Add(this.EvidencijaRacuna_btn);
            this.PodaciORacunu.Controls.Add(this.label3);
            this.PodaciORacunu.Location = new System.Drawing.Point(12, 13);
            this.PodaciORacunu.Name = "PodaciORacunu";
            this.PodaciORacunu.Size = new System.Drawing.Size(486, 116);
            this.PodaciORacunu.TabIndex = 14;
            this.PodaciORacunu.TabStop = false;
            this.PodaciORacunu.Text = "groupBox1";
            // 
            // DatumProdaje_datepicker
            // 
            this.DatumProdaje_datepicker.Location = new System.Drawing.Point(105, 77);
            this.DatumProdaje_datepicker.Name = "DatumProdaje_datepicker";
            this.DatumProdaje_datepicker.Size = new System.Drawing.Size(134, 20);
            this.DatumProdaje_datepicker.TabIndex = 10;
            // 
            // Kupci_combobox
            // 
            this.Kupci_combobox.FormattingEnabled = true;
            this.Kupci_combobox.Location = new System.Drawing.Point(105, 50);
            this.Kupci_combobox.Name = "Kupci_combobox";
            this.Kupci_combobox.Size = new System.Drawing.Size(195, 21);
            this.Kupci_combobox.TabIndex = 9;
            // 
            // Prodavaci_combobox
            // 
            this.Prodavaci_combobox.FormattingEnabled = true;
            this.Prodavaci_combobox.Location = new System.Drawing.Point(105, 20);
            this.Prodavaci_combobox.Name = "Prodavaci_combobox";
            this.Prodavaci_combobox.Size = new System.Drawing.Size(195, 21);
            this.Prodavaci_combobox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kupio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Prodao:";
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
            // EvidencijaRacuna_btn
            // 
            this.EvidencijaRacuna_btn.Location = new System.Drawing.Point(321, 17);
            this.EvidencijaRacuna_btn.Name = "EvidencijaRacuna_btn";
            this.EvidencijaRacuna_btn.Size = new System.Drawing.Size(75, 23);
            this.EvidencijaRacuna_btn.TabIndex = 9;
            this.EvidencijaRacuna_btn.Text = "button1";
            this.EvidencijaRacuna_btn.UseVisualStyleBackColor = true;
            this.EvidencijaRacuna_btn.Click += new System.EventHandler(this.EvidencijaRacuna_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datum prodaje:";
            // 
            // Evidencija_Racuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 391);
            this.Controls.Add(this.ObrišiStavkuRacuna_btn);
            this.Controls.Add(this.UrediStavkuRacuna_btn);
            this.Controls.Add(this.DodajStavkuRacuna_btn);
            this.Controls.Add(this.StavkeRacuna_datagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PodaciORacunu);
            this.Name = "Evidencija_Racuna";
            this.Text = "Evidencija Računa";
            ((System.ComponentModel.ISupportInitialize)(this.StavkeRacuna_datagrid)).EndInit();
            this.PodaciORacunu.ResumeLayout(false);
            this.PodaciORacunu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ObrišiStavkuRacuna_btn;
        private System.Windows.Forms.Button UrediStavkuRacuna_btn;
        private System.Windows.Forms.Button DodajStavkuRacuna_btn;
        private System.Windows.Forms.DataGridView StavkeRacuna_datagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox PodaciORacunu;
        private System.Windows.Forms.DateTimePicker DatumProdaje_datepicker;
        private System.Windows.Forms.ComboBox Prodavaci_combobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Odustani_btn;
        private System.Windows.Forms.Button EvidencijaRacuna_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Kupci_combobox;
    }
}