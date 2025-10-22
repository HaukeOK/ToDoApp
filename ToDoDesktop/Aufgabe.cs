using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDesktop
{
    public class Aufgabe
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Eindeutige ID der Aufgabe
        public string Titel { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
        public DateTime Faelligkeit { get; set; } = DateTime.Now;
        public Benutzer? Bearbeiter { get; set; } = null;
    }
}
