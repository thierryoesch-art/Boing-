using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Boing_
{
    public partial class SpileBild2 : Form
    {
        // Spielfigur und Boden
        private PictureBox character;
        private PictureBox boden;

        // Bewegungsgeschwindigkeit und Sprungmechanik
        private int speed = 7;
        private int velocityY = 0;
        private bool isJumping = false;
        private int jumpStrength = -17;
        private int trampolinSprungStärke = -30;
        private int gravity = 1;

        // Scrollgrenze für Kamera
        private int scrollThreshold = 300;

        // Listen für Plattformen
        private List<PictureBox> platformen = new List<PictureBox>();
        private List<PictureBox> trampolinPlattformen = new List<PictureBox>();

        // Timer für Spiel-Logik und Bewegung
        private Timer spielTimer;
        private Timer bewegungsTimer;

        private Random rand = new Random();

        // Tastensteuerung
        private bool leftPressed = false;
        private bool rightPressed = false;

        // Plattformverwaltung
        private int letztePlattformY;
        private bool istGestorben = false;

        // Pausenbutton
        private Button btn_pause;

        // Offset für Level-Scroll
        private int offsetX = 500;

        // Für zerfallende Plattformen
        private Dictionary<PictureBox, Timer> zerfallPlattformen = new Dictionary<PictureBox, Timer>();
        private PictureBox aktuelleZerfallplattform = null;

        // Konstruktor
        public SpileBild2()
        {
            InitializeComponent();
            Plattform0();     // Boden-Plattform hinzufügen
            Character();      // Spielfigur initialisieren
            LevelBauen();     // Level mit Plattformen bauen
            Timer();          // Timer starten
        }
        private void SpileBild2_Load(object sender, EventArgs e)
        {
            
        }


        // Event: Pausebutton gedrückt
        private void btn_pause_Click(object sender, EventArgs e)
        {
            spielTimer.Stop();
            bewegungsTimer.Stop();

            // Pause-Menü anzeigen
            PauseMenü pauseMenü = new PauseMenü();
            pauseMenü.Owner = this;
            pauseMenü.FortsetzenGeklickt += (s, ev) =>
            {
                spielTimer.Start();
                bewegungsTimer.Start();
            };
            pauseMenü.ShowDialog();

            // Fokus zurück auf Spielfenster setzen
            this.ActiveControl = null;
            this.Focus();
        }

        // Initialisiert Spielfigur
        private void Character()
        {
            // Bild aus Ressourcen laden
            byte[] imageBytes = Properties.Resources.spieler;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                character = new PictureBox();
                character.Image = Image.FromStream(ms);
                character.Size = new Size(50, 50);
                character.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(character);
            }

            // Startposition über dem Boden
            character.Location = new Point(200 + offsetX, boden.Top - character.Height - 10);
            this.KeyPreview = true;
            this.KeyDown += SpileBild2_KeyDown;
            this.KeyUp += SpileBild2_KeyUp;
        }

        // Erstellt die Bodenplattform
        private void Plattform0()
        {
            boden = new PictureBox();
            boden.Image = Properties.Resources.plattform;
            boden.Size = new Size(this.ClientSize.Width, 40);
            boden.SizeMode = PictureBoxSizeMode.StretchImage;
            boden.Location = new Point(0 + offsetX, this.ClientSize.Height - 40);
            this.Controls.Add(boden);
            platformen.Add(boden);
            letztePlattformY = boden.Top;
        }

        // Timer für Spiellogik und Bewegung
        private void Timer()
        {
            spielTimer = new Timer();
            spielTimer.Interval = 20;
            spielTimer.Tick += spielTimer_Tick;
            spielTimer.Start();

            bewegungsTimer = new Timer();
            bewegungsTimer.Interval = 20;
            bewegungsTimer.Tick += BewegungsTimer_Tick;
            bewegungsTimer.Start();
        }
        // Taste losgelassen
        private void SpileBild2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                leftPressed = false;
            else if (e.KeyCode == Keys.D)
                rightPressed = false;
        }
        // Tastendruck erkennen
        private void SpileBild2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                leftPressed = true;
            else if (e.KeyCode == Keys.D)
                rightPressed = true;
            else if (e.KeyCode == Keys.Space && !isJumping && IstAufPlattform())
            {
                // Unterschiedlicher Sprung je nach Plattformtyp
                if (IstAufTrampolin())
                    velocityY = trampolinSprungStärke;
                else
                    velocityY = jumpStrength;

                isJumping = true;
            }
        }

        // Level mit Plattformen und Trampolinen aufbauen
        private void LevelBauen()
        {
            int levelOffsetX = 400;
            int levelOffsetY = -100;

            // Neue Plattformpositionen mit Zerfall-Flag
            List<(Point Position, bool Zerfall)> plattformPositionen = new List<(Point, bool)>
    {
        (new Point(300, boden.Top - 2), false),
        (new Point(350, boden.Top - 120), true),
        (new Point(220, boden.Top - 250), false),
        (new Point(400, boden.Top - 400), true),
        (new Point(150, boden.Top - 550), false),
        (new Point(300, boden.Top - 700), false),
        (new Point(180, boden.Top - 850), true),
        (new Point(370, boden.Top - 1000), false),
        (new Point(280, boden.Top - 1150), false),
        (new Point(130, boden.Top - 1300), true),
        (new Point(350, boden.Top - 1450), false),
        (new Point(210, boden.Top - 1600), false),
        (new Point(380, boden.Top - 1750), true),
        (new Point(200, boden.Top - 1900), false),
        (new Point(300, boden.Top - 2050), true),
        (new Point(350, boden.Top - 2350), false),
        (new Point(250, boden.Top - 2500), true),
        (new Point(150, boden.Top - 2650), false),
        (new Point(320, boden.Top - 2800), true),
        (new Point(180, boden.Top - 2950), false),
        (new Point(350, boden.Top - 3100), false),
        (new Point(230, boden.Top - 3250), true),
        (new Point(300, boden.Top - 3400), false),
        (new Point(200, boden.Top - 3550), true),
        (new Point(280, boden.Top - 3700), false),
        (new Point(150, boden.Top - 3850), true),
        (new Point(350, boden.Top - 4000), false),
    };

            // Plattformen hinzufügen
            foreach (var (pos, istZerfall) in plattformPositionen)
            {
                PictureBox plattform = new PictureBox();
                plattform.Size = new Size(120, 30);
                plattform.SizeMode = PictureBoxSizeMode.StretchImage;
                plattform.Location = new Point(pos.X + levelOffsetX, pos.Y + levelOffsetY);
                if (istZerfall)
                {
                    plattform.Image = Properties.Resources.Spezielle_Plattform3;
                    plattform.Tag = "Zerfall";
                }
                else
                {
                    plattform.Image = Properties.Resources.plattform;
                }

                this.Controls.Add(plattform);
                platformen.Add(plattform);
            }

            // Trampolin-Plattformen hinzufügen
            List<Point> trampolinPositionen = new List<Point>
    {
        new Point(200, boden.Top - 750),
        new Point(320, boden.Top - 1350),
        new Point(180, boden.Top - 2200),
        new Point(280, boden.Top - 2600),
        new Point(150, boden.Top - 3200),
        new Point(220, boden.Top - 3900),
    };

            foreach (var pos in trampolinPositionen)
            {
                PictureBox trampolin = new PictureBox();
                trampolin.Image = Properties.Resources.trampolin;
                trampolin.Size = new Size(120, 30);
                trampolin.SizeMode = PictureBoxSizeMode.StretchImage;
                trampolin.Location = new Point(pos.X + levelOffsetX, pos.Y + levelOffsetY);
                this.Controls.Add(trampolin);
                trampolinPlattformen.Add(trampolin);
                platformen.Add(trampolin);
            }

            // Endplattform
            PictureBox endPlattform = new PictureBox();
            endPlattform.Image = Properties.Resources.plattform;
            endPlattform.Size = new Size(120, 30);
            endPlattform.SizeMode = PictureBoxSizeMode.StretchImage;
            endPlattform.Location = new Point(250 + levelOffsetX, boden.Top - 4200 + levelOffsetY);
            endPlattform.Tag = "End";
            this.Controls.Add(endPlattform);
            platformen.Add(endPlattform);
        }




        // Seitwärtsbewegung verarbeiten
        private void BewegungsTimer_Tick(object sender, EventArgs e)
        {
            if (leftPressed && character.Left > 0)
                character.Left -= speed;
            if (rightPressed && character.Right < this.ClientSize.Width)
                character.Left += speed;
        }

        // Prüft, ob der Spieler auf einer Plattform steht
        private bool IstAufPlattform()
        {
            foreach (var plattform in platformen)
            {
                Rectangle pr = plattform.Bounds;
                Rectangle cr = character.Bounds;

                if (cr.Bottom >= pr.Top - 5 && cr.Bottom <= pr.Top + 10 &&
                    cr.Right > pr.Left + 5 && cr.Left < pr.Right - 5)
                    return true;
            }
            return false;
        }

        // Prüft, ob der Spieler auf einem Trampolin steht
        private bool IstAufTrampolin()
        {
            foreach (var trampolin in trampolinPlattformen)
            {
                Rectangle tr = trampolin.Bounds;
                Rectangle cr = character.Bounds;

                if (cr.Bottom >= tr.Top - 5 && cr.Bottom <= tr.Top + 10 &&
                    cr.Right > tr.Left + 5 && cr.Left < tr.Right - 5)
                    return true;
            }
            return false;
        }

        // Hauptspielupdate (Schwerkraft, Kollisionen, Scroll, Sieg/Verlust)
        private void SpileBild2_Update(object sender, EventArgs e)
        {
            // Schwerkraft
            character.Top += velocityY;
            velocityY += gravity;

            // Kamera scrollt nach oben
            int diff = scrollThreshold - character.Top;
            if (diff > 0)
            {
                character.Top = scrollThreshold;
                foreach (var plattform in platformen)
                    plattform.Top += diff;
            }
            else if (character.Top > scrollThreshold + 100)
            {
                int scrollDown = character.Top - (scrollThreshold + 100);
                character.Top -= scrollDown;
                foreach (var plattform in platformen)
                    plattform.Top -= scrollDown;
            }

            // Kollision mit Plattformen
            if (velocityY >= 0)
            {
                foreach (var plattform in platformen)
                {
                    Rectangle pr = plattform.Bounds;
                    Rectangle cr = character.Bounds;

                    int vorherBottom = character.Top - velocityY + character.Height;

                    if (vorherBottom <= pr.Top && cr.Bottom >= pr.Top &&
                        cr.Right > pr.Left + 5 && cr.Left < pr.Right - 5)
                    {
                        character.Top = pr.Top - character.Height;
                        velocityY = 0;
                        isJumping = false;
                        break;
                    }
                }
            }

            // Zerfallende Plattformen prüfen
            foreach (var plattform in platformen.ToArray())
            {
                if (plattform.Tag?.ToString() == "Zerfall")
                {
                    Rectangle pr = plattform.Bounds;
                    Rectangle cr = character.Bounds;

                    bool stehtAuf = cr.Bottom >= pr.Top - 5 && cr.Bottom <= pr.Top + 10 &&
                                    cr.Right > pr.Left + 5 && cr.Left < pr.Right - 5;

                    if (stehtAuf)
                    {
                        if (aktuelleZerfallplattform != plattform)
                        {
                            aktuelleZerfallplattform = plattform;

                            if (!zerfallPlattformen.ContainsKey(plattform))
                            {
                                Timer zerfallTimer = new Timer();
                                zerfallTimer.Interval = 1000;
                                zerfallTimer.Tick += (object senderTimer, EventArgs eTimer) =>
                                {
                                    this.Controls.Remove(plattform);
                                    platformen.Remove(plattform);
                                    zerfallPlattformen.Remove(plattform);
                                    zerfallTimer.Stop();
                                    zerfallTimer.Dispose();
                                };

                                zerfallPlattformen[plattform] = zerfallTimer;
                                zerfallTimer.Start();
                            }
                        }
                    }
                    else if (aktuelleZerfallplattform == plattform)
                    {
                        aktuelleZerfallplattform = null;
                    }
                }
            }

            // Wenn Charakter unter den Bildschirm fällt → Tod
            if (!istGestorben && character.Top > boden.Top)
            {
                istGestorben = true;
                velocityY = 0;
                character.Top = boden.Top;
                MessageBox.Show("Du bist gefallen!");
                Application.Restart();
            }

            // Siegbedingung: Endplattform erreicht
            foreach (var plattform in platformen)
            {
                if (plattform.Tag != null && plattform.Tag.ToString() == "End")
                {
                    Rectangle pr = plattform.Bounds;
                    Rectangle cr = character.Bounds;

                    if (cr.Bottom >= pr.Top - 5 && cr.Bottom <= pr.Top + 10 &&
                        cr.Right > pr.Left + 5 && cr.Left < pr.Right - 5)
                    {
                        spielTimer.Stop();
                        bewegungsTimer.Stop();
                        MessageBox.Show("Glückwunsch! Du hast das Level geschafft!");
                        this.Hide();
                        Form1 home = new Form1();
                        home.Show();
                    }
                }
            }
        }

        // Timer-Event ruft Spiellogik auf
        private void spielTimer_Tick(object sender, EventArgs e)
        {
            SpileBild2_Update(sender, e);
        }

        // Verlassen-Button
        private void btn_verlassen_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Nicht verwendete Standardmethoden
        private void SpielBild_Load(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}
