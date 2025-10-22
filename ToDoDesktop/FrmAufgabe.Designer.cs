namespace ToDoDesktop
{
    partial class FrmAufgabe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitel = new Label();
            lblBeschreibung = new Label();
            txtTitel = new TextBox();
            txtBeschreibung = new TextBox();
            btnSpeichern = new Button();
            // NEU: Deklaration für die neuen Steuerelemente.
            lblBearbeiter = new Label();
            cmbBearbeiter = new ComboBox();
            SuspendLayout();
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Location = new Point(61, 36);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(38, 20);
            lblTitel.TabIndex = 0;
            lblTitel.Text = "Titel";
            // 
            // lblBeschreibung
            // 
            lblBeschreibung.AutoSize = true;
            lblBeschreibung.Location = new Point(61, 113);
            lblBeschreibung.Name = "lblBeschreibung";
            lblBeschreibung.Size = new Size(98, 20);
            lblBeschreibung.TabIndex = 1;
            lblBeschreibung.Text = "Beschreibung";
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(61, 59);
            txtTitel.Name = "txtTitel";
            txtTitel.Size = new Size(247, 27);
            txtTitel.TabIndex = 2;
            // 
            // txtBeschreibung
            // 
            txtBeschreibung.Location = new Point(61, 136);
            txtBeschreibung.Name = "txtBeschreibung";
            txtBeschreibung.Size = new Size(247, 27);
            txtBeschreibung.TabIndex = 3;
            // 
            // btnSpeichern
            // 
            // GEÄNDERT: Y-Position des Buttons angepasst.
            btnSpeichern.Location = new Point(61, 253);
            btnSpeichern.Name = "btnSpeichern";
            btnSpeichern.Size = new Size(94, 29);
            btnSpeichern.TabIndex = 4;
            btnSpeichern.Text = "Speichern";
            btnSpeichern.UseVisualStyleBackColor = true;
            btnSpeichern.Click += btnSpeichern_Click;
            // 
            // NEU: Eigenschaften für das Label "Bearbeiter".
            // 
            lblBearbeiter.AutoSize = true;
            lblBearbeiter.Location = new Point(61, 182);
            lblBearbeiter.Name = "lblBearbeiter";
            lblBearbeiter.Size = new Size(78, 20);
            lblBearbeiter.TabIndex = 5;
            lblBearbeiter.Text = "Bearbeiter";
            // 
            // NEU: Eigenschaften für die ComboBox zur Benutzerauswahl.
            // 
            cmbBearbeiter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBearbeiter.FormattingEnabled = true;
            cmbBearbeiter.Location = new Point(61, 205);
            cmbBearbeiter.Name = "cmbBearbeiter";
            cmbBearbeiter.Size = new Size(247, 28);
            cmbBearbeiter.TabIndex = 6;
            // 
            // FrmAufgabe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            // GEÄNDERT: Die Größe des Formulars wurde erhöht.
            ClientSize = new Size(415, 311);
            // NEU: Hinzufügen der neuen Steuerelemente zum Formular.
            Controls.Add(cmbBearbeiter);
            Controls.Add(lblBearbeiter);
            Controls.Add(btnSpeichern);
            Controls.Add(txtBeschreibung);
            Controls.Add(txtTitel);
            Controls.Add(lblBeschreibung);
            Controls.Add(lblTitel);
            Name = "FrmAufgabe";
            Text = "Aufgabe";
            Load += FrmAufgabe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitel;
        private Label lblBeschreibung;
        private TextBox txtTitel;
        private TextBox txtBeschreibung;
        private Button btnSpeichern;
        // NEU: Private Felder für die neuen Steuerelemente.
        private Label lblBearbeiter;
        private ComboBox cmbBearbeiter;
    }
}