using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boing_
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        private void btnClickThis_Click(object sender, EventArgs e)
        {
            Levelauswahl auswahl = new Levelauswahl();
            auswahl.Show();
            this.Hide();


  
        }

        

        private void btn_verlassen_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_hilfe(object sender, EventArgs e)
        {
            HilfeBild game = new HilfeBild();
            game.Show();
        }

    }
}
