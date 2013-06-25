namespace BikeZone
{
    partial class Racuni
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
            this.StavkeRacuna_datagrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Racuni_datagrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DodajRacun_btn = new System.Windows.Forms.Button();
            this.PromijeniRacun_btn = new System.Windows.Forms.Button();
            this.IspisRacuna_btn = new System.Windows.Forms.Button();
            this.ObrisiRacun_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StavkeRacuna_datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Racuni_datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StavkeRacuna_datagrid
            // 
            this.StavkeRacuna_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StavkeRacuna_datagrid.Location = new System.Drawing.Point(12, 221);
            this.StavkeRacuna_datagrid.Name = "StavkeRacuna_datagrid";
            this.StavkeRacuna_datagrid.Size = new System.Drawing.Size(572, 200);
            this.StavkeRacuna_datagrid.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stavke odabranog računa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Popis računa:";
            // 
            // Racuni_datagrid
            // 
            this.Racuni_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Racuni_datagrid.Location = new System.Drawing.Point(12, 33);
            this.Racuni_datagrid.Name = "Racuni_datagrid";
            this.Racuni_datagrid.Size = new System.Drawing.Size(480, 150);
            this.Racuni_datagrid.TabIndex = 6;
            this.Racuni_datagrid.SelectionChanged += new System.EventHandler(this.Racuni_datagrid_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DodajRacun_btn);
            this.groupBox1.Controls.Add(this.PromijeniRacun_btn);
            this.groupBox1.Controls.Add(this.IspisRacuna_btn);
            this.groupBox1.Controls.Add(this.ObrisiRacun_btn);
            this.groupBox1.Location = new System.Drawing.Point(503, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 134);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Račun";
            // 
            // DodajRacun_btn
            // 
            this.DodajRacun_btn.Location = new System.Drawing.Point(6, 17);
            this.DodajRacun_btn.Name = "DodajRacun_btn";
            this.DodajRacun_btn.Size = new System.Drawing.Size(75, 23);
            this.DodajRacun_btn.TabIndex = 4;
            this.DodajRacun_btn.Text = "Dodaj";
            this.DodajRacun_btn.UseVisualStyleBackColor = true;
            this.DodajRacun_btn.Click += new System.EventHandler(this.DodajRacun_btn_Click);
            // 
            // PromijeniRacun_btn
            // 
            this.PromijeniRacun_btn.Location = new System.Drawing.Point(6, 46);
            this.PromijeniRacun_btn.Name = "PromijeniRacun_btn";
            this.PromijeniRacun_btn.Size = new System.Drawing.Size(75, 23);
            this.PromijeniRacun_btn.TabIndex = 4;
            this.PromijeniRacun_btn.Text = "Promijeni";
            this.PromijeniRacun_btn.UseVisualStyleBackColor = true;
            this.PromijeniRacun_btn.Click += new System.EventHandler(this.PromijeniRacun_btn_Click);
            // 
            // IspisRacuna_btn
            // 
            this.IspisRacuna_btn.Location = new System.Drawing.Point(6, 104);
            this.IspisRacuna_btn.Name = "IspisRacuna_btn";
            this.IspisRacuna_btn.Size = new System.Drawing.Size(75, 23);
            this.IspisRacuna_btn.TabIndex = 4;
            this.IspisRacuna_btn.Text = "Ispis";
            this.IspisRacuna_btn.UseVisualStyleBackColor = true;
            this.IspisRacuna_btn.Click += new System.EventHandler(this.IspisRacune_btn_Click);
            // 
            // ObrisiRacun_btn
            // 
            this.ObrisiRacun_btn.Location = new System.Drawing.Point(6, 75);
            this.ObrisiRacun_btn.Name = "ObrisiRacun_btn";
            this.ObrisiRacun_btn.Size = new System.Drawing.Size(75, 23);
            this.ObrisiRacun_btn.TabIndex = 4;
            this.ObrisiRacun_btn.Text = "Obriši";
            this.ObrisiRacun_btn.UseVisualStyleBackColor = true;
            this.ObrisiRacun_btn.Click += new System.EventHandler(this.ObrisiRacun_btn_Click);
            // 
            // Racuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 432);
            this.Controls.Add(this.StavkeRacuna_datagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Racuni_datagrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "Racuni";
            this.Text = "Evidencija računa";
            ((System.ComponentModel.ISupportInitialize)(this.StavkeRacuna_datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Racuni_datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StavkeRacuna_datagrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Racuni_datagrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DodajRacun_btn;
        private System.Windows.Forms.Button PromijeniRacun_btn;
        private System.Windows.Forms.Button IspisRacuna_btn;
        private System.Windows.Forms.Button ObrisiRacun_btn;
    }
}