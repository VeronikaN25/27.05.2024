using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27._05._2024
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadWordsFromFile("words.txt");
        }
        string[] words;
        int index = 0, score = 0;
        Random random = new Random();
        private void LoadWordsFromFile(string fileName)
        {
            try
            {
               
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                if (File.Exists(filePath))
                {
                    words = File.ReadAllLines(filePath);
                }
                else
                {
                    MessageBox.Show($"File not found: {filePath}");
                   
                    words = new string[] { "default", "words", "in", "case", "of", "error" };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading words from file: {ex.Message}");
                words = new string[] { "default", "words", "in", "case", "of", "error" };
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            index = 0;
            score = 0;
            label_result.Text = "Result";
            label_result.BackColor = Color.Peru;
            label_score.Text = "00";
            displayWord();
            button_next.Enabled = true;
            button_start.Enabled = false;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            checkWord();
            if (index < words.Length - 1)
            {
                index++;
                displayWord();
            }
        }
        public void displayWord()
        {
            int pos1 = random.Next(words[index].Length);
            int pos2 = random.Next(words[index].Length);
            int pos3 = random.Next(words[index].Length);

            string word = words[index];

            word = word.Remove(pos1, 1).Insert(pos1, "_");
            word = word.Remove(pos2, 1).Insert(pos2, "_");
            word = word.Remove(pos3, 1).Insert(pos3, "_");

            label_word.Text = word;

        }
        public void checkWord()
        {
            if (textBox_guess.Text.ToLower().Equals(words[index]))
            {
                label_result.Text = "Correct";
                label_result.BackColor = Color.Green;
                score++;
            }
            else
            {
                label_result.Text = "Wrong";
                label_result.BackColor = Color.Red;
            }
            if (index == words.Length - 1)
            {
                button_start.Enabled = true;
                button_next.Enabled = false;
            }
            textBox_guess.Text = "";
            label_score.Text = score.ToString() + " / " + words.Length.ToString();
        }


    }
}

