using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace AnimeQuizApp
{
    public partial class frmGameplayScreen : Form
    {
        private Dictionary<Image, String> AnimeCharacters;
        //This will keep track of which character they are currently on in the eictionary
        private int CurrentCharacterIndex = 0;
        public frmGameplayScreen()
        {
            InitializeComponent();
            //Initialize the dictionary so it is not null
            AnimeCharacters = new Dictionary<Image, String>();
            //Function to pull character into image holder
            GetCharacters();

            //Start a round of the quiz
            StartNewRound();
            //Make the progress bar maximum equal to the amount of characters in the dictionary
            ProgressBar.Maximum = AnimeCharacters.Count;


        }

        private void GetCharacters()
        {
            //Pull the character Image and add it to the dictionary along wit the name
            AnimeCharacters.Add(Properties.Resources.Monkey_D_Luffy, "LUFFY");
            AnimeCharacters.Add(Properties.Resources.Goku, "GOKU");
        }

        private void StartNewRound()
        {
            //Check if progress bar is full to display Game finished image
            if (ProgressBar.Value == ProgressBar.Maximum)
            {
                CharacterImage.Image = (Properties.Resources.Congrats);
            }
            //This checks if the dictionary has anything inside
            if (AnimeCharacters.Count > 0)
            {
                //Create a local variabel for the character we are currently on
                var character = AnimeCharacters.ElementAt(CurrentCharacterIndex);

                //Pull the current characters image to use
                CharacterImage.Image = character.Key;
                //Make it so the image doesnt distort
                CharacterImage.SizeMode = PictureBoxSizeMode.Zoom;
                //Clear the users input so they can type new answer
                UserInput.Clear();
            }
           //Placeholder image to swap back to becayse i couldnt get the image to disappear
            XBox.Image = (Properties.Resources.white_box);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Make the local variablke fior the current character again
            var character = AnimeCharacters.ElementAt(CurrentCharacterIndex);
            //Create a string to hold the users answer & Change it to uppercase so there are no casing issues with the answer & get rid of extra spaces
            string Answer = UserInput.Text.ToUpper().Trim();
            //Make a string for the correct name & I typed it in uppercase so I dont need to upper it here
            string correctAnswer = character.Value;

            //Compare the user inoput to the cprrect answer
            if (Answer == correctAnswer)
            {
                //Change the label to say correct
                CorrectLabel.Text = "Correct!!";
                //Get the current key to remove it from the dictionary so correct answers do not show back up
                Image CurrentKey = AnimeCharacters.Keys.ElementAt(CurrentCharacterIndex);
                //Use the local variable made to store the image to remove it from the dictonary
                AnimeCharacters.Remove(CurrentKey);
                //If the answer is correct increase the progress bar
                if (ProgressBar.Value < ProgressBar.Maximum)
                {
                    ProgressBar.Value++;
                }
                //If the index is to big for the dictionary chnage it back to 0
                if (CurrentCharacterIndex >= AnimeCharacters.Count)
                {
                    CurrentCharacterIndex = 0;

                }
                //If correct take the user ot the next character
                StartNewRound();

            }
            else
            {
                //Add X Image
                XBox.Image = (Properties.Resources.Redx);
                //Make X image fit 
                XBox.SizeMode = PictureBoxSizeMode.Zoom;
                //Make the label say wrong
                CorrectLabel.Text = "Wrong Answer! Try Again!";
            }


            }
        


        

        private void SkipButton_Click(object sender, EventArgs e)
        {
            //When the button is clicked go to the next character in the dictionary 
            CurrentCharacterIndex++;
            //If no more characters left go back to the first one
            if (CurrentCharacterIndex >= AnimeCharacters.Count)
            {
                CurrentCharacterIndex = 0;
            }
            //Run start new round to show the next character
            StartNewRound();
        }


    }
}
