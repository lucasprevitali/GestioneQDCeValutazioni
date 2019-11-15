namespace ProvaWordWPF
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.nomeL = new System.Windows.Forms.Label();
            this.titoloQdc = new System.Windows.Forms.TextBox();
            this.nomeFormatore = new System.Windows.Forms.TextBox();
            this.valL = new System.Windows.Forms.Label();
            this.eseguiBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nomeL
            // 
            this.nomeL.AutoSize = true;
            this.nomeL.Location = new System.Drawing.Point(76, 59);
            this.nomeL.Name = "nomeL";
            this.nomeL.Size = new System.Drawing.Size(29, 13);
            this.nomeL.TabIndex = 0;
            this.nomeL.Text = "titolo";
            // 
            // titoloQdc
            // 
            this.titoloQdc.Location = new System.Drawing.Point(79, 86);
            this.titoloQdc.Name = "titoloQdc";
            this.titoloQdc.Size = new System.Drawing.Size(100, 20);
            this.titoloQdc.TabIndex = 1;
            // 
            // nomeFormatore
            // 
            this.nomeFormatore.Location = new System.Drawing.Point(242, 85);
            this.nomeFormatore.Name = "nomeFormatore";
            this.nomeFormatore.Size = new System.Drawing.Size(100, 20);
            this.nomeFormatore.TabIndex = 2;
            // 
            // valL
            // 
            this.valL.AutoSize = true;
            this.valL.Location = new System.Drawing.Point(239, 59);
            this.valL.Name = "valL";
            this.valL.Size = new System.Drawing.Size(80, 13);
            this.valL.TabIndex = 3;
            this.valL.Text = "nome formatore";
            // 
            // eseguiBT
            // 
            this.eseguiBT.Location = new System.Drawing.Point(167, 151);
            this.eseguiBT.Name = "eseguiBT";
            this.eseguiBT.Size = new System.Drawing.Size(75, 23);
            this.eseguiBT.TabIndex = 4;
            this.eseguiBT.Text = "esegui";
            this.eseguiBT.UseVisualStyleBackColor = true;
            this.eseguiBT.Click += new System.EventHandler(this.eseguiBT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eseguiBT);
            this.Controls.Add(this.valL);
            this.Controls.Add(this.nomeFormatore);
            this.Controls.Add(this.titoloQdc);
            this.Controls.Add(this.nomeL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nomeL;
        private System.Windows.Forms.TextBox titoloQdc;
        private System.Windows.Forms.TextBox nomeFormatore;
        private System.Windows.Forms.Label valL;
        private System.Windows.Forms.Button eseguiBT;
    }
}

