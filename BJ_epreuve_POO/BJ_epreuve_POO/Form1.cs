using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJ_epreuve_POO
{
    public partial class Form1 : Form
    {
        MyFolder mf;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {

            mf = new MyFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.FilterFolder("txt", 8000);
        }
    }
}
