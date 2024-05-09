namespace SemCS
{
    partial class AdressForm
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
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBoxNumber = new TextBox();
            textBoxStreet = new TextBox();
            textBoxCity = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Město:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 33);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Ulice:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 60);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Číslo popisné:";
            // 
            // button1
            // 
            button1.Location = new Point(98, 86);
            button1.Name = "button1";
            button1.Size = new Size(188, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(98, 57);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(188, 23);
            textBoxNumber.TabIndex = 4;
            // 
            // textBoxStreet
            // 
            textBoxStreet.Location = new Point(98, 30);
            textBoxStreet.Name = "textBoxStreet";
            textBoxStreet.Size = new Size(188, 23);
            textBoxStreet.TabIndex = 5;
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(98, 6);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(188, 23);
            textBoxCity.TabIndex = 6;
            // 
            // AdressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 124);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxStreet);
            Controls.Add(textBoxNumber);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdressForm";
            Text = "AdressForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBoxNumber;
        private TextBox textBoxStreet;
        private TextBox textBoxCity;
    }
}