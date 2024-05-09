namespace SemCS.gui
{
    partial class GarageForm
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
            label1 = new Label();
            label3 = new Label();
            numericUpDownKapacita = new NumericUpDown();
            comboBoxAdresa = new ComboBox();
            button1 = new Button();
            numericUpDownVolnaMista = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownKapacita).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVolnaMista).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Kapacita";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 66);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Adresa";
            // 
            // numericUpDownKapacita
            // 
            numericUpDownKapacita.Location = new Point(86, 6);
            numericUpDownKapacita.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownKapacita.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownKapacita.Name = "numericUpDownKapacita";
            numericUpDownKapacita.Size = new Size(213, 23);
            numericUpDownKapacita.TabIndex = 4;
            numericUpDownKapacita.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBoxAdresa
            // 
            comboBoxAdresa.FormattingEnabled = true;
            comboBoxAdresa.Location = new Point(84, 63);
            comboBoxAdresa.Name = "comboBoxAdresa";
            comboBoxAdresa.Size = new Size(215, 23);
            comboBoxAdresa.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(84, 92);
            button1.Name = "button1";
            button1.Size = new Size(215, 23);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDownVolnaMista
            // 
            numericUpDownVolnaMista.Location = new Point(86, 35);
            numericUpDownVolnaMista.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownVolnaMista.Name = "numericUpDownVolnaMista";
            numericUpDownVolnaMista.Size = new Size(213, 23);
            numericUpDownVolnaMista.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Volna mista";
            // 
            // GarageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 135);
            Controls.Add(button1);
            Controls.Add(comboBoxAdresa);
            Controls.Add(numericUpDownVolnaMista);
            Controls.Add(numericUpDownKapacita);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GarageForm";
            Text = "GarangeForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownKapacita).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVolnaMista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private NumericUpDown numericUpDownKapacita;
        private ComboBox comboBoxAdresa;
        private Button button1;
        private NumericUpDown numericUpDownVolnaMista;
        private Label label2;
    }
}