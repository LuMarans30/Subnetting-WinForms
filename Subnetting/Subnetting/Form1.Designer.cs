namespace Subnetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblIP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnInserisci = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCalcola = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtIP = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtMask = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtHost = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.classe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipRete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.broadcast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnhost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 15);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(0, 13);
            this.lblIP.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "/";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(23, 15);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "IP di partenza:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(41, 49);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel2.TabIndex = 17;
            this.kryptonLabel2.Values.Text = "Num. host:";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(250, 46);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(144, 25);
            this.btnInserisci.TabIndex = 4;
            this.btnInserisci.Values.Text = "Inserisci nuova sottorete";
            this.btnInserisci.Click += new System.EventHandler(this.btnInserisci_Click);
            // 
            // btnCalcola
            // 
            this.btnCalcola.Location = new System.Drawing.Point(15, 459);
            this.btnCalcola.Name = "btnCalcola";
            this.btnCalcola.Size = new System.Drawing.Size(1042, 31);
            this.btnCalcola.TabIndex = 5;
            this.btnCalcola.Values.Text = "Calcola";
            this.btnCalcola.Click += new System.EventHandler(this.btnCalcola_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(117, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(183, 23);
            this.txtIP.TabIndex = 1;
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(331, 12);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(31, 23);
            this.txtMask.TabIndex = 2;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(117, 46);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(127, 23);
            this.txtHost.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classe,
            this.ipRete,
            this.mask,
            this.broadcast,
            this.range,
            this.nhost,
            this.rnhost,
            this.spreco});
            this.dataGridView1.Location = new System.Drawing.Point(15, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1042, 353);
            this.dataGridView1.TabIndex = 23;
            // 
            // classe
            // 
            this.classe.HeaderText = "Classe";
            this.classe.Name = "classe";
            this.classe.ReadOnly = true;
            // 
            // ipRete
            // 
            this.ipRete.HeaderText = "Ip di rete";
            this.ipRete.Name = "ipRete";
            this.ipRete.ReadOnly = true;
            // 
            // mask
            // 
            this.mask.HeaderText = "Net mask";
            this.mask.Name = "mask";
            this.mask.ReadOnly = true;
            // 
            // broadcast
            // 
            this.broadcast.HeaderText = "Broadcast";
            this.broadcast.Name = "broadcast";
            this.broadcast.ReadOnly = true;
            // 
            // range
            // 
            this.range.HeaderText = "Range";
            this.range.Name = "range";
            this.range.ReadOnly = true;
            this.range.Width = 300;
            // 
            // nhost
            // 
            this.nhost.HeaderText = "Num. host";
            this.nhost.Name = "nhost";
            this.nhost.ReadOnly = true;
            // 
            // rnhost
            // 
            this.rnhost.HeaderText = "Num. host reale";
            this.rnhost.Name = "rnhost";
            this.rnhost.ReadOnly = true;
            // 
            // spreco
            // 
            this.spreco.HeaderText = "Spreco";
            this.spreco.Name = "spreco";
            this.spreco.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 502);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnCalcola);
            this.Controls.Add(this.btnInserisci);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Subnetting";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnInserisci;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalcola;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtIP;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMask;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtHost;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn classe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipRete;
        private System.Windows.Forms.DataGridViewTextBoxColumn mask;
        private System.Windows.Forms.DataGridViewTextBoxColumn broadcast;
        private System.Windows.Forms.DataGridViewTextBoxColumn range;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhost;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnhost;
        private System.Windows.Forms.DataGridViewTextBoxColumn spreco;
    }
}

