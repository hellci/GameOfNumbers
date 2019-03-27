using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class Form1 : Form
    {
        int _numberOfTries = 0;
        public Form1()
        {
            InitializeComponent();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 25; i++)
            {
                numbers.Add(i);
            }
            cbInput.DataSource = numbers;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_numberOfTries > 5)
            {
                MessageBox.Show("Sorry, you have exceeded the allowed number of tries!");
                return;
            }

            _numberOfTries++;
            pbTrials.Value = _numberOfTries;
            pbTrials.BackColor = Color.Red;

        }

        private void tbDifficulty_Scroll(object sender, EventArgs e)
        {
            var tb = (TrackBar)sender;
            switch (tb.Value)
            {
                case 1:
                    lblPrize.Text = "25$";
                    break;
                case 2:
                    lblPrize.Text = "50$";
                    break;
                case 3:
                    lblPrize.Text = "100$";
                    break;
                default:
                    lblPrize.Text = "25$";
                    break;
            }
        }
    }
}
