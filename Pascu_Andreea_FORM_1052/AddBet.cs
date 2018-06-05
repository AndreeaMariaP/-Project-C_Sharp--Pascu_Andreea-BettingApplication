using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Pascu_Andreea_FORM_1052
{
    
    public partial class AddBet : Form
    {

        List<Bet> betsList;
        char gender = ' ';
        public string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        
        private string ConnectionString =null;
        
        public AddBet(string matchN, string teamN, double oddValue)
        {
            InitializeComponent();
            lblShowOption.Text = teamN;
            lblShowOdd.Text = oddValue.ToString("0.00");
            lblShowMatchName.Text = matchN;
            setConnectionString();
        }

        public string setConnectionString()
        {
            string FileName = string.Format("{0}", Path.GetFullPath(Path.Combine(this.RunningPath, @"..\..\")));
            ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + FileName + "Resources\\BettingDatabase1.mdb;Persist Security Info=True";
            return ConnectionString;
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 1 && e.Row == 0 )
                e.Graphics.FillRectangle(Brushes.DimGray, e.CellBounds);
            if (e.Column == 1 && e.Row == 4)
                e.Graphics.FillRectangle(Brushes.DimGray, e.CellBounds);
        }
        
        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'm';
        }
        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = 'f';
        }
        
        private void AddBet_Load(object sender, EventArgs e)
        {
            betsList = new List<Bet>();
            if (File.Exists("SerializedBetsXML.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Bet>));
                using (StreamReader reader = new StreamReader("SerializedBetsXML.xml"))
                {
                    betsList = (List<Bet>)serializer.Deserialize(reader);
                }
            }
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (DateTime.Today.Date.AddYears(-18) < dtpBirthDate.Value.Date)
            {             
                errorProvider2.SetError(dtpBirthDate, "You should be 18+!");
                isValid = false;
                
            }
            
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                errorProvider1.SetError(tbName, "The Name should not be empty!");
                isValid = false;
                
            }
            if (!(rbtnMale.Checked || rbtnFemale.Checked))
            {
                errorProvider3.SetError(rbtnMale, "Check Your Gender!");
                isValid = false;
               
            }
            if (string.IsNullOrWhiteSpace(tbStake.Text))
            {
                errorProvider4.SetError(tbStake, "Insert integer values only!");
                isValid = false;
                
            }
            if (!isValid)
            {
                MessageBox.Show("The form contains errors!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
            {
                Bet bet = new Bet(tbName.Text, DateTime.Today.Date, gender, int.Parse(tbStake.Text),
                    double.Parse(lblShowOdd.Text), lblShowMatchName.Text);
                betsList.Add(bet);
                
                XmlSerializer serializer = new XmlSerializer(typeof(List<Bet>));
                using (StreamWriter writer = new StreamWriter("SerializedBetsXML.xml"))
                {
                    serializer.Serialize(writer, betsList);
                    writer.Close();
                }

                AddDataToDatabase(bet);

                Close();
            }
        }

       
        private void AddDataToDatabase(Bet bet)
        {
            
            var queryStringGambler = "insert into Gambler(gambler_name, birth_date, gender) values(@gamblerName,@birthDate,@gender);";
            var queryStringGame = "insert into Game(player1, player2) values(@player1,@player2);";
            var queryStringBet = "insert into Bet(gambler_id, game_id, player, stake, game_odd) values(@gamblerId,@gameId,@player, @stake, @gameOdd);";

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
               
                connection.Open();

                var insertCommandGambler = new OleDbCommand(queryStringGambler, connection);
                var insertCommandGame = new OleDbCommand(queryStringGame, connection);
                var insertCommandBet = new OleDbCommand(queryStringBet, connection);

                var gamblerNameParameter = new OleDbParameter("@gamblerName", bet.UserName);
                var birthDateParameter = new OleDbParameter("@birthDate", bet.birthDate.Date);
                var genderParameter = new OleDbParameter("@gender", bet.gender);

                string[] teamNames = bet.MatchName.Split(' ');
                var player1Parameter = new OleDbParameter("@player1", teamNames[0]);
                var player2Parameter = new OleDbParameter("@player2", teamNames[2]);

                insertCommandGame.Parameters.Add(player1Parameter);
                insertCommandGame.Parameters.Add(player2Parameter);
                insertCommandGame.ExecuteNonQuery();

                insertCommandGambler.Parameters.Add(gamblerNameParameter);
                insertCommandGambler.Parameters.Add(birthDateParameter);
                insertCommandGambler.Parameters.Add(genderParameter);
                insertCommandGambler.ExecuteNonQuery();
                
                var getGamblerIdCommand = new OleDbCommand("SELECT @@Identity FROM Gambler WHERE gambler_name= @gamblerN;", connection);
                var gamblerNameP = new OleDbParameter("@gamblerN", bet.UserName);
                getGamblerIdCommand.Parameters.Add(gamblerNameP);
                var gamblerId = (int)getGamblerIdCommand.ExecuteScalar();

                var getMatchIdCommand = new OleDbCommand("SELECT TOP 1 game_id FROM Game ORDER BY game_id DESC;", connection);
                var gameId = (int)getMatchIdCommand.ExecuteScalar();

                var gamblerIdParameter = new OleDbParameter("@gamblerId", gamblerId);
                var gameIdParameter = new OleDbParameter("@gameId", gameId);
                string[] player = lblShowOption.Text.Split('-');
                var playerParameter = new OleDbParameter("@player", player[1]);
                var stakeParameter = new OleDbParameter("@stake", bet.betAmount);
                var matchOddParameter = new OleDbParameter("@matchOdd", bet.oddsBet);

                insertCommandBet.Parameters.Add(gamblerIdParameter);
                insertCommandBet.Parameters.Add(gameIdParameter);
                insertCommandBet.Parameters.Add(playerParameter);
                insertCommandBet.Parameters.Add(stakeParameter);
                insertCommandBet.Parameters.Add(matchOddParameter);
                insertCommandBet.ExecuteNonQuery();
              
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "The Name should not be empty!");
                
            }
        }
        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.Clear();
           
        }
        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            DateTime bd = dtpBirthDate.Value.Date;
           
            if(today.AddYears(-18)<bd)
            {
                e.Cancel = true;
                errorProvider2.SetError((Control)sender, "You should be 18+!");
            }           
        }
        private void dtpBirthDate_Validated(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            
        }
        private void rbtnMale_Validated(object sender, EventArgs e)
        {
            errorProvider3.Clear();
            
        }
        private void rbtnMale_Validating(object sender, CancelEventArgs e)
        {
            if (!(rbtnMale.Checked || rbtnFemale.Checked))
            {
                e.Cancel = true;
                errorProvider3.SetError((Control)sender, "Check Your gender");
            }
        }
        private void rbtnFemale_Validated(object sender, EventArgs e)
        {
            errorProvider3.Clear();
            
        }
        private void rbtnFemale_Validating(object sender, CancelEventArgs e)
        {

            if (!(rbtnMale.Checked || rbtnFemale.Checked))
            {
                e.Cancel = true;
                errorProvider3.SetError((Control)sender, "Check Your gender");
            }
        }
        private void tbStake_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                //e.Cancel = true;
                errorProvider4.SetError((Control)sender, "Insert integer values only!");
            }
            else
            {
                double possibleGain = 0;
                possibleGain = int.Parse(tbStake.Text) * double.Parse(lblShowOdd.Text);
                lblPP2.Text = possibleGain.ToString("0.00") + " lei";
            }

        }
        private void tbStake_Validated(object sender, EventArgs e)
        {
            errorProvider4.Clear();
            double possibleGain = 0;
            possibleGain = int.Parse(tbStake.Text) * double.Parse(lblShowOdd.Text);
            lblPP2.Text = possibleGain.ToString("0.00") + " lei";
           
        }
        private void tbStake_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            
        }

        private void btnExportTicket_Click(object sender, EventArgs e)
        {
            
            if (!(DateTime.Today.Date.AddYears(-18) < dtpBirthDate.Value.Date)&&
                !(string.IsNullOrWhiteSpace(tbName.Text)) &&
                !(!(rbtnMale.Checked || rbtnFemale.Checked)) &&
                !(string.IsNullOrWhiteSpace(tbStake.Text)))
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File | *.txt";
                saveFileDialog.Title = "Save as text file";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        sw.WriteLine("FullName,   BirthDate, Gender, BettingOption,                         MatchName,                     OddValue, Stake, PotentialPayout");
                        Bet bettingTicket = betsList.Last<Bet>();


                        sw.WriteLine("{0},           {1},    {2},       {3},    {4}, {5},      {6},        {7}",
                            bettingTicket.UserName, bettingTicket.birthDate.ToShortDateString(),
                            bettingTicket.gender, lblShowOption.Text, lblShowMatchName.Text, lblShowOdd.Text,
                            bettingTicket.betAmount, lblPP2.Text);


                    }
                }
            }
        }

        private void tbStake_TextChanged(object sender, EventArgs e)
        {
            double possibleGain = 0;
            possibleGain = int.Parse(tbStake.Text) * double.Parse(lblShowOdd.Text);
            lblPP2.Text = possibleGain.ToString("0.00") + " lei";
        }
    }
}
