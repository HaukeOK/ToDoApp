using System.Diagnostics.Eventing.Reader;
using System.Xml;
using System.Xml.Serialization;

namespace ToDoDesktop
{
    public partial class FrmMain : Form
    {
        private List<AufgabenListe> _aufgabenListe = new List<AufgabenListe>();
        private List<Benutzer> _benutzer = new List<Benutzer>();

        private XmlSerializer xmlTodo
            = new XmlSerializer(typeof(List<AufgabenListe>));
        // NEU: Ein XmlSerializer für die Benutzerliste.
        private XmlSerializer xmlBenutzer
            = new XmlSerializer(typeof(List<Benutzer>));
        private string xmlFileTodo = "todo.xml";
        // NEU:Das selbe wie im vorhinein. Der Dateiname für die Benutzer-XML.
        private string xmlFileBenutzer = "benutzer.xml";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void XmlLaden()
        {
            // Wenn die XML-Datei noch nicht existiert, dann Abbruch des Einlesens
            if (File.Exists(xmlFileTodo))
            {
                // Filestream mit der XML-Datei öffnen
                using (FileStream fsRead = File.Open(xmlFileTodo, FileMode.Open))
                {
                    // Aufgabenlisten-Struktur aus der XML-Datei durch Desrialisierung auslesen
                    _aufgabenListe =
                        xmlTodo.Deserialize(fsRead) as List<AufgabenListe> ?? new List<AufgabenListe>();
                }
            }

            // NEU: Das selbe wie vorher schon, um die Benutzer zuladen.
            if (File.Exists(xmlFileBenutzer))
            {
                using (FileStream fsRead = File.Open(xmlFileBenutzer, FileMode.Open))
                {
                    _benutzer =
                        xmlBenutzer.Deserialize(fsRead) as List<Benutzer> ?? new List<Benutzer>();
                }
            }
        }

        private void XmlSpeichern()
        {
            // Wenn mindestens ein Element in der Liste der Aufgabenlisten enthalten ist
            if (_aufgabenListe.Count >= 0) // Geändert: Speichert auch, wenn Liste leer ist, um die Datei zu leeren
            {
                // XML-Datei neu erstellen (create)
                using (FileStream fsWrite = File.Create(xmlFileTodo))
                {
                    // Liste der Aufgabenlisten serialisieren
                    xmlTodo.Serialize(fsWrite, _aufgabenListe);
                }
            }

            // NEU: Der Speicher-Block für die Benutzerliste.
            if (_benutzer.Count >= 0)
            {
                using (FileStream fsWrite = File.Create(xmlFileBenutzer))
                {
                    xmlBenutzer.Serialize(fsWrite, _benutzer);
                }
            }
        }


        private void btnEnde_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Wenn Form geladen wird, Listen aus der Datei auslesen
            XmlLaden();
            AufgabenListeAktualisieren();
            // NEU: Die Benutzerliste wird beim Start ebenfalls aktualisiert.
            BenutzerAktualisieren();
        }

        private void btnAufgabenListeNeu_Click(object sender, EventArgs e)
        {
            // Erzeugen eine neue Instanz des Formulars für Aufgabenlistenerstellung
            FrmAufgabenListe frmAufgabenListe = new FrmAufgabenListe();

            // lokale neue Aufgabenliste erstellen
            AufgabenListe aufgabenListe = new AufgabenListe();

            // lokale Aufgabenliste an Formular zur Bearbeitung übergeben
            frmAufgabenListe.AufgabenListe = aufgabenListe;

            // Formular modal anzeigen und Ergebniswert abfragen
            if (frmAufgabenListe.ShowDialog() == DialogResult.OK)
            {
                // Element der Aufgabenliste hinzufügen
                _aufgabenListe.Add(aufgabenListe);
                AufgabenListeAktualisieren();
            }
        }

        private void AufgabenListeAktualisieren()
        {
            // Listbox-Steuerlement leeren
            lstAufgabenListen.Items.Clear();
            // einzelnen Aufgabenlisten hinzfügen
            foreach (AufgabenListe list in _aufgabenListe)
            {
                lstAufgabenListen.Items.Add(list.Titel);
            }
        }

        // Eintrag bearbeiten
        private void lstAufgabenListen_DoubleClick(object sender, EventArgs e)
        {
            // Wenn nichts in der Liste ausgewählt - abbrechen
            if (lstAufgabenListen.SelectedIndex < 0)
                return;

            // Neue Formularinstanz anlegen
            FrmAufgabenListe frmAufgabenListe = new FrmAufgabenListe();

            // Dem Feld auf dem Formular das Element der Aufgabenlistenlist zuweisen,
            // welches mit dem selektierten Index der Listbox übereinstimmt
            frmAufgabenListe.AufgabenListe =
                _aufgabenListe.ElementAt(lstAufgabenListen.SelectedIndex);

            if (frmAufgabenListe.ShowDialog() == DialogResult.OK)
                AufgabenListeAktualisieren();
        }

        private void btnAufgabenListeLoeschen_Click(object sender, EventArgs e)
        {
            // Nichts tun, wenn nichts ausgewählt
            if (lstAufgabenListen.SelectedIndex < 0) return;

            // Aufgabenliste aus der Liste der Listen löschen
            _aufgabenListe.RemoveAt(lstAufgabenListen.SelectedIndex);

            // Listbox-Inhalt aktualisieren
            AufgabenListeAktualisieren();
        }

        private void btnAufgabeNeu_Click(object sender, EventArgs e)
        {
            // Wenn keine Aufgabenliste ausgewählt - abbrechen
            if (lstAufgabenListen.SelectedIndex < 0) return;

            FrmAufgabe frmAufgabe = new FrmAufgabe();
            Aufgabe aufgabe = new Aufgabe();
            frmAufgabe.Aufgabe = aufgabe;
            // NEU: Die komplette Benutzerliste wird an das Aufgaben-Formular übergeben.
            frmAufgabe.BenutzerListe = _benutzer;

            if (frmAufgabe.ShowDialog() == DialogResult.OK)
            {
                _aufgabenListe
                    .ElementAt(lstAufgabenListen.SelectedIndex)
                    .Aufgaben.Add(aufgabe);
                AufgabenAktualisieren();
            }
        }

        private void AufgabenAktualisieren()
        {
            // Listbox der Aufgaben löschen
            lstAufgaben.Items.Clear();

            // für jedes Element der ausgewählten Aufgabenliste die Aufgaben mit dem Titel
            // zur Listbox der Aufgaben hinzufügen
            if (lstAufgabenListen.SelectedIndex >= 0) // GEÄNDERT: Prüft ob eine Aufgabenliste ausgewählt ist.
            {
                foreach (Aufgabe aufgabe in
                    _aufgabenListe
                        .ElementAt(lstAufgabenListen.SelectedIndex).Aufgaben
                )
                {
                    lstAufgaben.Items.Add(aufgabe.Titel);
                }
            }
        }

        // Wrapper-Methoder
        private void lstAufgabenListen_SelectedIndexChanged(object sender, EventArgs e)
        {
            AufgabenAktualisieren();
        }

        private void btnAufgabeLoeschen_Click(object sender, EventArgs e)
        {
            if (lstAufgaben.SelectedIndex < 0) return;

            _aufgabenListe
                .ElementAt(lstAufgabenListen.SelectedIndex)
                .Aufgaben.RemoveAt(lstAufgaben.SelectedIndex);

            AufgabenAktualisieren();
        }

        private void lstAufgaben_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstAufgaben_DoubleClick(object sender, EventArgs e)
        {
            if (lstAufgaben.SelectedIndex < 0) return;

            FrmAufgabe frmAufgabe = new FrmAufgabe();
            frmAufgabe.Aufgabe =
                _aufgabenListe
                .ElementAt(lstAufgabenListen.SelectedIndex)
                .Aufgaben.ElementAt(lstAufgaben.SelectedIndex);
            // NEU: Die komplette Benutzerliste wird an das Aufgaben-Formular übergeben.
            frmAufgabe.BenutzerListe = _benutzer;

            if (frmAufgabe.ShowDialog() == DialogResult.OK)
            {
                AufgabenAktualisieren();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Speichern der Objektstruktur in der XML-Datei
            XmlSpeichern();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(
                "Anwendung wirklich beenden?",
                "Programmende",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
            {
                // Schließen der Form abbrechen
                e.Cancel = true;
            }
        }

        // Neuen Benutzer anlegen
        private void btnBenutzerNeu_Click(object sender, EventArgs e)
        {
            FrmBenutzer frmBenutzer = new FrmBenutzer();
            Benutzer benutzer = new Benutzer();
            frmBenutzer.Benutzer = benutzer;

            if (frmBenutzer.ShowDialog() == DialogResult.OK)
            {
                _benutzer.Add(benutzer);
                BenutzerAktualisieren();
            }
        }

        // Liste der Benutzer aktualisieren
        private void BenutzerAktualisieren()
        {
            lstBenutzer.Items.Clear();
            foreach (Benutzer benutzer in _benutzer)
            {
                lstBenutzer.Items.Add(benutzer.Name);
            }
        }

        // Benutzer bearbeiten
        private void lstBenutzer_DoubleClick(object sender, EventArgs e)
        {
            if (lstBenutzer.SelectedIndex < 0) return;

            FrmBenutzer frmBenutzer = new FrmBenutzer();
            frmBenutzer.Benutzer = _benutzer.ElementAt(lstBenutzer.SelectedIndex);
            if (frmBenutzer.ShowDialog() == DialogResult.OK)
            {
                BenutzerAktualisieren();
            }
        }
    }
}