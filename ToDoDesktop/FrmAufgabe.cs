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
        public List<Benutzer> BenutzerListe = new List<Benutzer>();

        public FrmAufgabe()
        {
            InitializeComponent();
        }

        private void FrmAufgabe_Load(object sender, EventArgs e)
        {
            txtTitel.Text = Aufgabe.Titel;
            txtBeschreibung.Text = Aufgabe.Beschreibung;

            //Die ComboBox wird jetzt so konfiguriert, dass sie die Benutzer-ID als Wert verwendet
            cmbBearbeiter.DataSource = BenutzerListe;
            cmbBearbeiter.DisplayMember = "Name";
            cmbBearbeiter.ValueMember = "Id";

            // Prüft, ob eine BearbeiterId in der Aufgabe gespeichert ist.
            if (Aufgabe.BearbeiterId.HasValue)
            {
                // Wählt den Benutzer basierend auf der gespeicherten ID aus.
                cmbBearbeiter.SelectedValue = Aufgabe.BearbeiterId.Value;
            }
            else
            {
                // Wenn keine ID gespeichert ist, wird kein Benutzer ausgewählt.
                cmbBearbeiter.SelectedItem = null;
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            Aufgabe.Titel = txtTitel.Text;
            Aufgabe.Beschreibung = txtBeschreibung.Text;

            //Speichert die ID des ausgewählten Benutzers.
            if (cmbBearbeiter.SelectedValue != null)
            {
                Aufgabe.BearbeiterId = (int)cmbBearbeiter.SelectedValue;
            }
            else
            {
                // Wenn nichts ausgewählt ist, wird die BearbeiterId auf null gesetzt.
                Aufgabe.BearbeiterId = null;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}