using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascu_Andreea_FORM_1052
{
    [Serializable]
    public class Bet
    {
        public string UserName { get; set; }
        public DateTime birthDate { get; set; }
        public char gender { get; set; }
        public DateTime currentDate { get; set; }
        public int betAmount { get; set; }
        public double possibleGain { get; set; }
        public double oddsBet { get; set; }
        public string MatchName { get; set; }
        public string WinTeam { get; set; }
        public bool winStatus { get; set; }

        public Bet()
        {
            this.UserName = "";
            this.birthDate = DateTime.Today;
            char gender = ' ';
            this.currentDate = DateTime.Today;
            betAmount = 0;
            possibleGain = 0;
            oddsBet = 0;
            MatchName = "";
            WinTeam = "";
            winStatus = false;
        }
        public Bet(string userName, DateTime bDate, char gen, int betA,double oddB, string MatchN)
        {
            this.UserName = userName;
            this.birthDate = bDate;
            this.gender = gen;
            this.currentDate = DateTime.Today;
            this.betAmount = betA;
            this.possibleGain = betA*oddB;
            this.oddsBet = oddB;
            this.MatchName = MatchN;
            
        }
        public void setWinStatus(bool code)
        {
            this.winStatus = code;
        }
        public void setWinTeam(string WinT)
        {
            this.WinTeam = WinT;
        }
        public double getPossibleGain()
        {
            return this.possibleGain;
        }
    }
}
