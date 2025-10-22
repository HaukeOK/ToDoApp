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
    public partial class FrmAufgabe : Form
    {
        public Aufgabe Aufgabe = new Aufgabe();

        public FrmAufgabe()
        {
            InitializeComponent();
        }

        private void FrmAufgabe_Load(object sender, EventArgs e)
        {
            txtTitel.Text = Aufgabe.Titel;
            txtBeschreibung.Text = Aufgabe.Beschreibung;
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            Aufgabe.Titel = txtTitel.Text;
            Aufgabe.Beschreibung = txtBeschreibung.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
