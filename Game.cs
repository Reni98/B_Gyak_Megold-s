using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino_Practice
{
    internal class Game
    {
        public int sorszam;
        public string username;
        public int tet;
        public int szorzo;
        public string eredmeny;

        public Game( string sorszam, string username,string tet, string szorzo, string eredmeny)
        {
            this.sorszam = int.Parse(sorszam);
            this.username = username;
            this.tet =int.Parse( tet);
            this.szorzo = int.Parse(szorzo);
            this.eredmeny = eredmeny;
        }

        
    }
}
