using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Queue<string> underAge = new Queue<string>();
            Queue<string> overAge = new Queue<string>();

            string path = "info_people.txt";

            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                    if (Int32.Parse(line.Split(' ')[4]) < numericUpDown1.Value)
                        underAge.Enqueue(line);
                    else overAge.Enqueue(line);
            }

            int under = underAge.Count;
            int over = overAge.Count;

            listBox1.Items.Add($"Люди младше {numericUpDown1.Value} \n");
            for (int i = 0; i < under; i++)
                listBox1.Items.Add(underAge.Dequeue() + "\n");

            listBox1.Items.Add($"Люди старше {numericUpDown1.Value} \n");
            for (int i = 0; i < over; i++)
                listBox1.Items.Add(overAge.Dequeue() + "\n");
        }   
    }
}
