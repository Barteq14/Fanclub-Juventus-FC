using FanclubJuventus.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FanclubJuventus.DAL
{
    public class FanclubInitializer :DropCreateDatabaseIfModelChanges<FanclubContext>
    {
        protected override void Seed(FanclubContext context)
        {
            //trener
            var coaches = new List<Coach>()
            {
               new Coach { FirstName ="Maurizio" , LastName ="Sarri" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener Juventusu Turyn" },
               new Coach { FirstName ="Pep" , LastName ="Guardiola" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener FC Barcelona" },
               new Coach { FirstName ="trainer3" , LastName ="trainer3" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener milanu" },
               new Coach { FirstName ="trainer4" , LastName ="trainer4" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener Fc napoli" },
                new Coach { FirstName ="trainer55" , LastName ="trainer4" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener Real Madrid" },
                 new Coach { FirstName ="trainer6" , LastName ="trainer4" , Age =  60 , EmployedSince = "2019" , EmployedTo = "now" , Description = "Obecny trener ARSENALU" }

            };
            coaches.ForEach(c => context.Coaches.Add(c));
            context.SaveChanges();

            //kluby piłkarskie
            var clubs = new List<Club>()
            {
                new Club {Name = "Juventus FC",Points = 24 ,Country = "Italy", Coach = coaches[0]},
                new Club {Name = "FC Barcelona",Points = 30 , Country = "Spain", Coach = coaches[1]},
                 new Club {Name = "AC MILAN",Points = 30 , Country = "Italy", Coach = coaches[2]},
                  new Club {Name = "NAPOli",Points = 30 , Country = "Italy", Coach = coaches[3]},
                  new Club {Name = "Real Madrid",Points = 30 , Country = "Spain", Coach = coaches[4]},
                  new Club {Name = "Arsenal",Points = 30 , Country = "England", Coach = coaches[5]},
                  

            };
            clubs.ForEach(c => context.Clubs.Add(c));
            context.SaveChanges();

            //zawodnicy
            var players = new List<Player>()
            {
                //JUVENTUS FC
                
                new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 84,Club = clubs[0]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 84,Club = clubs[0]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 72,Club = clubs[0]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defender" , Rating =  86,Club = clubs[0]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defender", Rating = 82,Club = clubs[0]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defender" , Rating = 89,Club = clubs[0]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defender" , Rating = 86,Club = clubs[0]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defender" , Rating = 65,Club = clubs[0]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defender" , Rating = 81,Club = clubs[0]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defender", Rating = 78,Club = clubs[0]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 86,Club = clubs[0]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 80,Club = clubs[0]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 82,Club = clubs[0]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 83,Club = clubs[0]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 76,Club = clubs[0]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 85,Club = clubs[0]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating = 84,Club = clubs[0]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 94,Club = clubs[0]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 76,Club = clubs[0]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[0]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 87,Club = clubs[0]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 85,Club = clubs[0]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 76,Club = clubs[0]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 92,Club = clubs[0]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[0]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[0]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 85,Club = clubs[0]},

                //FC BARCELONA

                   new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 80,Club = clubs[1]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 84,Club = clubs[1]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 86,Club = clubs[1]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defencer" , Rating =  96,Club = clubs[1]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defencer", Rating = 89,Club = clubs[1]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defencer" , Rating = 99,Club = clubs[1]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defencer" , Rating = 76,Club = clubs[1]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defencer" , Rating = 65,Club = clubs[1]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defencer" , Rating = 71,Club = clubs[1]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defencer", Rating = 98,Club = clubs[1]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 86,Club = clubs[1]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 80,Club = clubs[1]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 82,Club = clubs[1]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 83,Club = clubs[1]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 76,Club = clubs[1]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 85,Club = clubs[1]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating = 84,Club = clubs[1]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 94,Club = clubs[1]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 76,Club = clubs[1]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[1]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 50,Club = clubs[1]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 85,Club = clubs[1]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 76,Club = clubs[1]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 92,Club = clubs[1]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[1]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[1]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 85,Club = clubs[1]},

                //AC MILAN
                new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 80,Club = clubs[2]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 84,Club = clubs[2]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 86,Club = clubs[2]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defencer" , Rating =  96,Club = clubs[2]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defencer", Rating = 89,Club = clubs[2]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defencer" , Rating = 69,Club = clubs[2]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defencer" , Rating = 66,Club = clubs[2]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defencer" , Rating = 65,Club = clubs[2]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defencer" , Rating = 71,Club = clubs[2]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defencer", Rating = 68,Club = clubs[2]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 86,Club = clubs[2]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 60,Club = clubs[2]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 82,Club = clubs[2]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 83,Club = clubs[2]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 76,Club = clubs[2]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 65,Club = clubs[2]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating = 84,Club = clubs[2]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 64,Club = clubs[2]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 76,Club = clubs[2]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[2]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 87,Club = clubs[2]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 65,Club = clubs[2]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 66,Club = clubs[2]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 62,Club = clubs[2]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[2]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[2]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 65,Club = clubs[2]},

                //Napoli
                new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 51,Club = clubs[3]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 54,Club = clubs[3]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 56,Club = clubs[3]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defencer" , Rating =  66,Club = clubs[3]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defencer", Rating = 59,Club = clubs[3]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defencer" , Rating = 69,Club = clubs[3]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defencer" , Rating = 56,Club = clubs[3]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defencer" , Rating = 55,Club = clubs[3]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defencer" , Rating = 51,Club = clubs[3]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defencer", Rating = 58,Club = clubs[3]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 56,Club = clubs[3]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 60,Club = clubs[3]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 62,Club = clubs[3]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 63,Club = clubs[3]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 76,Club = clubs[3]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 65,Club = clubs[3]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating = 64,Club = clubs[3]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 94,Club = clubs[3]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 66,Club = clubs[3]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[3]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 57,Club = clubs[3]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 55,Club = clubs[3]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 76,Club = clubs[3]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 52,Club = clubs[3]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[3]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[3]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 85,Club = clubs[3]},

                 //Real Madrid
                new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 91,Club = clubs[4]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 94,Club = clubs[4]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 96,Club = clubs[4]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defencer" , Rating =  96,Club = clubs[4]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defencer", Rating = 99,Club = clubs[4]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defencer" , Rating = 99,Club = clubs[4]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defencer" , Rating = 96,Club = clubs[4]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defencer" , Rating = 75,Club = clubs[4]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defencer" , Rating = 71,Club = clubs[4]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defencer", Rating = 78,Club = clubs[4]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 76,Club = clubs[4]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 70,Club = clubs[4]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 72,Club = clubs[4]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 73,Club = clubs[4]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 86,Club = clubs[4]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 65,Club = clubs[4]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating = 64,Club = clubs[4]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 94,Club = clubs[4]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 66,Club = clubs[4]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[4]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 87,Club = clubs[4]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 75,Club = clubs[4]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 76,Club = clubs[4]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 72,Club = clubs[4]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[4]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[4]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 85,Club = clubs[4]},

                 //Arsenal
                new Player { FirstName = "Wojciech" , LastName = "Szczesny" , Age = 24 , Number = 1 , Country = "Poland" , position = "Goalkeeper", Rating = 70,Club = clubs[5]},
                new Player { FirstName = "Mattia" , LastName = "Perin" , Age = 26 , Number = 22 , Country = "Italy" , position = "Goalkeeper", Rating = 74,Club = clubs[5]},
                new Player { FirstName = "Carlo" , LastName = "Pinsoglio" , Age = 29 , Number = 21 , Country = "Italy" , position = "Goalkeeper", Rating = 76,Club = clubs[5]},
                new Player { FirstName = "Leonardo" , LastName = "Bonucci" , Age = 26 , Number = 19 , Country = "Italy" , position = "Defencer" , Rating =  76,Club = clubs[5]},
                new Player { FirstName = "Daniele" , LastName = "Rugani" , Age = 24 , Number = 24 , Country = "Italy" , position = "Defencer", Rating = 79,Club = clubs[5]},
                new Player { FirstName = "Giorgio" , LastName = "Chiellini" , Age = 34 , Number = 3 , Country = "Italy" , position = "Defencer" , Rating = 79,Club = clubs[5]},
                new Player { FirstName = "Alex" , LastName = "Sandro" , Age = 26 , Number = 12 , Country = "Brasil" , position = "Defencer" , Rating = 76,Club = clubs[5]},
                new Player { FirstName = "Luca" , LastName = "Pellegrini" , Age = 28 , Number = 0 , Country = "Italy" , position = "Defencer" , Rating = 75,Club = clubs[5]},
                new Player { FirstName = "Joao" , LastName = "Cancelo" , Age = 25 , Number = 20 , Country = "Portugal" , position = "Defencer" , Rating = 71,Club = clubs[5]},
                new Player { FirstName = "Mattia" , LastName = "De Sciglio" , Age = 26 , Number = 2 , Country = "Italy" , position = "Defencer", Rating = 78,Club = clubs[5]},
                new Player { FirstName = "Miralem" , LastName = "Pjanic" , Age = 29 , Number = 5 , Country = "Luksemburg" , position = "Helper", Rating = 76,Club = clubs[5]},
                new Player { FirstName = "Emre" , LastName = "Can" , Age = 26 , Number = 23 , Country = "Deuchland" , position = "Helper", Rating = 70,Club = clubs[5]},
                new Player { FirstName = "Aaron" , LastName = "Ramsey" , Age = 28 , Number = 8 , Country = "Walia" , position = "Helper", Rating = 72,Club = clubs[5]},
                new Player { FirstName = "Adrien" , LastName = "Rabiot" , Age = 24 , Number = 0 , Country = "France" , position = "Helper", Rating = 73,Club = clubs[5]},
                new Player { FirstName = "Rodriogo" , LastName = "Bentancur" , Age = 22 , Number = 30 , Country = "Urugway" , position = "Helper", Rating = 76,Club = clubs[5]},
                new Player { FirstName = "Blaise" , LastName = "Matuidi" , Age = 32 , Number = 14 , Country = "France" , position = "Helper", Rating = 75,Club = clubs[5]},
                new Player { FirstName = "Sami" , LastName = "Kheidira" , Age = 32 , Number = 6 , Country = "Deuchland" , position = "Helper", Rating =74,Club = clubs[5]},
                new Player { FirstName = "Cristiano" , LastName = "Ronaldo" , Age = 34 , Number = 7 , Country = "Portugal" , position = "Attacker" , Rating = 74,Club = clubs[5]},
                new Player { FirstName = "Marko" , LastName = "Pjaca" , Age = 24 , Number = 0 , Country = "Croatia" , position = "Attacker" , Rating = 70,Club = clubs[5]},
                new Player { FirstName = "Federico" , LastName = "Bernardeschi" , Age = 25 , Number = 33 , Country = "Italy" , position = "Attacker", Rating = 83,Club = clubs[5]},
                new Player { FirstName = "Douglas" , LastName = "Costa" , Age = 28 , Number = 11 , Country = "Brasil" , position = "Attacker" , Rating = 77,Club = clubs[5]},
                new Player { FirstName = "Juan" , LastName = "Cuadrado" , Age = 31 , Number = 16 , Country = "Columbia" , position = "Attacker" , Rating = 55,Club = clubs[5]},
                new Player { FirstName = "Leonardo" , LastName = "Mancuso" , Age = 27 , Number = 0 , Country = "Italy" , position = "Attacker" , Rating = 76,Club = clubs[5]},
                new Player { FirstName = "Pablo" , LastName = "Dybala" , Age = 25 , Number = 10 , Country = "Argentina" , position = "Attacker", Rating = 72,Club = clubs[5]},
                new Player { FirstName = "Moise" , LastName = "Kean" , Age = 19 , Number = 18 , Country = "Italy" , position = "Attacker" , Rating = 72,Club = clubs[5]},
                new Player { FirstName = "Gonzalo" , LastName = "Higuain" , Age = 31 , Number = 0 , Country = "Argentina" , position = "Attacker" , Rating = 78,Club = clubs[5]},
                new Player { FirstName = "Mario" , LastName = "Mandzukic" , Age = 33 , Number = 17 , Country = "Croatia" , position = "Attacker" , Rating = 85,Club = clubs[5]},
            };
            players.ForEach(p => context.Players.Add(p));
            context.SaveChanges();

            var sizes = new List<Size>()
            {
               new Size { SizeOfProduct = "S" },
               new Size { SizeOfProduct = "M"  },
               new Size { SizeOfProduct = "L"  },
               new Size { SizeOfProduct = "XL"  },
               new Size { SizeOfProduct = "XXL"  }

            };
            sizes.ForEach(c => context.Size.Add(c));
            context.SaveChanges();


            //kategoria
            var categories = new List<Category>()
            {
               new Category { Name = "T-shirts" },
               new Category { Name = "Jeans"  },
               new Category { Name = "Shoes"  }

            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            //produkty
            var products = new List<Product>()
            {
                new Product { Name = "T-shirt" , Price = 100 , Category = categories[0]},
                new Product { Name = "Trousers" , Price = 89 , Category = categories[0] },
                new Product { Name = "Socks" , Price = 30 , Category = categories[0]},
                new Product { Name = "czapka letnia" , Price = 140 , Category = categories[0] },
                new Product { Name = "czapka zimowa" , Price = 140 , Category = categories[0] },
                new Product { Name = "bluzza" , Price = 140 ,Category = categories[0]}
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();


            var productsSize = new List<ProductSize>()
            {
               new ProductSize { product = products[0] , size = sizes[1] },
               new ProductSize { product = products[0] , size = sizes[2] },
               new ProductSize { product = products[0] , size = sizes[3] },
               new ProductSize { product = products[0] , size = sizes[4] },
               new ProductSize { product = products[1] , size = sizes[1] },
               new ProductSize { product = products[1] , size = sizes[2] },
               new ProductSize { product = products[1] , size = sizes[3] },
               new ProductSize { product = products[1] , size = sizes[4] },
               new ProductSize { product = products[2] , size = sizes[1] },
               new ProductSize { product = products[2] , size = sizes[2] },
               new ProductSize { product = products[2] , size = sizes[3] },
               new ProductSize { product = products[2] , size = sizes[4] },
               new ProductSize { product = products[3] , size = sizes[1] },
               new ProductSize { product = products[3] , size = sizes[2] },
               new ProductSize { product = products[3] , size = sizes[3] },
               new ProductSize { product = products[3] , size = sizes[4] },
               new ProductSize { product = products[4] , size = sizes[1] },
               new ProductSize { product = products[4] , size = sizes[2] },
               new ProductSize { product = products[4] , size = sizes[3] },
               new ProductSize { product = products[4] , size = sizes[4] },
               new ProductSize { product = products[5] , size = sizes[1] },
               new ProductSize { product = products[5] , size = sizes[2] },
               new ProductSize { product = products[5] , size = sizes[3] },
               new ProductSize { product = products[5] , size = sizes[4] }

            };
            productsSize.ForEach(c => context.ProductSize.Add(c));
            context.SaveChanges();

          

            //mecze
            var matches = new List<Match>()
            {
                new Match {  club = clubs[1], club2 = clubs[0] , Result1 = 4 , Result2 =  3, MatchDate = DateTime.Now ,Status = "Finished"}
            };
            matches.ForEach(m => context.Matches.Add(m));
            context.SaveChanges();

            //proffile
            var profiles = new List<Profile>()
            {
                new Profile { UserName = "b.longota2@wp.pl" , PhoneNumber = "662115529" },
                 new Profile { UserName = "test@wp.pl" , PhoneNumber = "111222333" }
            };
            profiles.ForEach(p => context.Profiles.Add(p));
            context.SaveChanges();

           
            //posty |||| problem z datą :/
            var posts = new List<Post>()
            {
                new Post { Title = "Transfer Cristiano Ronaldo" , Header = "Uwaga uwaga znana gwiazda pilki nożnej przechodzi z Realu Madrid do Juventus!" ,  Content = "" ,PostDate = DateTime.Now},
                new Post { Title = "news 2" , Header = "witaj w poscie 2!" ,  Content = "wspaniałe wiesci, czytasz wlasnie post 2" ,PostDate = DateTime.Now},
                new Post { Title = "news 3" , Header = "witaj w poscie 3!" ,  Content = "wspaniałe wiesci, czytasz wlasnie post 3" ,PostDate = DateTime.Now}
            };
            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();

          

            //categoria forum
            var forumCategories = new List<ForumCategory>()
            {
                new ForumCategory { Title = "proba 1" },
                 new ForumCategory { Title = "proba 2" }//,PostDate = new DateTime(2019-03-09)}
            };
            forumCategories.ForEach(p => context.ForumCategories.Add(p));
            context.SaveChanges();

            //tematy forum
            var forumSubjects = new List<ForumSubject>()
            {
                new ForumSubject { Title = "normalny ",ForumCategory = forumCategories[0] },
                 new ForumSubject { Title = "normalny 2",ForumCategory = forumCategories[1] }
            };
            forumSubjects.ForEach(p => context.ForumSubjects.Add(p));
            context.SaveChanges();

      
            var status = new List<Status>()
            {
                new Status {  Name = "Expectant"},
                new Status { Name = "Accepted"}
            };
            status.ForEach(f => context.Status.Add(f));
            context.SaveChanges();

            var kindOfDelivery = new List<KindOfDelivery>()
            {
               new KindOfDelivery {Name = "Prepayment" , PriceForDelivery = 9},
               new KindOfDelivery {Name = "Cash on delivery" , PriceForDelivery = 15},
               new KindOfDelivery {Name = "Personal pickup" , PriceForDelivery = 0}
            };
            kindOfDelivery.ForEach(f => context.KindOfDelivery.Add(f));
            context.SaveChanges();


            var delivery = new List<DeliveryOption>()
            {
               new DeliveryOption {Name = "Paczkomaty 24/7" , KindOfDeliveryID = 3},
               new DeliveryOption {Name = "Poczta Polska" , KindOfDeliveryID = 1 },
               new DeliveryOption {Name = "Poczta Polska" ,KindOfDeliveryID = 2 },
               new DeliveryOption {Name = "GLS" ,KindOfDeliveryID = 1 },
               new DeliveryOption {Name = "GLS" ,KindOfDeliveryID = 2 },
               new DeliveryOption {Name = "DPD" ,KindOfDeliveryID = 1 },
               new DeliveryOption {Name = "DPD" ,KindOfDeliveryID = 2 },
               new DeliveryOption {Name = "DHL" ,KindOfDeliveryID = 1 },
               new DeliveryOption {Name = "DHL" ,KindOfDeliveryID = 2 },
               new DeliveryOption {Name = "GRATIS" ,KindOfDeliveryID = 3 }
            };
            delivery.ForEach(f => context.DeliveryOption.Add(f));
            context.SaveChanges();

            base.Seed(context);


            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));
            

            var user = new ApplicationUser { UserName = "b.longota2@wp.pl" };
            string password = "Complex.Password.123";

            var user1 = new ApplicationUser { UserName = "test@wp.pl" };
            string password1 = "Admin202";

            userManager.Create(user1, password1);
           
            userManager.Create(user, password);
            userManager.AddToRole(user.Id , "Admin");
                
        }
    }
}