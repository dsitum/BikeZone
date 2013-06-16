namespace BikeZone
{
    partial class Glavna_Forma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavna_Forma));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplikacijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupBazePodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreBazePodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dijelovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uslugaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dobavljačaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dobavljačaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kupacaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposlenikaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.izvještajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.računToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primkaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomoćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oTvrtki_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplikacijaToolStripMenuItem,
            this.unosToolStripMenuItem,
            this.izvještajToolStripMenuItem,
            this.pomoćToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aplikacijaToolStripMenuItem
            // 
            this.aplikacijaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupRestoreToolStripMenuItem,
            this.izlazToolStripMenuItem});
            this.aplikacijaToolStripMenuItem.Name = "aplikacijaToolStripMenuItem";
            this.aplikacijaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.aplikacijaToolStripMenuItem.Text = "&Aplikacija";
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupBazePodatakaToolStripMenuItem,
            this.restoreBazePodatakaToolStripMenuItem});
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.backupRestoreToolStripMenuItem.Text = "Backup / Restore";
            // 
            // backupBazePodatakaToolStripMenuItem
            // 
            this.backupBazePodatakaToolStripMenuItem.Name = "backupBazePodatakaToolStripMenuItem";
            this.backupBazePodatakaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.backupBazePodatakaToolStripMenuItem.Text = "Backup baze podataka";
            // 
            // restoreBazePodatakaToolStripMenuItem
            // 
            this.restoreBazePodatakaToolStripMenuItem.Name = "restoreBazePodatakaToolStripMenuItem";
            this.restoreBazePodatakaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.restoreBazePodatakaToolStripMenuItem.Text = "Restore baze podataka";
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.izlazToolStripMenuItem.Text = "&Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // unosToolStripMenuItem
            // 
            this.unosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dijelovaToolStripMenuItem,
            this.dobavljačaToolStripMenuItem,
            this.zaposlenikaToolStripMenuItem1});
            this.unosToolStripMenuItem.Name = "unosToolStripMenuItem";
            this.unosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.unosToolStripMenuItem.Text = "&Evidencija";
            // 
            // dijelovaToolStripMenuItem
            // 
            this.dijelovaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proizvodaToolStripMenuItem,
            this.uslugaToolStripMenuItem1});
            this.dijelovaToolStripMenuItem.Name = "dijelovaToolStripMenuItem";
            this.dijelovaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dijelovaToolStripMenuItem.Text = "Proizvoda / Usluga";
            this.dijelovaToolStripMenuItem.Click += new System.EventHandler(this.Unos_dijelova_Menu_Click);
            // 
            // proizvodaToolStripMenuItem
            // 
            this.proizvodaToolStripMenuItem.Name = "proizvodaToolStripMenuItem";
            this.proizvodaToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.proizvodaToolStripMenuItem.Text = "Proizvoda";
            this.proizvodaToolStripMenuItem.Click += new System.EventHandler(this.EvidencijaProizvoda_Menu_Click);
            // 
            // uslugaToolStripMenuItem1
            // 
            this.uslugaToolStripMenuItem1.Name = "uslugaToolStripMenuItem1";
            this.uslugaToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.uslugaToolStripMenuItem1.Text = "Usluga";
            this.uslugaToolStripMenuItem1.Click += new System.EventHandler(this.EvidencijaUsluga_Menu_Click);
            // 
            // dobavljačaToolStripMenuItem
            // 
            this.dobavljačaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dobavljačaToolStripMenuItem1,
            this.kupacaToolStripMenuItem1});
            this.dobavljačaToolStripMenuItem.Name = "dobavljačaToolStripMenuItem";
            this.dobavljačaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dobavljačaToolStripMenuItem.Text = "Poslovnih partnera";
            // 
            // dobavljačaToolStripMenuItem1
            // 
            this.dobavljačaToolStripMenuItem1.Name = "dobavljačaToolStripMenuItem1";
            this.dobavljačaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.dobavljačaToolStripMenuItem1.Text = "Dobavljača";
            this.dobavljačaToolStripMenuItem1.Click += new System.EventHandler(this.EvidencijaDobavljača_Menu_Click);
            // 
            // kupacaToolStripMenuItem1
            // 
            this.kupacaToolStripMenuItem1.Name = "kupacaToolStripMenuItem1";
            this.kupacaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.kupacaToolStripMenuItem1.Text = "Kupaca";
            this.kupacaToolStripMenuItem1.Click += new System.EventHandler(this.EvidencijaKupaca_Menu_Click);
            // 
            // zaposlenikaToolStripMenuItem1
            // 
            this.zaposlenikaToolStripMenuItem1.Name = "zaposlenikaToolStripMenuItem1";
            this.zaposlenikaToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.zaposlenikaToolStripMenuItem1.Text = "Zaposlenika";
            this.zaposlenikaToolStripMenuItem1.Click += new System.EventHandler(this.EvidencijaZaposlenika_Menu_Click);
            // 
            // izvještajToolStripMenuItem
            // 
            this.izvještajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.računToolStripMenuItem,
            this.primkaToolStripMenuItem});
            this.izvještajToolStripMenuItem.Name = "izvještajToolStripMenuItem";
            this.izvještajToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.izvještajToolStripMenuItem.Text = "&Izvještaj";
            // 
            // računToolStripMenuItem
            // 
            this.računToolStripMenuItem.Name = "računToolStripMenuItem";
            this.računToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.računToolStripMenuItem.Text = "&Račun";
            // 
            // primkaToolStripMenuItem
            // 
            this.primkaToolStripMenuItem.Name = "primkaToolStripMenuItem";
            this.primkaToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.primkaToolStripMenuItem.Text = "Pri&mka";
            // 
            // pomoćToolStripMenuItem
            // 
            this.pomoćToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oTvrtki_MenuItem});
            this.pomoćToolStripMenuItem.Name = "pomoćToolStripMenuItem";
            this.pomoćToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomoćToolStripMenuItem.Text = "&Pomoć";
            // 
            // oTvrtki_MenuItem
            // 
            this.oTvrtki_MenuItem.Name = "oTvrtki_MenuItem";
            this.oTvrtki_MenuItem.Size = new System.Drawing.Size(113, 22);
            this.oTvrtki_MenuItem.Text = "&O tvrtki";
            this.oTvrtki_MenuItem.Click += new System.EventHandler(this.OTvrtki_Menu_Click);
            // 
            // Glavna_Forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 496);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Glavna_Forma";
            this.Text = "Bike Zone";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aplikacijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dijelovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvještajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primkaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomoćToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oTvrtki_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem dobavljačaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposlenikaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem proizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uslugaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dobavljačaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kupacaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupBazePodatakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreBazePodatakaToolStripMenuItem;
    }
}

