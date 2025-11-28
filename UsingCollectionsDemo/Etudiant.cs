using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageCollections
{
    //(NO), Prénom, Nom, NoteCC et NoteDevoir.
    public class Etudiant
    {
        public string NO { get; set; }
        public string Nom { get; set; }
        public string PreNom { get; set; }
        public double NoteCC { get; set; }
        public double NoteDevoir { get; set; }

        public double Moyenne
        {
            get { return NoteCC * 0.33 + NoteDevoir * 0.67; }
        }
    }
}
