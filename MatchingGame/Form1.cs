namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> list = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };


        public Form1()
        {
            InitializeComponent();
        }
    }
}
