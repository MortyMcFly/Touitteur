using System;
using System.Collections.Generic;
using System.Text;
using Touitteur.Models;

namespace Touitteur.Services
{
    public class TouitteurService : ITouitteurService
    {
        private static TouitteurService instance;

        private TouitteurService()
        {
        }

        public static TouitteurService GetInstance()
        {
            if (instance == null)
                instance = new TouitteurService();
            return instance;
        }

        public bool Authenticate(string user, string password)
        {
            if (user == "morty" && password == "azerty")
                return true;
            return false;
        }

        public List<Touitte> GetTouittes(string search)
        {
            var touittes = new List<Touitte>();
            touittes.Add(new Touitte
            {
                CreationDate = "Aujourd'hui",
                Identifiant = "1",
                Text = "Super la dernière émission de Cyril Hanouna !!!!",
                UserId = "1",
                UserName = "juleno",
                UserPseudo = "@juleno"
            });
            touittes.Add(new Touitte
            {
                CreationDate = "Hier",
                Identifiant = "2",
                Text = "Je suis très heureux d'intégrer cette grande communauté qu'est Touitteur ! #PremierTouitte",
                UserId = "1",
                UserName = "juleno",
                UserPseudo = "@juleno"
            });
            touittes.Add(new Touitte
            {
                CreationDate = "Aujourd'hui",
                Identifiant = "3",
                Text = "Génial cette application elle est assez bien j'aime beaucoup le design c'est très bien codé big up au développeur ;)",
                UserId = "2",
                UserName = "MortyMcFly",
                UserPseudo = "@morty"
            });

            return touittes;
        }
    }
}
