using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techs
{
    //Év,Előreugrás/Technológia/Esemény,Eseményt/Előreugrást/Technológiát létrehozó személy(ek) neve
    internal class Improvements
    {
        public int year { get; }
        public string improvement { get; }

        public new List<string> names { get; }

        public Improvements(string line)
        {
            string[] currentLine = line.Split('%');
            year = int.Parse(currentLine[0]);
            improvement = currentLine[1];
            names = new List<string>();
            string[] currentNames = currentLine[2].Split('/');
            foreach (string s in currentNames)
            {
                names.Add(s);
            }
            
        }
    }
}
