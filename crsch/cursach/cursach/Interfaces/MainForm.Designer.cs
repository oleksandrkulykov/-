namespace cursach
{
    partial class MainForm
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
            textBox1 = new TextBox();
            listView1 = new ListView();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            button1 = new Button();
            SuspendLayout();

            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(760, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);

            // 
            // listView1
            // 
            listView1.Location = new System.Drawing.Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(760, 507);
            listView1.TabIndex = 1;
            listView1.View = View.Details;
            listView1.Columns.Add("Type", 150);
            listView1.Columns.Add("Author", 150);
            listView1.Columns.Add("Source", 150);
            listView1.Columns.Add("Topic", 150);
            listView1.Columns.Add("Name", 150);

            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(778, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(200, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);

            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(778, 70);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(200, 23);
            comboBox2.TabIndex = 3;
            comboBox2.SelectedIndexChanged += new System.EventHandler(comboBox2_SelectedIndexChanged);

            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(778, 99);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(200, 23);
            comboBox3.TabIndex = 4;
            comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);

            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(803, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Друк";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);

            // Добавляем кнопку "Додавання" через код
            addButton = new Button();
            addButton.Text = "Додавання";
            addButton.Size = new System.Drawing.Size(100, 23);
            addButton.Location = new System.Drawing.Point(800, 190); // Расположение кнопки на форме
            addButton.Click += AddButton_Click;
            Controls.Add(addButton);

            // Добавляем кнопку "Видалення" через код
            deleteButton = new Button();
            deleteButton.Text = "Видалення";
            deleteButton.Size = new System.Drawing.Size(100, 23);
            deleteButton.Location = new System.Drawing.Point(800, 160); // Расположение кнопки на форме
            deleteButton.Click += DeleteButton_Click;
            Controls.Add(deleteButton);

            // Добавляем кнопку "Редагування" через код
            

            // Добавляем кнопку "Назад" через код
            button2 = new Button();
            button2.Text = "Вихід";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.Location = new System.Drawing.Point(12, 570); // Расположение кнопки на форме
            button2.Click += Button2_Click;
            Controls.Add(button2);


            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 600);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(listView1);
            Controls.Add(textBox1);
            Name = "MainForm";
            Text = "Головна";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}
