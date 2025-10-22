using System.Diagnostics.Eventing.Reader;
using System.Xml;
using System.Xml.Serialization;

namespace ToDoDesktop
{
    public partial class FrmMain : Form
    {
        private List<AufgabenListe> _aufgabenListe = new List<AufgabenListe>();
        private List<Benutzer> _benutzer = new List<Benutzer>();

        private XmlSerializer xmlTodo = new XmlSerializer(typeof(List<AufgabenListe>));
        private XmlSerializer xmlBenutzer = new XmlSerializer(typeof(List<Benutzer>));
        private string xmlFileTodo = "todo.xml";
        private string xmlFileBenutzer = "benutzer.xml";

        private static int _naechsteBenutzerId = 1;
        private static int _naechsteAufgabenListenId = 1;
        private static int _naechsteAufgabenId = 1;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void XmlLaden()
        {
            if (File.Exists(xmlFileTodo))
            {
                using (FileStream fsRead = File.Open(xmlFileTodo, FileMode.Open))
                {
                    _aufgabenListe = xmlTodo.Deserialize(fsRead) as List<AufgabenListe> ?? new List<AufgabenListe>();
                }
            }

            if (File.Exists(xmlFileBenutzer))
            {
                using (FileStream fsRead = File.Open(xmlFileBenutzer, FileMode.Open))
                {
                    _benutzer = xmlBenutzer.Deserialize(fsRead) as List<Benutzer> ?? new List<Benutzer>();
                }
            }

            //ID-Zähler initialisieren
            if (_benutzer.Any())
                _naechsteBenutzerId = _benutzer.Max(b => b.Id) + 1;

            if (_aufgabenListe.Any())
            {
                _naechsteAufgabenListenId = _aufgabenListe.Max(al => al.Id) + 1;
                if (_aufgabenListe.SelectMany(al => al.Aufgaben).Any())
                {
                    _naechsteAufgabenId = _aufgabenListe.SelectMany(al => al.Aufgaben).Max(a => a.Id) + 1;
                }
            }
        }

        private void XmlSpeichern()
        {
            if (_aufgabenListe.Count >= 0)
            {
                using (FileStream fsWrite = File.Create(xmlFileTodo))
                {
                    xmlTodo.Serialize(fsWrite, _aufgabenListe);
                }
            }

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
            XmlLaden();
            AufgabenListeAktualisieren();
            BenutzerAktualisieren();
        }

        private void btnAufgabenListeNeu_Click(object sender, EventArgs e)
        {
            FrmAufgabenListe frmAufgabenListe = new FrmAufgabenListe();
            AufgabenListe aufgabenListe = new AufgabenListe();

            //Weist die nächste freie ID zu und erhöht den Zähler
            aufgabenListe.Id = _naechsteAufgabenListenId++;

            frmAufgabenListe.AufgabenListe = aufgabenListe;

            if (frmAufgabenListe.ShowDialog() == DialogResult.OK)
            {
                _aufgabenListe.Add(aufgabenListe);
                AufgabenListeAktualisieren();
            }
        }

        private void AufgabenListeAktualisieren()
        {
            //Die ListBox wird jetzt direkt an die Datenquelle gebunden
            lstAufgabenListen.DataSource = null;
            lstAufgabenListen.DataSource = _aufgabenListe;
            lstAufgabenListen.DisplayMember = "Titel";
            lstAufgabenListen.ValueMember = "Id";
        }

        private void lstAufgabenListen_DoubleClick(object sender, EventArgs e)
        {
            if (lstAufgabenListen.SelectedIndex < 0)
                return;

            FrmAufgabenListe frmAufgabenListe = new FrmAufgabenListe();
            frmAufgabenListe.AufgabenListe = _aufgabenListe.ElementAt(lstAufgabenListen.SelectedIndex);

            if (frmAufgabenListe.ShowDialog() == DialogResult.OK)
                AufgabenListeAktualisieren();
        }

        private void btnAufgabenListeLoeschen_Click(object sender, EventArgs e)
        {
            if (lstAufgabenListen.SelectedIndex < 0) return;

            _aufgabenListe.RemoveAt(lstAufgabenListen.SelectedIndex);
            AufgabenListeAktualisieren();
        }

        private void btnAufgabeNeu_Click(object sender, EventArgs e)
        {
            if (lstAufgabenListen.SelectedIndex < 0) return;

            FrmAufgabe frmAufgabe = new FrmAufgabe();
            Aufgabe aufgabe = new Aufgabe();

            //Weist die nächste freie ID zu und erhöht den Zähler.
            aufgabe.Id = _naechsteAufgabenId++;

            frmAufgabe.Aufgabe = aufgabe;
            frmAufgabe.BenutzerListe = _benutzer;

            if (frmAufgabe.ShowDialog() == DialogResult.OK)
            {
                _aufgabenListe.ElementAt(lstAufgabenListen.SelectedIndex).Aufgaben.Add(aufgabe);
                AufgabenAktualisieren();
            }
        }

        private void AufgabenAktualisieren()
        {
            //Auch diese ListBox wird jetzt an die Datenquelle gebunden.
            lstAufgaben.DataSource = null;
            if (lstAufgabenListen.SelectedIndex >= 0)
            {
                var ausgewaehlteListe = _aufgabenListe.ElementAt(lstAufgabenListen.SelectedIndex);
                lstAufgaben.DataSource = ausgewaehlteListe.Aufgaben;
                lstAufgaben.DisplayMember = "Titel";
                lstAufgaben.ValueMember = "Id";
            }
        }

        private void lstAufgabenListen_SelectedIndexChanged(object sender, EventArgs e)
        {
            AufgabenAktualisieren();
        }

        private void btnAufgabeLoeschen_Click(object sender, EventArgs e)
        {
            if (lstAufgaben.SelectedIndex < 0 || lstAufgabenListen.SelectedIndex < 0) return;

            _aufgabenListe
                .ElementAt(lstAufgabenListen.SelectedIndex)
                .Aufgaben.RemoveAt(lstAufgaben.SelectedIndex);

            AufgabenAktualisieren();
        }

        private void lstAufgaben_DoubleClick(object sender, EventArgs e)
        {
            if (lstAufgaben.SelectedIndex < 0 || lstAufgabenListen.SelectedIndex < 0) return;

            FrmAufgabe frmAufgabe = new FrmAufgabe();
            frmAufgabe.Aufgabe = _aufgabenListe
                .ElementAt(lstAufgabenListen.SelectedIndex)
                .Aufgaben.ElementAt(lstAufgaben.SelectedIndex);
            frmAufgabe.BenutzerListe = _benutzer;

            if (frmAufgabe.ShowDialog() == DialogResult.OK)
            {
                AufgabenAktualisieren();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSpeichern();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Anwendung wirklich beenden?", "Programmende", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnBenutzerNeu_Click(object sender, EventArgs e)
        {
            FrmBenutzer frmBenutzer = new FrmBenutzer();
            Benutzer benutzer = new Benutzer();

            //Weist die nächste freie ID zu und erhöht den Zähler.
            benutzer.Id = _naechsteBenutzerId++;

            frmBenutzer.Benutzer = benutzer;

            if (frmBenutzer.ShowDialog() == DialogResult.OK)
            {
                _benutzer.Add(benutzer);
                BenutzerAktualisieren();
            }
        }

        private void BenutzerAktualisieren()
        {
            //Auch diese ListBox wird jetzt an die Datenquelle gebunden.
            lstBenutzer.DataSource = null;
            lstBenutzer.DataSource = _benutzer;
            lstBenutzer.DisplayMember = "Name";
            lstBenutzer.ValueMember = "Id";
        }

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

        // Leere Event-Handler können bleiben, sie stören nicht.
        private void lstAufgaben_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}