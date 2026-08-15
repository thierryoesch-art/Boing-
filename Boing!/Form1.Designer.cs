namespace Boing_
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_verlassen = new System.Windows.Forms.Button();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            this.btn_hife = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start.AutoSize = true;
            this.btn_start.BackColor = System.Drawing.Color.Red;
            this.btn_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_start.Font = new System.Drawing.Font("Impact", 15F);
            this.btn_start.ForeColor = System.Drawing.Color.Snow;
            this.btn_start.Location = new System.Drawing.Point(282, 175);
            this.btn_start.MinimumSize = new System.Drawing.Size(125, 78);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(125, 78);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btnClickThis_Click);
            // 
            // btn_verlassen
            // 
            this.btn_verlassen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_verlassen.AutoSize = true;
            this.btn_verlassen.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_verlassen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_verlassen.Font = new System.Drawing.Font("Ink Free", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verlassen.ForeColor = System.Drawing.Color.Snow;
            this.btn_verlassen.Location = new System.Drawing.Point(282, 292);
            this.btn_verlassen.Name = "btn_verlassen";
            this.btn_verlassen.Size = new System.Drawing.Size(125, 41);
            this.btn_verlassen.TabIndex = 2;
            this.btn_verlassen.Text = "Verlassen";
            this.btn_verlassen.UseVisualStyleBackColor = false;
            this.btn_verlassen.Click += new System.EventHandler(this.btn_verlassen_Click);
            // 
            // btn_hife
            // 
            this.btn_hife.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_hife.AutoSize = true;
            this.btn_hife.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_hife.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F);
            this.btn_hife.Location = new System.Drawing.Point(623, 12);
            this.btn_hife.Name = "btn_hife";
            this.btn_hife.Size = new System.Drawing.Size(66, 25);
            this.btn_hife.TabIndex = 3;
            this.btn_hife.Text = "Help";
            this.btn_hife.UseVisualStyleBackColor = false;
            this.btn_hife.Click += new System.EventHandler(this.btn_hilfe);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(699, 437);
            this.Controls.Add(this.btn_hife);
            this.Controls.Add(this.btn_verlassen);
            this.Controls.Add(this.btn_start);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Ink Free", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(717, 484);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_verlassen;
        private System.Windows.Forms.Timer gametimer;
        private System.Windows.Forms.Button btn_hife;
    }
}

