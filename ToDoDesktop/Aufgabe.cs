using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDesktop
{
    public class Aufgabe
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Beschreibung { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime Faelligkeit { get; set; } = DateTime.Now;
        public int? BearbeiterId { get; set; }
    }
}