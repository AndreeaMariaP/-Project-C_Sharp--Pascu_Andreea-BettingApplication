using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pascu_Andreea_FORM_1052
{
    public partial class HowToBet : Form
    {
        public HowToBet()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;          
            double cash = 1;
            double payout = 5.6 * cash;
            int ph = panel1.Height - 5;
            int pw = panel1.Width - 60;
            float cashWPercentage = (float)(cash / payout);
            float profit = (float)(payout - cash);

            //Rectangle(x, y, widith, height)
            g.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ph / 3, (int)(pw * cashWPercentage)),
                Color.RosyBrown, Color.SaddleBrown), 0, 0 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 0 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawString(cash.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 0 * (ph / 3));

            g.FillRectangle(new LinearGradientBrush(new Point(0, 1 * (ph / 3)), new Point(2 * ph / 3, (int)(pw)),
                Color.MediumSeaGreen, Color.DarkSlateGray), 0, 1 * (ph / 3), pw, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 1 * (ph / 3), pw, ph / 3);
            g.DrawString(payout.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 1 * (ph / 3));

            g.FillRectangle(new LinearGradientBrush(new Point(pw * (int)cashWPercentage, 2 * (ph / 3)),
                new Point(ph, pw - (pw * (int)cashWPercentage - 10)), Color.OrangeRed, Color.Red), pw * cashWPercentage, 2 * (ph / 3),
                pw - pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 2 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), pw * cashWPercentage, 2 * (ph / 3), pw - pw * cashWPercentage, ph / 3);
            g.DrawString(profit.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 2 * (ph / 3));

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            double cash = 4;
            double payout = 9.87 * cash;
            int ph = panel2.Height - 5;
            int pw = panel2.Width - 60;
            float cashWPercentage = (float)(cash / payout);
            float profit = (float)(payout - cash);

            //(x, y, widith, height)
            g.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(ph / 3, (int)(pw * cashWPercentage)), Color.RosyBrown, Color.SaddleBrown), 0, 0 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 0 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawString(cash.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 0 * (ph / 3));

            g.FillRectangle(new LinearGradientBrush(new Point(0, 1 * (ph / 3)), new Point(2 * ph / 3, (int)(pw)), Color.MediumSeaGreen, Color.DarkSlateGray), 0, 1 * (ph / 3), pw, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 1 * (ph / 3), pw, ph / 3);
            g.DrawString(payout.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 1 * (ph / 3));

            g.FillRectangle(new LinearGradientBrush(new Point(pw * (int)cashWPercentage, 2 * (ph / 3)), new Point(ph, pw - (pw * (int)cashWPercentage-10)), Color.OrangeRed, Color.Red), pw * cashWPercentage, 2 * (ph / 3), pw - pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), 0, 2 * (ph / 3), pw * cashWPercentage, ph / 3);
            g.DrawRectangle(new Pen(Color.Black), pw * cashWPercentage, 2 * (ph / 3), pw - pw * cashWPercentage, ph / 3);
            g.DrawString(profit.ToString("0.00"), new Font("Microsoft Sans Serif", 10f), Brushes.White, pw + 1, 10 + 2 * (ph / 3));
        }

        private void HowToBet_Load(object sender, EventArgs e)
        {

        }
    }
}
