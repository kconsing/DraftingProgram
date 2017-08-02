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

namespace WindowsFormsApplication2
{
    public partial class Form3 : Form
    {
        List<string> players;
        List<string> teal;
        List<string> black;
        string _configpath = AppDomain.CurrentDomain.BaseDirectory + "Players.txt";

        public Form3()
        {
            string player; 

            InitializeComponent();

            radioButton1.Checked = true;

            players = new List<string>();
            string[] lines = File.ReadAllLines(_configpath);

            foreach (string line in lines)
            {
                players.Add(line);
                player = line.ToUpper();
                listBox1.Items.Add(player);
            }

            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectPlayer(listBox1.SelectedItem.ToString());
            }
            catch
            {
                if(listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No more players.");
                }
            }
        }

        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                if (radioButton1.Checked == true)
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
                else
                {
                    listBox3.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
        }

        void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox3.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                listBox1.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            else
            {
                listBox3.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void selectPlayer(string player)
        {
            label2.Text = player.ToUpper();
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + player + ".jpg");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectPlayer(listBox2.SelectedItem.ToString());
            }
            catch
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No more players.");
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectPlayer(listBox3.SelectedItem.ToString());
            }
            catch
            {
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No more players.");
                }
            }
        }
    }
}
