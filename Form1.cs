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
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        List<string> players;
        List<string> teal;
        List<string> black;
        string _configpath = AppDomain.CurrentDomain.BaseDirectory + "Players.txt";
        int count = 0;

        public Form1()
        {
            //test
            players = new List<string>();
            string[] lines = File.ReadAllLines(_configpath);

            foreach(string line in lines)
            {
                players.Add(line);
            }

            Random r = new Random();
            string rand = players[r.Next(players.Count)];


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                Random num = new Random();
                string rand = players[r.Next(players.Count)];
                selectPlayer(rand);
                players.Remove(rand);

            }
            catch(Exception ex)
            {
                MessageBox.Show($"No more players. {ex.Message}");
            }
        }

        private void selectPicture(string player)
        {
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + player + ".jpg");
        }

        private async void selectPlayer(string player)
        {
            Random r = new Random();
            Random num = new Random();
            string rand = "";
            for (int i = 0; i < num.Next(10,50);i++)
            {
                rand = players[r.Next(players.Count)];
                selectPicture(rand);
                label1.Text = rand;
                await Task.Delay(50);
            }

            count++;
            if (count % 2 == 0)
            {
                listBox1.Items.Add(rand);
            }
            else
            {
                listBox2.Items.Add(rand);
            }
        }
    }
}
