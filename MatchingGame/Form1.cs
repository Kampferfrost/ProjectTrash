using System.Reflection.Metadata.Ecma335;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        ///<summary>
        /// Assign each icon from the list of icons to a random square
        ///</summary>
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        /// <summary>
        /// Every label's Click event is handled by this event handler
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
            }
        }

        Label? firstClicked = null;
        Label? secondClicked = null;

    }
}
