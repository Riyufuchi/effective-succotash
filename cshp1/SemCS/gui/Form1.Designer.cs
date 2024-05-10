namespace SemCS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            addAdressToolStripMenuItem = new ToolStripMenuItem();
            addGarangeToolStripMenuItem = new ToolStripMenuItem();
            addVehicleToolStripMenuItem = new ToolStripMenuItem();
            addDriverToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            ridicToolStripMenuItem = new ToolStripMenuItem();
            taby = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView2 = new DataGridView();
            tabPage3 = new TabPage();
            dataGridView3 = new DataGridView();
            tabPage4 = new TabPage();
            dataGridView4 = new DataGridView();
            adresaToolStripMenuItem = new ToolStripMenuItem();
            garazToolStripMenuItem = new ToolStripMenuItem();
            vozidloToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            taby.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(786, 542);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { databaseToolStripMenuItem, windowToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addAdressToolStripMenuItem, addGarangeToolStripMenuItem, addVehicleToolStripMenuItem, addDriverToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(67, 20);
            databaseToolStripMenuItem.Text = "Database";
            // 
            // addAdressToolStripMenuItem
            // 
            addAdressToolStripMenuItem.Name = "addAdressToolStripMenuItem";
            addAdressToolStripMenuItem.Size = new Size(136, 22);
            addAdressToolStripMenuItem.Text = "Add Adress";
            addAdressToolStripMenuItem.Click += addAdressToolStripMenuItem_Click;
            // 
            // addGarangeToolStripMenuItem
            // 
            addGarangeToolStripMenuItem.Name = "addGarangeToolStripMenuItem";
            addGarangeToolStripMenuItem.Size = new Size(136, 22);
            addGarangeToolStripMenuItem.Text = "Add Garage";
            addGarangeToolStripMenuItem.Click += addGarangeToolStripMenuItem_Click;
            // 
            // addVehicleToolStripMenuItem
            // 
            addVehicleToolStripMenuItem.Name = "addVehicleToolStripMenuItem";
            addVehicleToolStripMenuItem.Size = new Size(136, 22);
            addVehicleToolStripMenuItem.Text = "Add Vehicle";
            addVehicleToolStripMenuItem.Click += addVehicleToolStripMenuItem_Click;
            // 
            // addDriverToolStripMenuItem
            // 
            addDriverToolStripMenuItem.Name = "addDriverToolStripMenuItem";
            addDriverToolStripMenuItem.Size = new Size(136, 22);
            addDriverToolStripMenuItem.Text = "Add Driver";
            addDriverToolStripMenuItem.Click += addDriverToolStripMenuItem_Click;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adresaToolStripMenuItem, garazToolStripMenuItem, vozidloToolStripMenuItem, ridicToolStripMenuItem });
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(54, 20);
            windowToolStripMenuItem.Text = "Search";
            // 
            // ridicToolStripMenuItem
            // 
            ridicToolStripMenuItem.Name = "ridicToolStripMenuItem";
            ridicToolStripMenuItem.Size = new Size(180, 22);
            ridicToolStripMenuItem.Text = "Ridic";
            ridicToolStripMenuItem.Click += ridicToolStripMenuItem_Click;
            // 
            // taby
            // 
            taby.Controls.Add(tabPage1);
            taby.Controls.Add(tabPage2);
            taby.Controls.Add(tabPage3);
            taby.Controls.Add(tabPage4);
            taby.Dock = DockStyle.Fill;
            taby.Location = new Point(0, 24);
            taby.Name = "taby";
            taby.SelectedIndex = 0;
            taby.Size = new Size(800, 576);
            taby.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 548);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Adresa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 548);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Garaz";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(786, 542);
            dataGridView2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 548);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Vozilo";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.Size = new Size(786, 542);
            dataGridView3.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dataGridView4);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(792, 548);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Ridic";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Dock = DockStyle.Fill;
            dataGridView4.Location = new Point(3, 3);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.Size = new Size(786, 542);
            dataGridView4.TabIndex = 0;
            // 
            // adresaToolStripMenuItem
            // 
            adresaToolStripMenuItem.Name = "adresaToolStripMenuItem";
            adresaToolStripMenuItem.Size = new Size(180, 22);
            adresaToolStripMenuItem.Text = "Adresa";
            adresaToolStripMenuItem.Click += adresaToolStripMenuItem_Click;
            // 
            // garazToolStripMenuItem
            // 
            garazToolStripMenuItem.Name = "garazToolStripMenuItem";
            garazToolStripMenuItem.Size = new Size(180, 22);
            garazToolStripMenuItem.Text = "Garaz";
            garazToolStripMenuItem.Click += garazToolStripMenuItem_Click;
            // 
            // vozidloToolStripMenuItem
            // 
            vozidloToolStripMenuItem.Name = "vozidloToolStripMenuItem";
            vozidloToolStripMenuItem.Size = new Size(180, 22);
            vozidloToolStripMenuItem.Text = "Vozidlo";
            vozidloToolStripMenuItem.Click += vozidloToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(taby);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(800, 600);
            Name = "Form1";
            Text = "Vozový park DB";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            taby.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TabControl taby;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private ToolStripMenuItem addAdressToolStripMenuItem;
        private ToolStripMenuItem addGarangeToolStripMenuItem;
        private ToolStripMenuItem ridicToolStripMenuItem;
        private ToolStripMenuItem addVehicleToolStripMenuItem;
        private ToolStripMenuItem addDriverToolStripMenuItem;
        private ToolStripMenuItem adresaToolStripMenuItem;
        private ToolStripMenuItem garazToolStripMenuItem;
        private ToolStripMenuItem vozidloToolStripMenuItem;
    }
}
