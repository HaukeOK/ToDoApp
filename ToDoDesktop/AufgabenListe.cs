using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDesktop
{
    public class AufgabenListe
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public List<Aufgabe> Aufgaben { get; set; } = new List<Aufgabe>();
    }
}