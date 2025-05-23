using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AdatKiszedVárosok
{
    internal class Program
    {
        static void Main(string[] args)

        {
           List<string> ujAdatok = new List<string>();
            string ujSor;
           using (StreamReader olvas = new StreamReader("magyarorszagvarosai.txt"))
            {
                while (!olvas.EndOfStream)
                {
                    string[] sor = olvas.ReadLine().Split(',');
                    ujSor = $"{sor[0]},{ sor[1]},{sor[4]},{sor[5]},{sor[6]},{sor[7]}";
                    ujAdatok.Add(ujSor.Trim());

                }
            } 
           using ( StreamWriter iro = new StreamWriter("varosok.txt"))
            {
                iro.WriteLine("Sorszám;Városnév;Járás;Kistérség;Népesség;Terület");
                foreach (string sor in ujAdatok)
                {
                    
                    iro.WriteLine(sor);
                }
            }
        }
    }
}
