using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skizzen_Editor
{
    class Sketches
    {
        private int Skizze_ID { get; set; }
        private string S_Name { get; set; }
        private int S_Koordinaten { get; set; }
        private string S_Bilder { get; set; }
        private string User_ID { get; set; }

        public Sketches(int id, string name, int koo, string bild, string uid)
        {
            Skizze_ID = id;
            S_Name = name;
            S_Koordinaten = koo;
            S_Bilder = bild;
            User_ID = uid;
        }
    }
   
        
}
