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

namespace working_with_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose the .txt file";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            File f = new File();
            string s = textBox1.Text;
            f.st(s, textBox2);
            f.res(textBox3);
        }
        class File
        {
            int[] a;
            int[] b;
            int length;
            public bool f = false;
            int k1 = 0;
            int k = 0;
            public File()
            {
                a = new int[100];
                b = new int[100];
                length = 100;
            }
            void show(TextBox t, int[] aa)
            {
                t.Text = "";
                for (int i = 0; i < length; i++)
                {
                    t.AppendText(aa[i] + "    ");
                }
            }

            public void st(string s, TextBox t)
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(s, System.Text.Encoding.Default)) // reading lines with array elements in txt file
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        a[i] = Convert.ToInt16(line);
                        i++;
                    }
                }
                length = i;
                show(t, a);
            }


            public void res(TextBox t) 
            {
                int[] b1;
                for (int i = 0; i < length; i++)
                {
                    int k = 0;
                    for (int j = 0; j < length; j++)
                    {
                        if (a[i] == a[j] && i != j)
                        {
                            k1++;
                            break;

                        }

                    }
                    k = length - k1;
                    t.Text = Convert.ToString(k);
                    string s = @"D:\недоУчоба\2 курс\ООП\working_with_files\raz.txt";
                    using (StreamWriter sw = new StreamWriter(s, false, System.Text.Encoding.Default)) // writing result in another txt file
                    {

                        sw.WriteLine("Amount of elements that happens in array 1 time only:   " + k.ToString());

                    }

                }


            }

        }
    }
}
