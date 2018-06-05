using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascu_Andreea_FORM_1052
{
    enum SoccerTeams
    {
        RealMadrid,
        FCBarcelona,
        Juventus,
        ManchesterUnited,
        Chelsea,
        Arsenal,
        SteauaBucuresti,
        DinamoBucuresti,
        ACMilan,
        SportingLisabon,
        Celtic,
        BorussiaDortmund
    };
    enum BasketballTeams
    {
        BostonCeltics,
        NewYorkKnicks,
        LosAngelesLakers,
        Philadelphia76ers,
        ChicagoBulls,
        MilwaukeeBucks,
        DetroitPistons,
        AtlantaHawks,
        PhoenixSuns,
        DallasMavericks,
        IndianaPacers,
        MiamiHeat
    };
    enum TennisPlayers
    {
        RafaelNadal,
        RogerFederer,
        NovakDjokovic,
        SerenaWilliams,
        AndyMurray,
        MariaSharapova,
        VenusWilliams,
        AndreAgassi,
        DavidFerrer,
        SimonaHalep,
        JimmyConnors,
        DiegoSchwartzman
    };

    class Game: MainBetForm
    {
        String team1;
        String team2;
        double[] odds;
        string score1;
        string score2;

        public Game()
        {
            this.team1 = "";
            this.team2 = "";
            this.score1 = "";
            this.score2 = "";
            this.odds = new double[3];
            for (int i = 0; i < 3; i++)
            {
                this.odds[i] = 0;
            }
        }
        public void setTeams(Random rnd)
        {
            int team1 = 0; int team2 = 0;
            team1 = (int)rnd.Next(12);
            this.team1 = Enum.GetName(typeof(SoccerTeams), team1);
            team2 = (int)rnd.Next(12);
            if (team1 == team2)
                while (team1 == team2)
                {
                    team2 = (int)rnd.Next(12);
                }
            this.team2 = Enum.GetName(typeof(SoccerTeams), team2);
        }
        public void setTeams(string t1, string t2)
        {
            this.team1 = t1;
            this.team2 = t2;
        }
        public void setBasketballTeams(Random rnd)
        {
            int team1 = 0; int team2 = 0;
            team1 = (int)rnd.Next(12);
            this.team1 = Enum.GetName(typeof(BasketballTeams), team1);
            team2 = (int)rnd.Next(12);
            if (team1 == team2)
                while (team1 == team2)
                {
                    team2 = (int)rnd.Next(12);
                }
            this.team2 = Enum.GetName(typeof(BasketballTeams), team2);
        }
        public void setTennisGame(Random rnd)
        {
            int team1 = 0; int team2 = 0;
            team1 = (int)rnd.Next(12);
            this.team1 = Enum.GetName(typeof(TennisPlayers), team1);
            team2 = (int)rnd.Next(12);
            if (team1 == team2)
                while (team1 == team2)
                {
                    team2 = (int)rnd.Next(12);
                }
            this.team2 = Enum.GetName(typeof(TennisPlayers), team2);
        }
        
        public double[] setOdds(Random rnd)
        {
            this.odds = new double[3];
            for (int i = 0; i < 3; i++)
            {
                this.odds[i] = rnd.Next(1,12) + rnd.NextDouble();
            }
            return this.odds;
        }
        public string getTeams()
        {
            return this.team1 + " - " + this.team2;
        }
        public string getOdds()
        {
            string buff = "";
            for (int i = 0; i < 3; i++)
            {
                buff += this.odds[i].ToString("0.00") + ", ";
            }
            return buff;
        }
        public double getOddsByIndex(int i)
        {
            if (i >= 0 && i <= 2)
                return this.odds[i];
            else return 0;
        }

        public void setScores(Random rnd)
        {
    
                this.score1 += (int)rnd.Next(5);
                this.score2 += (int)rnd.Next(5);
            
        }
        public string getScores()
        {
            return this.score1+" - "+this.score2;
        }
        public void setBasketballScores(Random rnd)
        {

            this.score1 += (int)rnd.Next(70,130);
            this.score2 += (int)rnd.Next(70,130);
        }        
        public string getTeam1()
        {
            return this.team1;
        }
        public string getTeam2()
        {
            return this.team2;
        }
    }


}
