using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passcheck
{
    class Password
    {
        
        private int lenghtmin; //Szélső érték min
        private int lenghtmax; //Szélső érték max
        private char passletter; //Karakter ami benne kell legyen
        private string word; //Maga a jelszó

        public int Lenghtmin
        {
           get { return lenghtmin; } //olvasás
           set { lenghtmin = value; } //írás
        }
        public int Lenghtmax
        {
           get { return lenghtmax; }
           set { lenghtmax = value; }
        }
        public char Passletter
        {
           get { return passletter; }
           set { passletter = value; }
        }
        public string Word
        {
           get { return word; }
           set { word = value; }
        }


    }
}
