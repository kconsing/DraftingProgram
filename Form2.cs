using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 blindform = new Form1();
                this.Visible = false;
                blindform.ShowDialog();
                this.Close();
            }
            catch
            {
                MessageBox.Show("ERROR.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 draftform = new Form3();
            this.Visible = false;
            draftform.ShowDialog();
            this.Close();
        }
    }
}
