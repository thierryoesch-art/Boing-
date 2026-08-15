namespace Boing_
{
    partial class PauseMenü
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnFortsetzen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_beenden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFortsetzen
            // 
            this.btnFortsetzen.BackColor = System.Drawing.Color.LawnGreen;
            this.btnFortsetzen.Location = new System.Drawing.Point(244, 104);
            this.btnFortsetzen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFortsetzen.Name = "btnFortsetzen";
            this.btnFortsetzen.Size = new System.Drawing.Size(116, 19);
            this.btnFortsetzen.TabIndex = 0;
            this.btnFortsetzen.Text = "Fortsetzen";
            this.btnFortsetzen.UseVisualStyleBackColor = false;
            this.btnFortsetzen.Click += new System.EventHandler(this.btnFortsetzen_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LawnGreen;
            this.button1.Location = new System.Drawing.Point(244, 143);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hilfe";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_hilfe);
            // 
            // btn_beenden
            // 
            this.btn_beenden.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_beenden.Location = new System.Drawing.Point(244, 184);
            this.btn_beenden.Margin = new System.Windows.Forms.Padding(2);
            this.btn_beenden.Name = "btn_beenden";
            this.btn_beenden.Size = new System.Drawing.Size(116, 19);
            this.btn_beenden.TabIndex = 2;
            this.btn_beenden.Text = "Beenden";
            this.btn_beenden.UseVisualStyleBackColor = false;
            this.btn_beenden.Click += new System.EventHandler(this.btn_beenden_Click);
            // 
            // PauseMenü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Boing_.Properties.Resources.boing_hintergrund;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_beenden);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFortsetzen);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PauseMenü";
            this.Text = "PausenMenü";
          
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFortsetzen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_beenden;
    }
}
