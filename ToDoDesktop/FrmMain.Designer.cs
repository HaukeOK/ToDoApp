namespace ToDoDesktop
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEnde = new Button();
            lstAufgabenListen = new ListBox();
            lstAufgaben = new ListBox();
            lblAufgabenListen = new Label();
            lblAufgaben = new Label();
            btnAufgabenListeNeu = new Button();
            btnAufgabenListeLoeschen = new Button();
            btnAufgabeNeu = new Button();
            btnAufgabeLoeschen = new Button();
            lblBenutzer = new Label();
            lstBenutzer = new ListBox();
            btnBenutzerNeu = new Button();
            btnBenutzerLoeschen = new Button();
            SuspendLayout();
            // 
            // btnEnde
            // 
            btnEnde.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnde.Location = new Point(634, 356);
            btnEnde.Name = "btnEnde";
            btnEnde.Size = new Size(138, 36);
            btnEnde.TabIndex = 0;
            btnEnde.Text = "Ende";
            btnEnde.UseVisualStyleBackColor = true;
            btnEnde.Click += btnEnde_Click;
            // 
            // lstAufgabenListen
            // 
            lstAufgabenListen.FormattingEnabled = true;
            lstAufgabenListen.Location = new Point(52, 58);
            lstAufgabenListen.Name = "lstAufgabenListen";
            lstAufgabenListen.Size = new Size(228, 284);
            lstAufgabenListen.TabIndex = 1;
            lstAufgabenListen.SelectedIndexChanged += lstAufgabenListen_SelectedIndexChanged;
            lstAufgabenListen.DoubleClick += lstAufgabenListen_DoubleClick;
            // 
            // lstAufgaben
            // 
            lstAufgaben.FormattingEnabled = true;
            lstAufgaben.Location = new Point(316, 58);
            lstAufgaben.Name = "lstAufgaben";
            lstAufgaben.Size = new Size(209, 284);
            lstAufgaben.TabIndex = 2;
            lstAufgaben.DoubleClick += lstAufgaben_DoubleClick;
            // 
            // lblAufgabenListen
            // 
            lblAufgabenListen.AutoSize = true;
            lblAufgabenListen.Location = new Point(53, 33);
            lblAufgabenListen.Name = "lblAufgabenListen";
            lblAufgabenListen.Size = new Size(109, 20);
            lblAufgabenListen.TabIndex = 3;
            lblAufgabenListen.Text = "Aufgabenlisten";
            // 
            // lblAufgaben
            // 
            lblAufgaben.AutoSize = true;
            lblAufgaben.Location = new Point(316, 33);
            lblAufgaben.Name = "lblAufgaben";
            lblAufgaben.Size = new Size(74, 20);
            lblAufgaben.TabIndex = 4;
            lblAufgaben.Text = "Aufgaben";
            // 
            // btnAufgabenListeNeu
            // 
            btnAufgabenListeNeu.Location = new Point(53, 359);
            btnAufgabenListeNeu.Name = "btnAufgabenListeNeu";
            btnAufgabenListeNeu.Size = new Size(94, 29);
            btnAufgabenListeNeu.TabIndex = 5;
            btnAufgabenListeNeu.Text = "Neu";
            btnAufgabenListeNeu.UseVisualStyleBackColor = true;
            btnAufgabenListeNeu.Click += btnAufgabenListeNeu_Click;
            // 
            // btnAufgabenListeLoeschen
            // 
            btnAufgabenListeLoeschen.Location = new Point(186, 359);
            btnAufgabenListeLoeschen.Name = "btnAufgabenListeLoeschen";
            btnAufgabenListeLoeschen.Size = new Size(94, 29);
            btnAufgabenListeLoeschen.TabIndex = 6;
            btnAufgabenListeLoeschen.Text = "Löschen";
            btnAufgabenListeLoeschen.UseVisualStyleBackColor = true;
            btnAufgabenListeLoeschen.Click += btnAufgabenListeLoeschen_Click;
            // 
            // btnAufgabeNeu
            // 
            btnAufgabeNeu.Location = new Point(316, 359);
            btnAufgabeNeu.Name = "btnAufgabeNeu";
            btnAufgabeNeu.Size = new Size(94, 29);
            btnAufgabeNeu.TabIndex = 7;
            btnAufgabeNeu.Text = "Neu";
            btnAufgabeNeu.UseVisualStyleBackColor = true;
            btnAufgabeNeu.Click += btnAufgabeNeu_Click;
            // 
            // btnAufgabeLoeschen
            // 
            btnAufgabeLoeschen.Location = new Point(431, 359);
            btnAufgabeLoeschen.Name = "btnAufgabeLoeschen";
            btnAufgabeLoeschen.Size = new Size(94, 29);
            btnAufgabeLoeschen.TabIndex = 8;
            btnAufgabeLoeschen.Text = "Löschen";
            btnAufgabeLoeschen.UseVisualStyleBackColor = true;
            btnAufgabeLoeschen.Click += btnAufgabeLoeschen_Click;
            // 
            // lblBenutzer
            // 
            lblBenutzer.AutoSize = true;
            lblBenutzer.Location = new Point(562, 33);
            lblBenutzer.Name = "lblBenutzer";
            lblBenutzer.Size = new Size(67, 20);
            lblBenutzer.TabIndex = 9;
            lblBenutzer.Text = "Benutzer";
            // 
            // lstBenutzer
            // 
            lstBenutzer.FormattingEnabled = true;
            lstBenutzer.Location = new Point(562, 58);
            lstBenutzer.Name = "lstBenutzer";
            lstBenutzer.Size = new Size(209, 204);
            lstBenutzer.TabIndex = 10;
            lstBenutzer.DoubleClick += lstBenutzer_DoubleClick;
            // 
            // btnBenutzerNeu
            // 
            btnBenutzerNeu.Location = new Point(562, 276);
            btnBenutzerNeu.Name = "btnBenutzerNeu";
            btnBenutzerNeu.Size = new Size(94, 29);
            btnBenutzerNeu.TabIndex = 11;
            btnBenutzerNeu.Text = "Neu";
            btnBenutzerNeu.UseVisualStyleBackColor = true;
            btnBenutzerNeu.Click += btnBenutzerNeu_Click;
            // 
            // btnBenutzerLoeschen
            // 
            btnBenutzerLoeschen.Location = new Point(677, 276);
            btnBenutzerLoeschen.Name = "btnBenutzerLoeschen";
            btnBenutzerLoeschen.Size = new Size(94, 29);
            btnBenutzerLoeschen.TabIndex = 12;
            btnBenutzerLoeschen.Text = "Löschen";
            btnBenutzerLoeschen.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 418);
            Controls.Add(btnBenutzerLoeschen);
            Controls.Add(btnBenutzerNeu);
            Controls.Add(lstBenutzer);
            Controls.Add(lblBenutzer);
            Controls.Add(btnAufgabeLoeschen);
            Controls.Add(btnAufgabeNeu);
            Controls.Add(btnAufgabenListeLoeschen);
            Controls.Add(btnAufgabenListeNeu);
            Controls.Add(lblAufgaben);
            Controls.Add(lblAufgabenListen);
            Controls.Add(lstAufgaben);
            Controls.Add(lstAufgabenListen);
            Controls.Add(btnEnde);
            Name = "FrmMain";
            Text = "ToDoDesktop";
            FormClosing += FrmMain_FormClosing;
            FormClosed += FrmMain_FormClosed;
            Load += FrmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEnde;
        private ListBox lstAufgabenListen;
        private ListBox lstAufgaben;
        private Label lblAufgabenListen;
        private Label lblAufgaben;
        private Button btnAufgabenListeNeu;
        private Button btnAufgabenListeLoeschen;
        private Button btnAufgabeNeu;
        private Button btnAufgabeLoeschen;
        private Label lblBenutzer;
        private ListBox lstBenutzer;
        private Button btnBenutzerNeu;
        private Button btnBenutzerLoeschen;
    }
}
