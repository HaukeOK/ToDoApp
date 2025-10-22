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
        // Pseudocode (detaillierter Plan):
        // - Analyse: Der Code-Analyzer meldet WFO1000: Die Eigenschaft "BenutzerListe" konfiguriert die Codeserialisierung
        //   für ihren Eigenschafteninhalt nicht. Der WinForms-Designer erwartet für kollektionsartige Eigenschaften,
        // - Lösung: Die Eigenschaft mit dem Attribut
        //   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //   versehen, damit der Designer den Inhalt der Liste (nicht nur die Referenz) serialisiert.
        // - Implementierung:
        //   1. Attribute hinzufügen (using System.ComponentModel ist bereits vorhanden).
        //   2. Die Autoeigenschaft beibehalten und initialisieren mit new List<Benutzer>().
        //   3. Keine weiteren Änderungen am Verhalten der Eigenschaft erforderlich.
        // - Ergebnis: Analyzer-Warnung WFO1000 wird behoben, der Designer kann die Listenelemente serialisieren.

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Benutzer> BenutzerListe { get; set; } = new List<Benutzer>();

        public FrmAufgabe()
        {
            InitializeComponent();
        }

        private void FrmAufgabe_Load(object sender, EventArgs e)
        {
            txtTitel.Text = Aufgabe.Titel;
            txtBeschreibung.Text = Aufgabe.Beschreibung;

            // NEU: Dieser Block füllt die ComboBox und wählt den gespeicherten Bearbeiter aus.

            // Definiert, welche Eigenschaft des Benutzer-Objekts angezeigt werden soll.
            cmbBearbeiter.DisplayMember = "Name";

            // Erstellt eine temporäre Liste und fügt einen leeren Benutzer am Anfang hinzu.
            // Dies ermöglicht es, "keinen Bearbeiter" auszuwählen.
            var benutzerMitLeeremEintrag = new List<Benutzer> { new Benutzer { Name = "" } };
            benutzerMitLeeremEintrag.AddRange(BenutzerListe);
            cmbBearbeiter.DataSource = benutzerMitLeeremEintrag;

            // Prüft, ob der Aufgabe bereits ein Bearbeiter zugewiesen ist.
            if (Aufgabe.Bearbeiter != null && !string.IsNullOrEmpty(Aufgabe.Bearbeiter.Name))
            {
                // Sucht den zugewiesenen Benutzer in der Liste.
                var bearbeiter = BenutzerListe.FirstOrDefault(b => b.Name == Aufgabe.Bearbeiter.Name);
                if (bearbeiter != null)
                {
                    // Wählt den gefundenen Benutzer in der ComboBox aus.
                    cmbBearbeiter.SelectedItem = bearbeiter;
                }
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            Aufgabe.Titel = txtTitel.Text;
            Aufgabe.Beschreibung = txtBeschreibung.Text;

            // NEU: Speichert den ausgewählten Benutzer aus der ComboBox.
            if (cmbBearbeiter.SelectedItem is Benutzer ausgewaehlterBenutzer && !string.IsNullOrEmpty(ausgewaehlterBenutzer.Name))
            {
                // Wenn ein gültiger Benutzer ausgewählt wurde, wird er der Aufgabe zugewiesen.
                Aufgabe.Bearbeiter = ausgewaehlterBenutzer;
            }
            else
            {
                // Ansonsten wird der Bearbeiter auf null gesetzt (keine Zuweisung).
                Aufgabe.Bearbeiter = null;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}