using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoDesktop
{
    public partial class FrmBenutzer : Form
    {
        public Benutzer Benutzer = new Benutzer();

        public FrmBenutzer()
        {
            InitializeComponent();
        }

        private void FrmBenutzer_Load(object sender, EventArgs e)
        {
            txtName.Text = Benutzer.Name;
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            Benutzer.Name = txtName.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
