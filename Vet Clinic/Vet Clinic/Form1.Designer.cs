namespace Vet_Clinic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            login = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(72, 141);
            label1.Name = "label1";
            label1.Size = new Size(390, 146);
            label1.TabIndex = 0;
            label1.Text = "We care \r\nfor your pets";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.WindowText;
            label2.Location = new Point(72, 308);
            label2.Name = "label2";
            label2.Size = new Size(545, 68);
            label2.TabIndex = 1;
            label2.Text = "We provide a full range of treatment \r\nand diagnostic services for pets";
            // 
            // login
            // 
            login.BackColor = Color.RoyalBlue;
            login.Cursor = Cursors.Hand;
            login.FlatStyle = FlatStyle.Flat;
            login.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login.ForeColor = SystemColors.Window;
            login.ImageAlign = ContentAlignment.MiddleLeft;
            login.Location = new Point(72, 452);
            login.Name = "login";
            login.Size = new Size(150, 50);
            login.TabIndex = 2;
            login.Text = "Log in 🐾";
            login.UseVisualStyleBackColor = false;
            login.Click += login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(678, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(381, 653);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1182, 721);
            Controls.Add(pictureBox1);
            Controls.Add(login);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.WindowFrame;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button login;
        private PictureBox pictureBox1;
    }
}
