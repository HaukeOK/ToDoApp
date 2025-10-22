namespace ToDoDesktop
{
    partial class FrmAufgabenListe
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
            txtTitel = new TextBox();
            btnSpeichern = new Button();
            SuspendLayout();
            // 
            // lblTitel
            // 
            lblTitel.AutoSize = true;
            lblTitel.Location = new Point(28, 25);
            lblTitel.Name = "lblTitel";
            lblTitel.Size = new Size(38, 20);
            lblTitel.TabIndex = 0;
            lblTitel.Text = "Titel";
            lblTitel.Click += label1_Click;
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(28, 48);
            txtTitel.Name = "txtTitel";
            txtTitel.Size = new Size(238, 27);
            txtTitel.TabIndex = 1;
            txtTitel.TextChanged += txtTitel_TextChanged;
            // 
            // btnSpeichern
            // 
            btnSpeichern.Location = new Point(28, 95);
            btnSpeichern.Name = "btnSpeichern";
            btnSpeichern.Size = new Size(94, 29);
            btnSpeichern.TabIndex = 2;
            btnSpeichern.Text = "Speichern";
            btnSpeichern.UseVisualStyleBackColor = true;
            btnSpeichern.Click += btnSpeichern_Click;
            // 
            // FrmAufgabenListe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 150);
            Controls.Add(btnSpeichern);
            Controls.Add(txtTitel);
            Controls.Add(lblTitel);
            Name = "FrmAufgabenListe";
            Text = "Aufgabenliste";
            Load += FrmAufgabenListe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitel;
        private TextBox txtTitel;
        private Button btnSpeichern;
    }
}