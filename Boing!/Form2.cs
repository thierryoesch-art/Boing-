using System;
using System.Windows.Forms;

namespace Boing_
{
    public partial class PauseMenü : Form
    {
        public event EventHandler FortsetzenGeklickt;

        public PauseMenü()
        {
            InitializeComponent();
        }

        private void btnFortsetzen_Click(object sender, EventArgs e)
        {
            FortsetzenGeklickt?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btn_hilfe(object sender, EventArgs e)
        {
            HilfeBild game = new HilfeBild();
            game.Show();
        }

        private void btn_beenden_Click(object sender, EventArgs e)
        {
            // Zeige den Home-Screen
            Form1 home = new Form1();
            home.Show();

            // Schließe das Spiel-Fenster (Hinter dem Pausenmenü)
            if (this.Owner != null)
            {
                this.Owner.Close(); // Das ist SpielBild
            }

            // Schließe das Pausenmenü selbst
            this.Close();
        }
    }
}
