namespace Vet_Clinic
{
    partial class login
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
            pictureBox2 = new PictureBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            button1 = new Button();
            label2 = new Label();
            username = new TextBox();
            password = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.profile__2_1;
            pictureBox2.Location = new Point(189, 24);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(92, 178);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkSlateBlue;
            label1.Location = new Point(168, 171);
            label1.Name = "label1";
            label1.Size = new Size(145, 47);
            label1.TabIndex = 1;
            label1.Text = "LOG IN";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientActiveCaption;
            pictureBox1.Image = Properties.Resources.icons8_user_50;
            pictureBox1.Location = new Point(44, 304);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateBlue;
            panel1.ForeColor = Color.Aqua;
            panel1.Location = new Point(44, 366);
            panel1.Name = "panel1";
            panel1.Size = new Size(394, 1);
            panel1.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.GradientActiveCaption;
            pictureBox3.Image = Properties.Resources.icons8_lock_50;
            pictureBox3.Location = new Point(44, 434);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SlateBlue;
            panel2.Location = new Point(44, 481);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 1);
            panel2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkSlateBlue;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Bahnschrift", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(44, 551);
            button1.Name = "button1";
            button1.Size = new Size(394, 47);
            button1.TabIndex = 6;
            button1.Text = "LOG IN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkSlateBlue;
            label2.Location = new Point(214, 619);
            label2.Name = "label2";
            label2.Size = new Size(57, 24);
            label2.TabIndex = 7;
            label2.Text = "EXIT";
            label2.Click += label2_Click;
            // 
            // username
            // 
            username.BackColor = SystemColors.GradientActiveCaption;
            username.BorderStyle = BorderStyle.None;
            username.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            username.ForeColor = Color.DarkSlateBlue;
            username.Location = new Point(81, 320);
            username.Multiline = true;
            username.Name = "username";
            username.Size = new Size(334, 39);
            username.TabIndex = 8;
            // 
            // password
            // 
            password.BackColor = SystemColors.GradientActiveCaption;
            password.BorderStyle = BorderStyle.None;
            password.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            password.ForeColor = Color.DarkSlateBlue;
            password.Location = new Point(81, 439);
            password.Multiline = true;
            password.Name = "password";
            password.Size = new Size(334, 39);
            password.TabIndex = 8;
            password.UseSystemPasswordChar = true;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(500, 722);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "login";
            Load += login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Button button1;
        private Label label2;
        private TextBox username;
        private TextBox password;
    }
}