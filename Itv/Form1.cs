using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Я просто немного дальтоник, поэтому поставил черный на нем лучше отличия цвета видны
            richTextBox1.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = path_file_to_textbox(openFileDialog1);
            File_Patch fp = new File_Patch();
            textBox1.Text = fp.file_to_textbox(openFileDialog1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File_Patch fp = new File_Patch();
            textBox2.Text = fp.file_to_textbox(openFileDialog1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (textBox1.Text.ToString()!="" && textBox2.Text.ToString() != "")
            {
                string[] linesFirst = File.ReadAllLines(textBox1.Text);
                string[] linesSecond = File.ReadAllLines(textBox2.Text);

                ResultFile rf = new ResultFile(linesFirst, linesSecond);
                //вначале искренне надеялся только union обойтись, но не прокатило...(
                var Except1 = rf.Except1();
                var Except2 = rf.Except2();

                int s1 = 0; int s2 = 0;
                for (int i = 0; i < linesFirst.Count(); i++)
                {
                    if (linesFirst[s1].ToString() == linesSecond[s2].ToString())
                    {
                        AppendTextRichTextBox(richTextBox1, linesFirst[s1].ToString() + "\n", Color.Green);
                        s1++;
                        s2++;
                    }
                    else if (Except1.Contains(linesFirst[s1].ToString()))
                    {
                        AppendTextRichTextBox(richTextBox1, linesFirst[s1].ToString() + "\n", Color.Red);
                        s1++;
                    }
                    else if (Except2.Contains(linesSecond[s2].ToString()))
                    {
                        AppendTextRichTextBox(richTextBox1, linesSecond[s2].ToString() + "\n", Color.YellowGreen);
                        s2++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста выберите файлы №1 и №2");
            }
            
        }

        private void AppendTextRichTextBox(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
