using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDesktop
{
    public class Benutzer
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Eindeutige ID des Benutzers
        public string Name { get; set; } = string.Empty;
    }
}
