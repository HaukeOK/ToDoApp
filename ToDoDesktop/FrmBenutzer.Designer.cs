namespace ToDoDesktop
{
    partial class FrmBenutzer
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
            lblName = new Label();
            txtName = new TextBox();
            btnSpeichern = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(39, 38);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(39, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(308, 27);
            txtName.TabIndex = 1;
            // 
            // btnSpeichern
            // 
            btnSpeichern.Location = new Point(39, 114);
            btnSpeichern.Name = "btnSpeichern";
            btnSpeichern.Size = new Size(94, 29);
            btnSpeichern.TabIndex = 2;
            btnSpeichern.Text = "Speichern";
            btnSpeichern.UseVisualStyleBackColor = true;
            btnSpeichern.Click += btnSpeichern_Click;
            // 
            // FrmBenutzer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 172);
            Controls.Add(btnSpeichern);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Name = "FrmBenutzer";
            Text = "Benutzer";
            Load += FrmBenutzer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox txtName;
        private Button btnSpeichern;
    }
}