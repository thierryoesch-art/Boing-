using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boing_
{
    public partial class Levelauswahl : Form
    {
        public Levelauswahl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Level1_Click(object sender, EventArgs e)
        {
            SpielBild level1 = new SpielBild(); // Standardkonstruktor
            level1.Show();
            this.Hide(); // Levelauswahl ausblenden
        }

        private void btn_Level2_Click(object sender, EventArgs e)
        {
            SpileBild2 level2 = new SpileBild2();
            level2.Show();
            this.Hide(); // Levelauswahl-Fenster verstecken
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();       // Aktuelles Level-Fenster ausblenden
            Form1 hauptseite = new Form1();
            hauptseite.Show(); // Hauptseite anzeigen
        }
    }
}
