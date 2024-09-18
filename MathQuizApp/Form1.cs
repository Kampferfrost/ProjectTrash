using System.Media;

namespace MathQuizApp
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        Dictionary<string, int> _numbers = new Dictionary<string, int>();



        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// nad starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temproraryQuotiont = randomizer.Next(2, 11);
            dividend = divisor * temproraryQuotiont;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

            _numbers.Clear();
            _numbers.Add(sum.Name, addend1 + addend2);
            _numbers.Add(difference.Name, minuend - subtrahend);
            _numbers.Add(product.Name, multiplicand * multiplier);
            _numbers.Add(quotient.Name, dividend / divisor);
        }

        /// <summary>
        /// Check the answers to see if the user got everything right.
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void starButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor = default;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }




        }


        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }



        private bool CheckAAnswer(NumericUpDown trueBox)
        {
            if (timer1.Enabled == true)
            {


                foreach (var item in _numbers)
                {
                    if (item.Key == trueBox.Name)
                    {
                        return item.Value == trueBox.Value;
                    }
                }



            }

            return false;


        }

        private void true_Answer(object sender, EventArgs e)
        {
            NumericUpDown trueBox = sender as NumericUpDown;

            if (CheckAAnswer(trueBox))
            {
                trueBox.ForeColor = Color.Green;
                SoundPlayer simpleSound = new SoundPlayer("media\\Windows Unlock.wav");
                if (simpleSound != null)
                {
                    simpleSound.Play();
                }
            }
            else
            {
                trueBox.ForeColor = default;
            }




        }
    }

}
