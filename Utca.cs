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
        public Utca(string fileIn)
        {
            FileIn = fileIn;
            TelekList = ReadFile();
        }

        public string FileIn { get; set; }
        public List<Telek> TelekList { get; set; }

        public List<Telek> ReadFile()
        {
            StreamReader textIn = new StreamReader(FileIn);
            List<Telek> telekList = new List<Telek>();
            int hazszamParatlan = -1;
            int hazszamParos = 0;


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
                if (telek.Side == 0)
                {
                    hazszamParos += 2;
                    telek.Hazszam = hazszamParos;
                }
                else
                {
                    hazszamParatlan += 2;
                    telek.Hazszam = hazszamParatlan;
                }

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
            return utolso.TelekList.Last().Hazszam;
        }

        //4. Feladat
        public static int ElsoUgyanolyanKeritesSzinAParatlanOldalon(Utca telkek)
        {
            for (int i = 0; i < telkek.TelekList.Count; i++)
            {
                if (telkek.TelekList[i].Side == 1 && telkek.TelekList[i].Colour != "#" && telkek.TelekList[i].Colour != ":")
                {
                    for (int y = i + 1; y < telkek.TelekList.Count; y++)
                    {
                        if (telkek.TelekList[i].Side == 1 && telkek.TelekList[i].Colour == telkek.TelekList[y].Colour)
                        {
                            return telkek.TelekList[i].Hazszam;
                        }
                        else
                            break;
                    }
                }
            }
            return 0;
        }

        //5. Feladat
        public static string keritesAllapot(Utca telkek, int? input)
        {
            for (int i = 0; i < telkek.TelekList.Count; i++)
            {
                if (telkek.TelekList[i].Hazszam == input)
                {
                    return telkek.TelekList[i].Colour;
                }
            }
            return "Ilyen házszám nincs!";
        }

        public static string ajanlotSzin()
        {
            Random rand = new Random();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int num = rand.Next(1, 27);
            char szinChar = alphabet[num];
            return szinChar.ToString();
        }

        //6. Feladat
        public static void utcakep(Utca telkek)
        {
            StreamWriter textOut = new StreamWriter("utcakep.txt");

            for (int i = 0; i < telkek.TelekList.Count; i++)
            {
                if (telkek.TelekList[i].Side == 1)
                {
                    for (int y  = 0; y < telkek.TelekList[i].Length; y++)
                    {
                        textOut.Write(telkek.TelekList[i].Colour);
                    }
                }
            }
            textOut.WriteLine();

            for (int i = 0; i < telkek.TelekList.Count; i++)
            {
                if (telkek.TelekList[i].Side == 1)
                {
                    textOut.Write(telkek.TelekList[i].Hazszam);
                    int szamHossz = 0;
                    foreach (char ch in telkek.TelekList[i].Hazszam.ToString())
                        szamHossz++;
                    for (int y = szamHossz; y < telkek.TelekList[i].Length; y++)
                    {
                        textOut.Write(' ');
                    }
                }
            }
            textOut.Close();
        }
    }
}
