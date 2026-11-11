using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class videojatekok
    {
        public string Cim { get; set; }
        public string Mufaj { get; set; }
        public DateTime KiadasDatum { get; set; }
        public int AktivJatekosok { get; set; }
        public double Ertekeles { get; set; }

        public videojatekok(string line) {
            string[] data = line.Split(',');
            Cim = data[0];
            Mufaj = data[1];
            KiadasDatum = DateTime.Parse(data[2]);
            AktivJatekosok = int.Parse(data[3]);
            Ertekeles = float.Parse(data[4].Replace('.', ','));
        }
    }
}
