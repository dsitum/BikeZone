namespace BikeZone
{
    partial class Evidencija_Usluga
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
            this.OpisPopravka_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DioZaPopravak_combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UnosUBazu_btn = new System.Windows.Forms.Button();
            this.Obrisi_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.Usluga_groupbox = new System.Windows.Forms.GroupBox();
            this.Cijena_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Usluga_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpisPopravka_textbox
            // 
            this.OpisPopravka_textbox.Location = new System.Drawing.Point(81, 19);
            this.OpisPopravka_textbox.Multiline = true;
            this.OpisPopravka_textbox.Name = "OpisPopravka_textbox";
            this.OpisPopravka_textbox.Size = new System.Drawing.Size(139, 80);
            this.OpisPopravka_textbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opis popravka:";
            // 
            // DioZaPopravak_combobox
            // 
            this.DioZaPopravak_combobox.FormattingEnabled = true;
            this.DioZaPopravak_combobox.Location = new System.Drawing.Point(81, 105);
            this.DioZaPopravak_combobox.Name = "DioZaPopravak_combobox";
            this.DioZaPopravak_combobox.Size = new System.Drawing.Size(139, 21);
            this.DioZaPopravak_combobox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dio:";
            // 
            // UnosUBazu_btn
            // 
            this.UnosUBazu_btn.Location = new System.Drawing.Point(64, 176);
            this.UnosUBazu_btn.Name = "UnosUBazu_btn";
            this.UnosUBazu_btn.Size = new System.Drawing.Size(75, 23);
            this.UnosUBazu_btn.TabIndex = 7;
            this.UnosUBazu_btn.Text = "PromijeniME";
            this.UnosUBazu_btn.UseVisualStyleBackColor = true;
            this.UnosUBazu_btn.Click += new System.EventHandler(this.UnosUBazu_btn_Click);
            // 
            // Obrisi_btn
            // 
            this.Obrisi_btn.Location = new System.Drawing.Point(145, 176);
            this.Obrisi_btn.Name = "Obrisi_btn";
            this.Obrisi_btn.Size = new System.Drawing.Size(75, 23);
            this.Obrisi_btn.TabIndex = 8;
            this.Obrisi_btn.Text = "Obriši";
            this.Obrisi_btn.UseVisualStyleBackColor = true;
            this.Obrisi_btn.Click += new System.EventHandler(this.Obrisi_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(361, 189);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Popis usluga:";
            // 
            // Usluga_groupbox
            // 
            this.Usluga_groupbox.Controls.Add(this.Cijena_textbox);
            this.Usluga_groupbox.Controls.Add(this.UnosUBazu_btn);
            this.Usluga_groupbox.Controls.Add(this.Obrisi_btn);
            this.Usluga_groupbox.Controls.Add(this.OpisPopravka_textbox);
            this.Usluga_groupbox.Controls.Add(this.label2);
            this.Usluga_groupbox.Controls.Add(this.DioZaPopravak_combobox);
            this.Usluga_groupbox.Controls.Add(this.label1);
            this.Usluga_groupbox.Controls.Add(this.label3);
            this.Usluga_groupbox.Location = new System.Drawing.Point(380, 19);
            this.Usluga_groupbox.Name = "Usluga_groupbox";
            this.Usluga_groupbox.Size = new System.Drawing.Size(240, 205);
            this.Usluga_groupbox.TabIndex = 11;
            this.Usluga_groupbox.TabStop = false;
            this.Usluga_groupbox.Text = "groupBox1";
            // 
            // Cijena_textbox
            // 
            this.Cijena_textbox.Location = new System.Drawing.Point(81, 133);
            this.Cijena_textbox.Name = "Cijena_textbox";
            this.Cijena_textbox.Size = new System.Drawing.Size(100, 20);
            this.Cijena_textbox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cijena:";
            // 
            // Evidencija_Usluga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 236);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Usluga_groupbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Evidencija_Usluga";
            this.Text = "Evidencija Usluga";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Usluga_groupbox.ResumeLayout(false);
            this.Usluga_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OpisPopravka_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DioZaPopravak_combobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UnosUBazu_btn;
        private System.Windows.Forms.Button Obrisi_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Usluga_groupbox;
        private System.Windows.Forms.TextBox Cijena_textbox;
        private System.Windows.Forms.Label label1;
    }
}