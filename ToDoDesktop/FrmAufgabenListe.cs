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
    public partial class FrmAufgabenListe : Form
    {
        public AufgabenListe AufgabenListe = new AufgabenListe();

        public FrmAufgabenListe()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            AufgabenListe.Titel = txtTitel.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void FrmAufgabenListe_Load(object sender, EventArgs e)
        {
            txtTitel.Text = AufgabenListe.Titel;
        }

        private void txtTitel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
