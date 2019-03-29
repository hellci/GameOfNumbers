using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class Form1 : Form
    {
        int _numberOfTries = 0;
        int _maxNumber = 25;
        int _actualNumber = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblResult.Visible = true;
            if (_numberOfTries >= 5)
            {
                MessageBox.Show("To try again, click start over!", "You Lost!");
                lblResult.Text = "Sorry, you have exceeded the allowed number of tries!";
                return;
            }
            int input = 0;
            string result = "Sorry! Wrong Guess!";
            if (int.TryParse(cbInput.Text, out input))
            {
                result = new CompareInputs().IsTheSame(input, _actualNumber);
                if (result.Contains("Success"))
                {
                    MessageBox.Show("You guessed right!", "Congratulations!");
                    var wordEnd = _numberOfTries == 0 ? "y" : "ies";
                    lblResult.Text = $"You guessed right in {_numberOfTries + 1} tr{ wordEnd}!{Environment.NewLine}And you won {((_maxNumber / 5) * (5 - _numberOfTries))}$";
                    lblResult.ForeColor = Color.Green;
                    Reset();
                    return;
                }
            }
            lblResult.Text = result;
            _numberOfTries++;
            lblPrize.Text = ((_maxNumber / 5) * (5 - _numberOfTries)).ToString();
            pbTrials.PerformStep();

            ModifyProgressBarColor.SetState(pbTrials, _numberOfTries == 1 ? 1 : _numberOfTries < 4 ? 3 : 2);
            if (_numberOfTries >= 5)
            {
                MessageBox.Show("To try again, click start over!", "You Lost!");
                lblResult.Text = "Sorry, you have exceeded the allowed number of tries!";
                return;
            }
        }

        private void tbDifficulty_Scroll(object sender, EventArgs e)
        {
            var tb = (TrackBar)sender;
            switch (tb.Value)
            {
                case 1:
                    _maxNumber = 25;
                    break;
                case 2:
                    _maxNumber = 50;
                    break;
                case 3:
                    _maxNumber = 100;
                    break;
                default:
                    _maxNumber = 25;
                    break;
            }
            lblPrize.Text = _maxNumber.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Button start = (Button)sender;
            if (!start.Text.Contains("Over"))
            {
                start.Text = "Start Over!";
                tbDifficulty.Enabled = false;
                groupBox1.Enabled = true;
                RandomNumberGenerator generator = new RandomNumberGenerator(1, _maxNumber, 5);
                List<int> numbers = new List<int>();
                ModifyProgressBarColor.SetState(pbTrials, 1);
                _actualNumber = generator.Generate();
                for (int i = 1; i <= _maxNumber; i++)
                {
                    numbers.Add(i);
                }
                cbInput.DataSource = numbers;
                groupBox1.Text = "Started...";
            }
            else
            {
                Reset();
                lblResult.Visible = false;
            }
        }

        /// <summary>
        /// Reset form controls and values to the default
        /// </summary>
        public void Reset()
        {
            btnStart.Text = "Start!";
            tbDifficulty.Enabled = true;
            groupBox1.Enabled = false;
            groupBox1.Text = "Click start to begin";
            _numberOfTries = 0;
            pbTrials.Value = 0;
        }
    }
}
