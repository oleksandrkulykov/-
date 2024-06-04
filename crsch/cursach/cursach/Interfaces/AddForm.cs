using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using cursach.Core;

namespace cursach
{
    public partial class AddForm : Form
    {
        private MainForm parentForm;

        public AddForm(MainForm parent)
        {
            InitializeComponent();
            parentForm = parent;
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        string.IsNullOrWhiteSpace(textBox4.Text) ||
        string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = textBox1.Text;
            string author = textBox2.Text;
            string source = textBox3.Text;
            string topic = textBox4.Text;
            string name = textBox5.Text;

            Quote newQuote = new Quote
            {
                Type = type,
                Author = author,
                Source = source,
                Topic = topic,
                Name = name
            };

            parentForm.AddQuoteToListView(newQuote);

            parentForm.AddQuoteToJson(newQuote);

            MessageBox.Show("Вислів успішно додано.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
