using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerites
{
    public class Utca
    {
        //1. Feladat
        public Utca(string fileIn, string fileOut)
        {
            FileIn = fileIn;
            FileOut = fileOut;
            TelekList = ReadFile();
        }

        public string FileIn { get; set; }
        public string FileOut { get; set; }
        public List<Telek> TelekList { get; set; }

        public List<Telek> ReadFile()
        {
            StreamReader textIn = new StreamReader(FileIn);
            List<Telek> telekList = new List<Telek>();

            while (!textIn.EndOfStream)
            {
                string line = textIn.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                string[] telkekSplit = line.Split(' ');

                Telek telek = new Telek();
                telek.Side = int.Parse(telkekSplit[0]);
                telek.Length = int.Parse(telkekSplit[1]);
                telek.Colour = telkekSplit[2];
                telekList.Add(telek);
            }
            textIn.Close();
            return telekList;
        }

        //3. Feladat
        public static string UtolsoHazOldal(Utca utolso)
        {
            if (utolso.TelekList.Last().Side == 0)
                return "páros";
            else
                return "páratlan";
        }

        public static int UtolsoHazHazszam(Utca utolso)
        {
            int hazszam = 0;

            if (utolso.TelekList.Last().Side == 0)
            {
                for (int i = 0; i < utolso.TelekList.Count; i++)
                {
                    if (utolso.TelekList[i].Side == 0)
                    {
                        hazszam += 2;
                    } 
                }
            }
            else
            {
                for (int i = 0; i < utolso.TelekList.Count; i++)
                {
                    if (utolso.TelekList[i].Side == 1)
                    {
                        hazszam += 2;
                    }
                }
                hazszam--;
            }

            return hazszam;
        }

        //4. Feladat
        public static int ElsoUgyanolyanKeritesSzinAParatlanOldalon(Utca utolso)
        {
            int hazszam = 0;

            for (int i = 0; i < utolso.TelekList.Count; i++)
            {
                if (utolso.TelekList[i].Side == 1)
                {
                    hazszam += 2;
                    if (utolso.TelekList[i].Colour != "#" && utolso.TelekList[i].Colour != ":")
                    {
                        for (int y = i + 1; y < utolso.TelekList.Count; y++)
                        {
                            if (utolso.TelekList[i].Side == 1 && utolso.TelekList[i].Colour == utolso.TelekList[y].Colour)
                            {
                                hazszam--;
                                return hazszam;
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
