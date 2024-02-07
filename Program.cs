using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Game> game_list = new List<Game>();
          //  List<NyeroSzam> nyeroSzam_list = new List<NyeroSzam>();
          //  List<string> felhnev_list = new List<string>();
            string[] lines = File.ReadAllLines("nyeremenyek.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Game game_object = new Game(values[0], values[1], values[2], values[3], values[4]);
                game_list.Add(game_object);
            }

            /*
            foreach (var item in game_list)
            {
                Console.WriteLine($"{item.sorszam} {item.username} {item.tet} {item.szorzo} {item.eredmeny}");
            }
            */

            //2.Feladat
            Console.WriteLine("Feladat");
            Console.WriteLine("Kérem adjon meg egy számot 1-52 között!");
            string input_number = Console.ReadLine();
            int number = 0;
            if(int.TryParse(input_number, out number))
                foreach (var item in game_list)
                {
                    if (number == item.sorszam)
                    {
                        Console.WriteLine($"{item.sorszam}; {item.username}; {item.tet};{item.szorzo}; {item.eredmeny}");
                    }
                }

            //3.Feladat
            Dictionary<string, int> felhasznalo = new Dictionary<string, int>();
            foreach (var item in game_list)
            {
               if (felhasznalo.ContainsKey(item.username)){
                    felhasznalo[item.username]++;
                }
               else
                {
                    felhasznalo.Add(item.username, 1);
                }
                
            }

            var legtobbetSzereploFelhasznalo = felhasznalo.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine($"Legtöbbet szereplő felhasználó: {legtobbetSzereploFelhasznalo}");
            int osszeg = 0;
            foreach (var item in game_list)
            {
                if(item.username == legtobbetSzereploFelhasznalo)
                {
                    osszeg += item.tet;
                }
            }
            Console.WriteLine($"A legtöbbet szereplő felhasználóhoz tartozó összeg:{osszeg}");
            //4.Feladat
            int db = 0;
            foreach (var item in game_list)
            {
                if(item.eredmeny == "nyertes")
                    db++;
            }
            Console.WriteLine($"A nyertes játszmák összege: {db}");
            //5.Feladat
            int minNyeremeny = int.MaxValue;
            var minNyerAdat = game_list[0];
            foreach (var item in game_list)
            {
                int nyertes_szam = item.tet * item.szorzo;
                if(nyertes_szam < minNyeremeny)
                {
                    minNyeremeny = nyertes_szam;
                    minNyerAdat = item;
                }

            }
            Console.WriteLine($"A legkisebb nyeremény adatai: {minNyeremeny}; {minNyerAdat.username}; {minNyerAdat.sorszam} ");
            //6.Feladat
            int a_szamlalo = 0;
            int kiirando = 0;

            foreach (var item in game_list)
            {
                if (item.username.StartsWith("t"))
                {
                    kiirando++;
                    if (kiirando <= 5)
                    {
                        Console.WriteLine(item.username);
                    }
                    a_szamlalo++;
                }
               
            }
            Console.WriteLine($"a val kezdődő elemek db száma: {a_szamlalo}");
            //.7.feladat
            List<Tuple<int, string, int, int>> nyertesek = new List<Tuple<int, string, int, int>>();
            foreach(var item in game_list)
            {
                if(item.eredmeny == "nyertes")
                {
                    nyertesek.Add(new Tuple<int, string, int, int>(item.sorszam, item.username, item.tet,item.szorzo));
                }
            }
            
            foreach (var nyertes in nyertesek)
            {
                Console.WriteLine($"{nyertes.Item1}; {nyertes.Item2}; {nyertes.Item3 * nyertes.Item4}");
            }
            Console.ReadKey();
        }
    }
}
