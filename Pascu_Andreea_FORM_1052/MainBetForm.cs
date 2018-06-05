using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pascu_Andreea_FORM_1052
{
    public partial class MainBetForm : Form
    {

        Random rnd = new Random();


        List<Button> btnOddsList = new List<Button>();
        List<Button> btnBasketballOddsList = new List<Button>();
        List<Button> btnTennisOddsList = new List<Button>();
        List<Label> lblMatchList = new List<Label>();
        List<Label> lblBasketballMatchList = new List<Label>();
        List<Label> lblTennisMatchList = new List<Label>();
        List<Label> lblEndedMatchList = new List<Label>();
        List<Label> lblEndedBasketballMatchList = new List<Label>();
        List<Label> lblEndedTennisMatchList = new List<Label>();
        List<Label> lblEndedMatchScoreList = new List<Label>();
        List<Label> lblEndedBasketballMatchScoreList = new List<Label>();
        List<Label> lblEndedTennisMatchScoreList = new List<Label>();

        List<double> oddsValues = new List<double>();
        List<double> oddsBasketballValues = new List<double>();
        List<double> oddsTennisValues = new List<double>();
        List<string> finalScores = new List<string>();
        List<string> finalBasketballScores = new List<string>();
        

        LinkedList<Game> gamesList = new LinkedList<Game>();
        LinkedList<Game> gamesList2 = new LinkedList<Game>();
        LinkedList<Game> basketballGamesList = new LinkedList<Game>();
        LinkedList<Game> basketballGamesList2 = new LinkedList<Game>();
        LinkedList<Game> tennisGamesList = new LinkedList<Game>();
        LinkedList<Game> tennisGamesList2 = new LinkedList<Game>();

        LinkedList<Label> lblTimerList = new LinkedList<Label>();
        LinkedList<Label> lblTimerList2 = new LinkedList<Label>();
        LinkedList<Label> lblTimerList3 = new LinkedList<Label>();

        
        LinkedList<ProgressBar> pbList = new LinkedList<ProgressBar>();
        LinkedList<ProgressBar> pbList2 = new LinkedList<ProgressBar>();
        LinkedList<ProgressBar> pbList3 = new LinkedList<ProgressBar>();

        private int i = 0;
        private int j = 0;

        public MainBetForm()
        {
            InitializeComponent();       
            InitDateTimer();
            InitDateTimer2();
            InitDateTimer3();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            InitGamesList(rnd);
            InitGamesList2(rnd);
            InitBasketballGamesList(rnd);
            InitBasketballGamesList2(rnd);
            InitTennisGamesList(rnd);
            InitTennisGamesList2(rnd);


            InitOddsValues();
            InitOddsBasketballAndTennisValues();

            InitLblMatchList();
            InitLblEndedMatchList();
            InitLblBasketballMatchList();
            InitLblEndedBasketballMatchList();
            InitLblTennisMatchList();
            InitLblEndedTennisMatchList();

            InitBtnOddsList();
            InitBtnBasketballOddsList();
            InitBtnTennisballOddsList();

            InitFinalScores();
            InitFinalBasketballScores();           
            InitLblEndedMatchScoreList();
            InitLblEndedBasketballMatchScoreList();
            InitLblEndedTennisMatchScoreList();

            InitLblTimerList();
            InitLblTimerList2();
            InitLblTimerList3();
            
            InitPbList();
            InitPbList2();
            InitPbList3();

        }
        private void InitGamesList(Random rnd)
        {
            for (int i = 0; i < 5; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setTeams(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in gamesList)
                        {
                            if (
                                (!item.getTeam1().Equals(game.getTeam1()) && !item.getTeam1().Equals(game.getTeam2())) &&
                                (!item.getTeam2().Equals(game.getTeam1()) && !item.getTeam2().Equals(game.getTeam2())) )
                            {
                                counter--;
                            }                           
                        }
                        if (counter > 0)
                            game.setTeams(rnd);
                        else
                            teamIsOk = true;
                    }
                    //if (teamIsOk != true)
                    //    throw new Exception("No more teams available");
                }
                rnd.Next(10);
                game.setOdds(rnd);
                this.gamesList.AddLast(game);
            }
        }
        private void InitGamesList2(Random rnd)
        {
              
            for (int i = 0; i < 6; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setTeams(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in gamesList2)
                        {
                            if (!game.getTeam1().Equals(item.getTeam1()) && !game.getTeam2().Equals(item.getTeam2()) &&
                                !game.getTeam1().Equals(item.getTeam2()) && !game.getTeam2().Equals(item.getTeam1()) )
                            {
                                counter--;
                            }
                        }
                        if (counter > 0)
                            game.setTeams(rnd);
                        else
                            teamIsOk = true;
                    }
                    //if (teamIsOk != true)
                    //    throw new Exception("No more teams available");
                }
                rnd.Next(10);
                game.setOdds(rnd);               
                game.setScores(rnd);
                this.gamesList2.AddLast(game);
            }
        }
        private void InitBasketballGamesList(Random rnd)
        {
            for (int i = 0; i < 5; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setBasketballTeams(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in basketballGamesList)
                        {
                            if (
                                (!item.getTeam1().Equals(game.getTeam1()) && !item.getTeam1().Equals(game.getTeam2())) &&
                                (!item.getTeam2().Equals(game.getTeam1()) && !item.getTeam2().Equals(game.getTeam2())))
                            {
                                counter--;
                            }
                        }
                        if (counter > 0)
                            game.setBasketballTeams(rnd);
                        else
                            teamIsOk = true;
                    }

                }
                rnd.Next(10);
                game.setOdds(rnd);
                this.basketballGamesList.AddLast(game);
            }
        }
        private void InitBasketballGamesList2(Random rnd)
        {
            for (int i = 0; i < 3; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setBasketballTeams(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in basketballGamesList2)
                        {
                            if (
                                (!item.getTeam1().Equals(game.getTeam1()) && !item.getTeam1().Equals(game.getTeam2())) &&
                                (!item.getTeam2().Equals(game.getTeam1()) && !item.getTeam2().Equals(game.getTeam2())))
                            {
                                counter--;
                            }
                        }
                        if (counter > 0)
                            game.setBasketballTeams(rnd);
                        else
                            teamIsOk = true;
                    }

                }
                rnd.Next(10);
                game.setOdds(rnd);
                game.setBasketballScores(rnd);
                this.basketballGamesList2.AddLast(game);
            }
        }
        private void InitTennisGamesList(Random rnd)
        {
            for (int i = 0; i < 5; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setTennisGame(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in tennisGamesList)
                        {
                            if (
                                (!item.getTeam1().Equals(game.getTeam1()) && !item.getTeam1().Equals(game.getTeam2())) &&
                                (!item.getTeam2().Equals(game.getTeam1()) && !item.getTeam2().Equals(game.getTeam2())))
                            {
                                counter--;
                            }
                        }
                        if (counter > 0)
                            game.setTennisGame(rnd);
                        else
                            teamIsOk = true;
                    }

                }
                rnd.Next(10);
                game.setOdds(rnd);
                this.tennisGamesList.AddLast(game);
            }
        }
        private void InitTennisGamesList2(Random rnd)
        {
            for (int i = 0; i < 3; i++)
            {
                bool teamIsOk = false;
                Game game = new Game();
                int j = 0;
                game.setTennisGame(rnd);
                if (i > 0)
                {
                    while (teamIsOk == false)
                    {
                        int counter = i;
                        foreach (var item in tennisGamesList2)
                        {
                            if (
                                (!item.getTeam1().Equals(game.getTeam1()) && !item.getTeam1().Equals(game.getTeam2())) &&
                                (!item.getTeam2().Equals(game.getTeam1()) && !item.getTeam2().Equals(game.getTeam2())))
                            {
                                counter--;
                            }
                        }
                        if (counter > 0)
                            game.setTennisGame(rnd);
                        else
                            teamIsOk = true;
                    }

                }
                rnd.Next(10);
                game.setOdds(rnd);
                //game.setScores(rnd);
                this.tennisGamesList2.AddLast(game);
            }
        }


        private void InitOddsValues()
        {
            foreach (var item in gamesList)
            {
                for (int i = 0; i < 3; i++)
                {
                    oddsValues.Add(item.getOddsByIndex(i));
                }

            }
        }
        private void InitOddsBasketballAndTennisValues()
        {
            foreach (var item in basketballGamesList)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.oddsBasketballValues.Add(item.getOddsByIndex(i));
                }

            }
            foreach (var item in tennisGamesList)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.oddsTennisValues.Add(item.getOddsByIndex(i));
                }

            }
        }

        private List<Label> InitLblMatchList()
        {
            lblMatchList.Add(game1);
            lblMatchList.Add(game2);
            lblMatchList.Add(game3);
            lblMatchList.Add(game4);
            lblMatchList.Add(game5);
            int i = 0;
            foreach (var item in lblMatchList)
            {
                item.Text = gamesList.ElementAt(i).getTeams();
                i++;
            }
            return lblMatchList;
        }
        private List<Label> InitLblEndedMatchList()
        {
            lblEndedMatchList.Add(lblEM1);
            lblEndedMatchList.Add(lblEM2);
            lblEndedMatchList.Add(lblEM3);
            lblEndedMatchList.Add(lblEM4);
            lblEndedMatchList.Add(lblEM5);
            lblEndedMatchList.Add(lblEM6);
            int i = 0;
            foreach (var item in lblEndedMatchList)
            {
                item.Text = gamesList2.ElementAt(i).getTeams();
                i++;
            }
            return lblEndedMatchList;
        }
        private List<Label> InitLblBasketballMatchList()
        {
            lblBasketballMatchList.Add(basketball1);
            lblBasketballMatchList.Add(basketball2);
            lblBasketballMatchList.Add(basketball3);
            lblBasketballMatchList.Add(basketball4);
            lblBasketballMatchList.Add(basketball5);
            int i = 0;
            foreach (var item in lblBasketballMatchList)
            {
                item.Text = basketballGamesList.ElementAt(i).getTeams();
                i++;
            }

            return lblBasketballMatchList;
        }
        private List<Label> InitLblEndedBasketballMatchList()
        {
            lblEndedBasketballMatchList.Add(lblEB1);
            lblEndedBasketballMatchList.Add(lblEB2);
            lblEndedBasketballMatchList.Add(lblEB3);
            int i = 0;
            foreach (var item in lblEndedBasketballMatchList)
            {
                item.Text = basketballGamesList2.ElementAt(i).getTeams();
                i++;
            }
            return lblEndedBasketballMatchList;
        }
        private List<Label> InitLblTennisMatchList()
        {
            lblTennisMatchList.Add(tennis1);
            lblTennisMatchList.Add(tennis2);
            lblTennisMatchList.Add(tennis3);
            lblTennisMatchList.Add(tennis4);
            lblTennisMatchList.Add(tennis5);
            int i = 0;
            foreach (var item in lblTennisMatchList)
            {
                item.Text = tennisGamesList.ElementAt(i).getTeams();
                i++;
            }

            return lblTennisMatchList;
        }
        private List<Label> InitLblEndedTennisMatchList()
        {
            lblEndedTennisMatchList.Add(lblET1);
            lblEndedTennisMatchList.Add(lblET2);
            lblEndedTennisMatchList.Add(lblET3);
            int i = 0;
            foreach (var item in lblEndedTennisMatchList)
            {
                item.Text = tennisGamesList2.ElementAt(i).getTeams();
                i++;
            }

            return lblEndedTennisMatchList;

        }


        private List<Button> InitBtnOddsList()
        {
            this.btnOddsList.Add(btnG11);          
            this.btnOddsList.Add(btnG12);
            this.btnOddsList.Add(btnG13);
            this.btnOddsList.Add(btnG21);
            this.btnOddsList.Add(btnG22);
            this.btnOddsList.Add(btnG23);
            this.btnOddsList.Add(btnG31);
            this.btnOddsList.Add(btnG32);
            this.btnOddsList.Add(btnG33);
            this.btnOddsList.Add(btnG41);
            this.btnOddsList.Add(btnG42);
            this.btnOddsList.Add(btnG43);
            this.btnOddsList.Add(btnG51);
            this.btnOddsList.Add(btnG52);
            this.btnOddsList.Add(btnG53);
            int i = 0;
            foreach (var item in btnOddsList)
            {
                item.Text = oddsValues.ElementAt(i).ToString("0.00");
                i++;
            }
            foreach (var button in btnOddsList)
            {
                button.Click += btnG_Click;
            }
            return this.btnOddsList;
        }
        private List<Button> InitBtnBasketballOddsList()
        {
            this.btnBasketballOddsList.Add(btnB11);
            this.btnBasketballOddsList.Add(btnB12);
            this.btnBasketballOddsList.Add(btnB21);
            this.btnBasketballOddsList.Add(btnB22);
            this.btnBasketballOddsList.Add(btnB31);
            this.btnBasketballOddsList.Add(btnB32);
            this.btnBasketballOddsList.Add(btnB41);
            this.btnBasketballOddsList.Add(btnB42);
            this.btnBasketballOddsList.Add(btnB51);
            this.btnBasketballOddsList.Add(btnB52);
                int i = 0;
            foreach (var item in btnBasketballOddsList)
            {
                item.Text = oddsBasketballValues.ElementAt(i).ToString("0.00");
                i++;
            }
            foreach (var button in btnBasketballOddsList)
            {
                button.Click += btnB_Click;
            }
            return this.btnBasketballOddsList;

        }
        private List<Button> InitBtnTennisballOddsList()
        {
            this.btnTennisOddsList.Add(btnT11);
            this.btnTennisOddsList.Add(btnT12);
            this.btnTennisOddsList.Add(btnT21);
            this.btnTennisOddsList.Add(btnT22);
            this.btnTennisOddsList.Add(btnT31);
            this.btnTennisOddsList.Add(btnT32);
            this.btnTennisOddsList.Add(btnT41);
            this.btnTennisOddsList.Add(btnT42);
            this.btnTennisOddsList.Add(btnT51);
            this.btnTennisOddsList.Add(btnT52);
            int i = 0;
            foreach (var item in btnTennisOddsList)
            {
                item.Text = oddsTennisValues.ElementAt(i).ToString("0.00");
                i++;
            }
            foreach (var button in btnTennisOddsList)
            {
                button.Click += btnT_Click;
            }
            return this.btnTennisOddsList;
        }

        private void InitFinalScores()
        {
            foreach (var item in gamesList2)
            {
                finalScores.Add(item.getScores());
            }
        }
        private void InitFinalBasketballScores()
        {
            foreach (var item in basketballGamesList2)
            {
                finalBasketballScores.Add(item.getScores());
            }
        }

        

        private void InitLblEndedMatchScoreList()
        {          
            lblEndedMatchScoreList.Add(lblScore1);
            lblEndedMatchScoreList.Add(lblScore2);
            lblEndedMatchScoreList.Add(lblScore3);
            lblEndedMatchScoreList.Add(lblScore4);
            lblEndedMatchScoreList.Add(lblScore5);
            lblEndedMatchScoreList.Add(lblScore6);
            int i = 0;
            foreach (var item in lblEndedMatchScoreList)
            {
                item.Text = finalScores.ElementAt(i);
                i++;
            }
        }
        private void InitLblEndedBasketballMatchScoreList()
        {
            lblEndedBasketballMatchScoreList.Add(lblSB1);
            lblEndedBasketballMatchScoreList.Add(lblSB2);
            lblEndedBasketballMatchScoreList.Add(lblSB3);
            int i = 0;
            foreach (var item in lblEndedBasketballMatchScoreList)
            {
                item.Text = finalBasketballScores.ElementAt(i);
                i++;
            }
        }
        private void InitLblEndedTennisMatchScoreList()
        {
            lblEndedTennisMatchScoreList.Add(lblST1);
            lblEndedTennisMatchScoreList.Add(lblST2);
            lblEndedTennisMatchScoreList.Add(lblST3);
            int i = 0;
            foreach (var item in lblEndedTennisMatchScoreList)
            {
                if(i%2==1)
                  item.Text = tennisGamesList2.ElementAt(i).getTeam1()+" -Winner-";
                else
                  item.Text = tennisGamesList2.ElementAt(i).getTeam2() + " -Winner-";
                i++;
            }
        }

        private LinkedList<Label> InitLblTimerList()
        {
            lblTimerList.AddLast(lblT1);
            lblTimerList.AddLast(lblT2);
            lblTimerList.AddLast(lblT3);
            lblTimerList.AddLast(lblT4);
            lblTimerList.AddLast(lblT5);
            return lblTimerList;
        }
        private LinkedList<Label> InitLblTimerList2()
        {
            lblTimerList2.AddLast(lblT9);
            lblTimerList2.AddLast(lblT10);
            lblTimerList2.AddLast(lblT11);
            lblTimerList2.AddLast(lblT12);
            return lblTimerList2;
        }
        private LinkedList<Label> InitLblTimerList3()
        {
            lblTimerList3.AddLast(lblT6);
            lblTimerList3.AddLast(lblT7);
            lblTimerList3.AddLast(lblT8);
            lblTimerList3.AddLast(lblT13);
            lblTimerList3.AddLast(lblT14);
            lblTimerList3.AddLast(lblT15);
            return lblTimerList3;
        }

        
        private LinkedList<ProgressBar> InitPbList()
        {
            pbList.AddLast(progressBar1);
            pbList.AddLast(progressBar2);
            pbList.AddLast(progressBar3);
            pbList.AddLast(progressBar4);
            pbList.AddLast(progressBar5);

            return pbList;
        }
        private LinkedList<ProgressBar> InitPbList2()
        {
            pbList2.AddLast(progressBar9);
            pbList2.AddLast(progressBar10);
            pbList2.AddLast(progressBar11);
            pbList2.AddLast(progressBar12);
            return pbList2;
        }
        private LinkedList<ProgressBar> InitPbList3()
        {
            pbList3.AddLast(progressBar6);
            pbList3.AddLast(progressBar7);
            pbList3.AddLast(progressBar8);
            pbList3.AddLast(progressBar13);
            pbList3.AddLast(progressBar14);
            pbList3.AddLast(progressBar15);
            return pbList3;
        }


        private void btnG_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //string buttonName = button.Name;
            int buttonIndex = btnOddsList.IndexOf(button);
            double oddVal = oddsValues.ElementAt(buttonIndex);
            int nameIndex;
            string matchN;
            int option;
            string teamN;

            nameIndex = buttonIndex / 3;
            matchN = gamesList.ElementAt(nameIndex).getTeams();
            option = buttonIndex % 3;
            teamN = "Option ";

            if (option==0)
            {
                teamN += "1:  -"+gamesList.ElementAt(nameIndex).getTeam1() + "-  Winner";
            }
            else if(option==1)            {
                teamN +="X:  -Equality-";
            }
            else if(option==2)
            {
                teamN +="2:  -"+ gamesList.ElementAt(nameIndex).getTeam2() + "-  Winner";
            }

            AddBet d = new AddBet(matchN,teamN,oddVal);
            d.ShowDialog();
            

        }
        private void btnB_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
           
            int buttonIndex = btnBasketballOddsList.IndexOf(button);
            double oddVal = oddsBasketballValues.ElementAt(buttonIndex);
            int nameIndex;
            string matchN;
            int option;
            string teamN;

            nameIndex = buttonIndex / 2;
            matchN = basketballGamesList.ElementAt(nameIndex).getTeams();
            option = buttonIndex % 2;
            teamN = "Option ";

            if (option == 0)
            {
                teamN += "1:  -" + basketballGamesList.ElementAt(nameIndex).getTeam1() + "-  Winner";
            }
            else if (option == 1)
            {
                teamN += "2:  -" + basketballGamesList.ElementAt(nameIndex).getTeam2() + "-  Winner";
            }
            

            AddBet d = new AddBet(matchN, teamN, oddVal);
            d.ShowDialog();


        }
        private void btnT_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //string buttonName = button.Name;
            int buttonIndex = btnTennisOddsList.IndexOf(button);
            double oddVal = oddsTennisValues.ElementAt(buttonIndex);
            int nameIndex;
            string matchN;
            int option;
            string teamN;

            nameIndex = buttonIndex / 2;
            matchN = tennisGamesList.ElementAt(nameIndex).getTeams();
            option = buttonIndex % 2;
            teamN = "Option ";

            if (option == 0)
            {
                teamN += "1:  -" + tennisGamesList.ElementAt(nameIndex).getTeam1() + "-  Winner";
            }
            else if (option == 1)
            {
                teamN += "2:  -" + tennisGamesList.ElementAt(nameIndex).getTeam2() + "-  Winner";
            }
            

            AddBet d = new AddBet(matchN, teamN, oddVal);
            d.ShowDialog();


        }


        private void InitDateTimer()
        {
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Enabled = true;   
        }
        private void InitDateTimer2()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }
        private void InitDateTimer3()
        {
            timer3 = new System.Windows.Forms.Timer();
            timer3.Interval = 1;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Enabled = true;
        }
        DateTime date = DateTime.Now.AddSeconds(4).AddMinutes(1).AddHours(2);
        DateTime date2 = DateTime.Now.AddDays(8);
        DateTime date3 = DateTime.Now.AddSeconds(10);

        int m = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (date > DateTime.Now)
            {
                if (m == 0)
                {
                    //initialize component
                    double numberOfDays = 0;
                    numberOfDays = (date.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList)
                    {
                        if (numberOfDays == 0)
                        {

                            item.Text = (date - DateTime.Now).Hours.ToString() + "h:" +
                        (date - DateTime.Now).Minutes.ToString() + "m:" +
                        (date - DateTime.Now).Seconds.ToString() + "s left";


                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }
                    
                }
                else
                {
                    //proceed
                    //decrease by one milisec at each iteration
                    date = date.AddMilliseconds(-1);

                    System.TimeSpan diff = date.Subtract(DateTime.Now);
                    double numberOfDays = (date.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList)
                    {
                        if (numberOfDays == 0)
                        {
                            //iff no seconds are left, exit and start the clock else display the timer
                            if (diff.Seconds == 0 && diff.Hours==0&&diff.Minutes==0)
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                                InitTimer();

                            }
                            else
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                            }
                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }
                }
                m++;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (date2 > DateTime.Now)
            {
                if (m == 0)
                {
                    //initialize component
                    double numberOfDays = 0;
                    numberOfDays = (date2.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList2)
                    {
                        if (numberOfDays == 0)
                        {

                            item.Text = (date2 - DateTime.Now).Hours.ToString() + "h:" +
                        (date2 - DateTime.Now).Minutes.ToString() + "m:" +
                        (date2 - DateTime.Now).Seconds.ToString() + "s left";


                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }

                }
                else
                {
                    //proceed
                    //decrease by one milisec at each iteration
                    date2 = date2.AddMilliseconds(-1);

                    System.TimeSpan diff = date2.Subtract(DateTime.Now);
                    double numberOfDays = (date2.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList2)
                    {
                        if (numberOfDays == 0)
                        {
                            //iff no seconds are left, exit and start the clock else display the timer
                            if (diff.Seconds == 0 && diff.Hours == 0 && diff.Minutes == 0)
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                                InitTimer2();

                            }
                            else
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                            }
                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }
                }
                m++;
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (date3 > DateTime.Now)
            {
                if (m == 0)
                {
                    //initialize component
                    double numberOfDays = 0;
                    numberOfDays = (date3.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList3)
                    {
                        if (numberOfDays == 0)
                        {

                            item.Text = (date3 - DateTime.Now).Hours.ToString() + "h:" +
                        (date3 - DateTime.Now).Minutes.ToString() + "m:" +
                        (date3 - DateTime.Now).Seconds.ToString() + "s left";


                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }

                }
                else
                {
                    //proceed
                    //decrease by one milisec at each iteration
                    date3 = date3.AddMilliseconds(-1);

                    System.TimeSpan diff = date3.Subtract(DateTime.Now);
                    double numberOfDays = (date3.Date - DateTime.Now.Date).TotalDays;
                    foreach (var item in lblTimerList3)
                    {
                        if (numberOfDays == 0)
                        {
                            //iff no seconds are left, exit and start the clock else display the timer
                            if (diff.Seconds == 0 && diff.Hours == 0 && diff.Minutes == 0)
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                                InitTimer3();

                            }
                            else
                            {
                                item.Text = diff.Hours.ToString() + "h:" +
                                diff.Minutes.ToString() + "m:" +
                                diff.Seconds.ToString() + "s left";
                            }
                        }
                        else
                        {
                            item.Text = numberOfDays.ToString("00") + " days remaining";
                        }
                    }
                }
                m++;
            }
        }

        private void InitTimer()
        {

            timer2.Stop();
            timer2 = null;
            timer2 = new System.Windows.Forms.Timer();
            timer2.Interval = 1;
            timer2.Tick += new EventHandler(timer_Tick);
            timer2.Enabled = true;
        }
        private void InitTimer2()
        {

            timer1.Stop();
            timer1 = null;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer_Tick2);
            timer1.Enabled = true;
        }
        private void InitTimer3()
        {
            timer3.Stop();
            timer3 = null;
            timer3 = new System.Windows.Forms.Timer();
            timer3.Interval = 1;
            timer3.Tick += new EventHandler(timer_Tick3);
            timer3.Enabled = true;
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {
            //the use of List here slows the timer
            if (i == 0)
            {
                
                lblT1.Text = lblT2.Text = lblT3.Text = lblT4.Text= lblT5.Text = "00:00";
            }

            i++;
            j++;
            lblT1.Text = lblT2.Text = lblT3.Text = lblT4.Text = lblT5.Text= i / 3600 + ":";
            if (j % 3600 == 0)
            {
                lblT1.Text += "00";
                lblT2.Text += "00";
                lblT3.Text += "00";
                lblT4.Text += "00";
                lblT5.Text += "00";
                j = 0;
            }
            else
            {
                if ((j / 60) >= 10)
                {
                    lblT1.Text += (j / 60);
                    lblT2.Text += (j / 60);
                    lblT3.Text += (j / 60);
                    lblT4.Text += (j / 60);
                    lblT5.Text += (j / 60);
                }
                else
                {
                    lblT1.Text += "0" + (j / 60);
                    lblT2.Text += "0" + (j / 60);
                    lblT3.Text += "0" + (j / 60);
                    lblT4.Text += "0" + (j / 60);
                    lblT5.Text += "0" + (j / 60);
                }
            }

            if (i == 324000)
            {
                timer2.Stop();
                
            }
            if (i % 3240 == 0)
            {
                pbList.ElementAt(0).Increment(1);
                pbList.ElementAt(1).Increment(1);
                pbList.ElementAt(2).Increment(1);
                pbList.ElementAt(3).Increment(1);
                pbList.ElementAt(4).Increment(1);
                
            }

        }
        private void timer_Tick2(object sender, EventArgs e)
        {
           
            if (i == 0)
            {
                
                lblT9.Text = lblT10.Text = lblT11.Text = lblT12.Text = "00:00";
            }

            i++;
            j++;
            lblT9.Text = lblT10.Text = lblT11.Text = lblT12.Text = i / 3600 + ":";
            if (j % 3600 == 0)
            {
                lblT9.Text += "00";
                lblT10.Text += "00";
                lblT11.Text += "00";
                lblT12.Text += "00";
                
                j = 0;
            }
            else
            {
                if ((j / 60) >= 10)
                {
                    lblT9.Text += (j / 60);
                    lblT10.Text += (j / 60);
                    lblT11.Text += (j / 60);
                    lblT12.Text += (j / 60);
                    
                }
                else
                {
                    lblT9.Text += "0" + (j / 60);
                    lblT10.Text += "0" + (j / 60);
                    lblT11.Text += "0" + (j / 60);
                    lblT12.Text += "0" + (j / 60);
                    
                }
            }

            if (i == 324000)
            { timer1.Stop();  }
            if (i % 3240 == 0)
            {
                pbList2.ElementAt(0).Increment(1);
                pbList2.ElementAt(1).Increment(1);
                pbList2.ElementAt(2).Increment(1);
                pbList2.ElementAt(3).Increment(1);          
                
            }
        }
        private void timer_Tick3(object sender, EventArgs e)
        {
           
            if (i == 0)
            {
                lblT6.Text = lblT7.Text = lblT8.Text = lblT13.Text = lblT14.Text= lblT15.Text="00:00";
            }

            i++;
            j++;
            lblT6.Text = lblT7.Text = lblT8.Text = lblT13.Text = lblT14.Text = lblT15.Text = i / 3600 + ":";
            if (j % 3600 == 0)
            {
                lblT6.Text += "00";
                lblT7.Text += "00";
                lblT8.Text += "00";
                lblT13.Text += "00";
                lblT14.Text += "00";
                lblT15.Text += "00";

                j = 0;
            }
            else
            {
                if ((j / 60) >= 10)
                {                    
                    lblT6.Text += (j / 60);
                    lblT7.Text += (j / 60);
                    lblT8.Text += (j / 60);
                    lblT13.Text += (j / 60);
                    lblT14.Text += (j / 60);
                    lblT15.Text += (j / 60);
                }
                else
                {
                    lblT6.Text += "0" + (j / 60);
                    lblT7.Text += "0" + (j / 60);
                    lblT8.Text += "0" + (j / 60);
                    lblT13.Text += "0" + (j / 60);
                    lblT14.Text += "0" + (j / 60);
                    lblT15.Text += "0" + (j / 60);
                }
            }

            if (i == 324000)
            
                timer3.Stop();
                
            
            if (i % 3240 == 0)
            {
                pbList3.ElementAt(0).Increment(1);
                pbList3.ElementAt(1).Increment(1);
                pbList3.ElementAt(2).Increment(1);
                pbList3.ElementAt(3).Increment(1);
                pbList3.ElementAt(4).Increment(1);
                pbList3.ElementAt(5).Increment(1);
                
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.ForestGreen;
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.DimGray;
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.DarkGreen;
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.ForestGreen;
        }
        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.BackColor = Color.ForestGreen;
        }
        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.DimGray;
        }
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            label6.BackColor = Color.DarkGreen;
        }
        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            label6.BackColor = Color.ForestGreen;
        }
        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.BackColor = Color.ForestGreen;
        }
        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = Color.DimGray;
        }
        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            label7.BackColor = Color.DarkGreen;
        }
        private void label7_MouseUp(object sender, MouseEventArgs e)
        {
            label7.BackColor = Color.ForestGreen;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(tabControl1.SelectedIndex==0)
                label1.BackColor = Color.DarkGreen;
            else if(tabControl1.SelectedIndex == 1)
                     label6.BackColor = Color.DarkGreen;
            else label7.BackColor = Color.DarkGreen;

            if (e.Alt && e.KeyCode == Keys.L)
            {
                
                if (tabControl1.SelectedIndex != 0)
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        tabControl1.SelectTab(0);
                        label1.BackColor = Color.DarkGreen;
                        label6.BackColor = Color.DimGray;
                        label7.BackColor = Color.DimGray;
                    }
                    else
                    {
                        tabControl1.SelectTab(1);
                        label1.BackColor = Color.DimGray;
                        label6.BackColor = Color.DarkGreen;
                        label7.BackColor = Color.DimGray;
                    }
                }
            }
            else
            if (e.Alt && e.KeyCode == Keys.R)
            {
                
                if (tabControl1.SelectedIndex != 2)
                {

                    if (tabControl1.SelectedIndex == 0)
                    {
                        tabControl1.SelectTab(1);
                        label1.BackColor = Color.DimGray;
                        label6.BackColor = Color.DarkGreen;
                        label7.BackColor = Color.DimGray;
                    }
                    else
                    {
                        tabControl1.SelectTab(2);
                        label1.BackColor = Color.DimGray;
                        label6.BackColor = Color.DimGray;
                        label7.BackColor = Color.DarkGreen;
                    }
                }

            }

        }

        private void howToBETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToBet h = new HowToBet();
            h.ShowDialog();
        }
    }
}
