namespace BikeZone
{
    partial class Primke
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
            this.Primke_datagrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StavkePrimke_datagrid = new System.Windows.Forms.DataGridView();
            this.DodajPrimku_btn = new System.Windows.Forms.Button();
            this.PromijeniPrimku_btn = new System.Windows.Forms.Button();
            this.ObrisiPrimku_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IspisPrimke_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Primke_datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StavkePrimke_datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Primke_datagrid
            // 
            this.Primke_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Primke_datagrid.Location = new System.Drawing.Point(12, 32);
            this.Primke_datagrid.Name = "Primke_datagrid";
            this.Primke_datagrid.Size = new System.Drawing.Size(349, 150);
            this.Primke_datagrid.TabIndex = 0;
            this.Primke_datagrid.SelectionChanged += new System.EventHandler(this.Primke_datagrid_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Popis primki:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stavke odabrane primke:";
            // 
            // StavkePrimke_datagrid
            // 
            this.StavkePrimke_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StavkePrimke_datagrid.Location = new System.Drawing.Point(12, 220);
            this.StavkePrimke_datagrid.Name = "StavkePrimke_datagrid";
            this.StavkePrimke_datagrid.Size = new System.Drawing.Size(480, 200);
            this.StavkePrimke_datagrid.TabIndex = 3;
            // 
            // DodajPrimku_btn
            // 
            this.DodajPrimku_btn.Location = new System.Drawing.Point(6, 17);
            this.DodajPrimku_btn.Name = "DodajPrimku_btn";
            this.DodajPrimku_btn.Size = new System.Drawing.Size(75, 23);
            this.DodajPrimku_btn.TabIndex = 4;
            this.DodajPrimku_btn.Text = "Dodaj";
            this.DodajPrimku_btn.UseVisualStyleBackColor = true;
            this.DodajPrimku_btn.Click += new System.EventHandler(this.DodajPrimku_btn_Click);
            // 
            // PromijeniPrimku_btn
            // 
            this.PromijeniPrimku_btn.Location = new System.Drawing.Point(6, 46);
            this.PromijeniPrimku_btn.Name = "PromijeniPrimku_btn";
            this.PromijeniPrimku_btn.Size = new System.Drawing.Size(75, 23);
            this.PromijeniPrimku_btn.TabIndex = 4;
            this.PromijeniPrimku_btn.Text = "Promijeni";
            this.PromijeniPrimku_btn.UseVisualStyleBackColor = true;
            this.PromijeniPrimku_btn.Click += new System.EventHandler(this.PromijeniPrimku_btn_Click);
            // 
            // ObrisiPrimku_btn
            // 
            this.ObrisiPrimku_btn.Location = new System.Drawing.Point(6, 75);
            this.ObrisiPrimku_btn.Name = "ObrisiPrimku_btn";
            this.ObrisiPrimku_btn.Size = new System.Drawing.Size(75, 23);
            this.ObrisiPrimku_btn.TabIndex = 4;
            this.ObrisiPrimku_btn.Text = "Obriši";
            this.ObrisiPrimku_btn.UseVisualStyleBackColor = true;
            this.ObrisiPrimku_btn.Click += new System.EventHandler(this.ObrisiPrimku_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DodajPrimku_btn);
            this.groupBox1.Controls.Add(this.PromijeniPrimku_btn);
            this.groupBox1.Controls.Add(this.IspisPrimke_btn);
            this.groupBox1.Controls.Add(this.ObrisiPrimku_btn);
            this.groupBox1.Location = new System.Drawing.Point(392, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primka";
            // 
            // IspisPrimke_btn
            // 
            this.IspisPrimke_btn.Location = new System.Drawing.Point(6, 104);
            this.IspisPrimke_btn.Name = "IspisPrimke_btn";
            this.IspisPrimke_btn.Size = new System.Drawing.Size(75, 23);
            this.IspisPrimke_btn.TabIndex = 4;
            this.IspisPrimke_btn.Text = "Ispis";
            this.IspisPrimke_btn.UseVisualStyleBackColor = true;
            this.IspisPrimke_btn.Click += new System.EventHandler(this.IspisPrimke_btn_Click);
            // 
            // Primke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(511, 434);
            this.Controls.Add(this.StavkePrimke_datagrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Primke_datagrid);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Primke";
            this.Text = "Primke";
            ((System.ComponentModel.ISupportInitialize)(this.Primke_datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StavkePrimke_datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Primke_datagrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView StavkePrimke_datagrid;
        private System.Windows.Forms.Button DodajPrimku_btn;
        private System.Windows.Forms.Button PromijeniPrimku_btn;
        private System.Windows.Forms.Button ObrisiPrimku_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button IspisPrimke_btn;
    }
}