namespace MathQuizApp
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1;
        int addend2;
        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// nad starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
        }


        public Form1()
        {
            InitializeComponent();
        }

    }
    
}
