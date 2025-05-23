namespace Vet_Clinic
{
    partial class MEDICINE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MEDICINE));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            imageList1 = new ImageList(components);
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            dateTimePicker2 = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            pictureBox2 = new PictureBox();
            comboBox1 = new TextBox();
            dateTimePicker1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.GradientInactiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(61, 566);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1243, 261);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.ImageIndex = 0;
            button1.ImageList = imageList1;
            button1.Location = new Point(90, 472);
            button1.Name = "button1";
            button1.Size = new Size(129, 44);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "add.png");
            imageList1.Images.SetKeyName(1, "draw.png");
            imageList1.Images.SetKeyName(2, "trash-bin (1).png");
            imageList1.Images.SetKeyName(3, "9080369_arrow_back_up_icon.png");
            imageList1.Images.SetKeyName(4, "search.png");
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.ImageIndex = 1;
            button2.ImageList = imageList1;
            button2.Location = new Point(291, 474);
            button2.Name = "button2";
            button2.Size = new Size(137, 44);
            button2.TabIndex = 2;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.ImageIndex = 2;
            button3.ImageList = imageList1;
            button3.Location = new Point(496, 474);
            button3.Name = "button3";
            button3.Size = new Size(158, 44);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.ImageIndex = 4;
            button4.ImageList = imageList1;
            button4.Location = new Point(919, 472);
            button4.Name = "button4";
            button4.Size = new Size(148, 44);
            button4.TabIndex = 4;
            button4.Text = "Search";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 2;
            button5.FlatAppearance.MouseOverBackColor = SystemColors.GradientInactiveCaption;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.ImageIndex = 3;
            button5.ImageList = imageList1;
            button5.Location = new Point(719, 469);
            button5.Name = "button5";
            button5.Size = new Size(154, 46);
            button5.TabIndex = 5;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 72);
            label1.Name = "label1";
            label1.Size = new Size(195, 31);
            label1.TabIndex = 6;
            label1.Text = "Medication _ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 150);
            label2.Name = "label2";
            label2.Size = new Size(95, 31);
            label2.TabIndex = 7;
            label2.Text = "Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 230);
            label3.Name = "label3";
            label3.Size = new Size(123, 31);
            label3.TabIndex = 8;
            label3.Text = "Quantity :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 314);
            label4.Name = "label4";
            label4.Size = new Size(206, 31);
            label4.TabIndex = 9;
            label4.Text = "Expiration Date :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 389);
            label5.Name = "label5";
            label5.Size = new Size(87, 31);
            label5.TabIndex = 10;
            label5.Text = "Price :";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Bahnschrift", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(248, 72);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 35);
            textBox1.TabIndex = 11;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(248, 314);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(328, 30);
            dateTimePicker2.TabIndex = 14;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(248, 389);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(328, 30);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.download__5_2;
            pictureBox2.Location = new Point(583, -21);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(784, 488);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(248, 158);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(328, 30);
            comboBox1.TabIndex = 18;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(248, 241);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(328, 30);
            dateTimePicker1.TabIndex = 19;
            dateTimePicker1.TextChanged += dateTimePicker1_ValueChanged;
            // 
            // MEDICINE
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1370, 854);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(dateTimePicker2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "MEDICINE";
            Text = "MEDICINE";
            Load += MEDICINE_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ImageList imageList1;
        private Button button5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker2;
        private NumericUpDown numericUpDown1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox comboBox1;
        private TextBox dateTimePicker1;
    }
}