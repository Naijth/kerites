namespace Kerites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Feladat");
            Utca telkek = new Utca("kerites.txt", "utcakep.txt");
            Console.WriteLine("Fájl beolvasva!");
            Console.WriteLine();

            Console.WriteLine("2. Feladat");
            Console.WriteLine("Az eladott telkek száma: " +  telkek.TelekList.Count);
            Console.WriteLine();

            Console.WriteLine("3. Feladat");
            string utolso = Utca.UtolsoHazOldal(telkek);
            Console.WriteLine("A " + utolso + " oldalon adták el az utolsó telket.");
            int utolsoHazszam = Utca.UtolsoHazHazszam(telkek);
            Console.WriteLine("Az utolsó telek házszáma: " + utolsoHazszam);
            Console.WriteLine();

            Console.WriteLine("4. Feladat");
            int paratlanKeritesSzin = Utca.ElsoUgyanolyanKeritesSzinAParatlanOldalon(telkek);
            if (paratlanKeritesSzin == 0)
            {
                Console.WriteLine("A szomszéddal nincs egyező kerítés szín a páratlan oldalon.");
            }
            else
                Console.WriteLine("A szomszédossal egyezik a kerítés színe: " + paratlanKeritesSzin);
            Console.WriteLine();

            Console.WriteLine("5. Feladat");
        }
    }
}
