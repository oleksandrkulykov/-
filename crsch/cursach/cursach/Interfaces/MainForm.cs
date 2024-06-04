using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using cursach.Core;

namespace cursach
{
    public partial class MainForm : Form
    {
        private List<Quote> allQuotes;
        private Button addButton;
        private Button deleteButton;
        private Button editButton;
        private Button button2;
        private bool isLoaded = false;

        public MainForm()
        {
            InitializeComponent();
            if (!isLoaded)
            {
                LoadData();
                isLoaded = true;
            }
            PopulateComboBoxes();
            ApplyFilters();
        }

        private void LoadData()
        {
            string filePath = @"C:\Users\Station\Desktop\crsch\basaDanih.json";
            allQuotes = LoadQuotes(filePath);
            ApplyFilters();
        }

        private List<Quote> LoadQuotes(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Database data = JsonConvert.DeserializeObject<Database>(json);
                return data.Quotes;
            }
        }

        private void PopulateComboBoxes()
        {
            var authors = allQuotes.Select(q => q.Author).Distinct().ToList();
            var sources = allQuotes.Select(q => q.Source).Distinct().ToList();
            var topics = allQuotes.Select(q => q.Topic).Distinct().ToList();

            comboBox1.Items.AddRange(authors.ToArray());
            comboBox2.Items.AddRange(sources.ToArray());
            comboBox3.Items.AddRange(topics.ToArray());
        }

        private void SaveDataToJson()
        {
            Database data = new Database { Quotes = allQuotes };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            string filePath = @"C:\Users\Station\Desktop\crsch\basaDanih.json";
            File.WriteAllText(filePath, json);

            MessageBox.Show("Вислови успішно видалені та дані оновлені.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyFilters()
        {
            string searchTerm = textBox1.Text.ToLower();
            string selectedAuthor = comboBox1.SelectedItem?.ToString();
            string selectedSource = comboBox2.SelectedItem?.ToString();
            string selectedTopic = comboBox3.SelectedItem?.ToString();

            var filteredQuotes = allQuotes.Where(q =>
                (string.IsNullOrEmpty(selectedAuthor) || q.Author == selectedAuthor) &&
                (string.IsNullOrEmpty(selectedSource) || q.Source == selectedSource) &&
                (string.IsNullOrEmpty(selectedTopic) || q.Topic == selectedTopic) &&
                (string.IsNullOrEmpty(searchTerm) || q.Name.ToLower().Contains(searchTerm))
            ).ToList();

            if (filteredQuotes.Any())
            {
                PopulateListView(filteredQuotes);
            }
            else
            {
                MessageBox.Show("Немає результатів, які відповідають критеріям пошуку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
            }
        }

        private void PopulateListView(List<Quote> quotes)
        {
            listView1.Items.Clear();
            foreach (var quote in quotes)
            {
                ListViewItem item = new ListViewItem(quote.Type);
                item.SubItems.Add(quote.Author);
                item.SubItems.Add(quote.Source);
                item.SubItems.Add(quote.Topic);
                item.SubItems.Add(quote.Name);
                listView1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrepareQuotesForPrint();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);

            addForm.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            List<Quote> selectedQuotes = GetSelectedQuotes();

            if (selectedQuotes.Count == 0)
            {
                MessageBox.Show("Виберіть цитати для видалення.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Quote quote in selectedQuotes)
            {
                allQuotes.RemoveAll(q => q.Type == quote.Type &&
                                          q.Author == quote.Author &&
                                          q.Source == quote.Source &&
                                          q.Topic == quote.Topic &&
                                          q.Name == quote.Name);
            }

            PopulateListView(allQuotes);
            SaveDataToJson();
        }

        private List<Quote> GetSelectedQuotes()
        {
            List<Quote> selectedQuotes = new List<Quote>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string type = item.SubItems[0].Text;
                string author = item.SubItems[1].Text;
                string source = item.SubItems[2].Text;
                string topic = item.SubItems[3].Text;
                string name = item.SubItems[4].Text;

                Quote selectedQuote = new Quote
                {
                    Type = type,
                    Author = author,
                    Source = source,
                    Topic = topic,
                    Name = name
                };

                selectedQuotes.Add(selectedQuote);
            }

            return selectedQuotes;
        }



        public void AddQuoteToListView(Quote newQuote)
        {
            ListViewItem item = new ListViewItem(newQuote.Type);
            item.SubItems.Add(newQuote.Author);
            item.SubItems.Add(newQuote.Source);
            item.SubItems.Add(newQuote.Topic);
            item.SubItems.Add(newQuote.Name);

            listView1.Items.Add(item);
        }

        public void AddQuoteToJson(Quote newQuote)
        {
            string filePath = @"C:\Users\Station\Desktop\crsch\basaDanih.json";
            string json = File.ReadAllText(filePath);
            Database data = JsonConvert.DeserializeObject<Database>(json);
            data.Quotes.Add(newQuote);

            string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }


        private Quote GetSelectedQuote()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string type = selectedItem.SubItems[0].Text;
                string author = selectedItem.SubItems[1].Text;
                string source = selectedItem.SubItems[2].Text;
                string topic = selectedItem.SubItems[3].Text;
                string name = selectedItem.SubItems[4].Text;

                Quote selectedQuote = new Quote
                {
                    Type = type,
                    Author = author,
                    Source = source,
                    Topic = topic,
                    Name = name
                };

                return selectedQuote;
            }

            return null;
        }

        private void PrepareQuotesForPrint()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("\"Виберіть хоча б один ряд для друку.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> selectedQuotes = new List<string>();

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string quoteText = $"{item.SubItems[0].Text} - {item.SubItems[1].Text}\n{item.SubItems[2].Text}\n{item.SubItems[3].Text}\n{item.SubItems[4].Text}\n";
                selectedQuotes.Add(quoteText);
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SelectedQuotes.txt");

            File.WriteAllLines(filePath, selectedQuotes);

            MessageBox.Show($"Вислови підготовлені для друку та збережені в {filePath}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
