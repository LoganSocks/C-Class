using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace AnimeQuizApp
{
    public partial class frmGameplayScreen : Form
    {
        //This int will be the score
        private int currentScore = 0;

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
            AnimeCharacters.Add(Properties.Resources.Jotaro_1, "JOTARO");
            AnimeCharacters.Add(Properties.Resources.naruto, "NARUTO");
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
            //Get the answer and convert it to all caps and get rid of extra spaces so correct answers will be correct
            string Answer = UserInput.Text.ToUpper().Trim();
            ValidateAnswer(Answer);
        }
        //This function will update the score label each time the score is changed
        private void UpdateScore()
        {
            //The $ acts like an f-string in python so I can put the variable directly into the text libe
            scoreLabel.Text = $"Current Score is {currentScore}";
        }

        private void ValidateAnswer(string answer)
        {
            var currentCharacter = AnimeCharacters.ElementAt(CurrentCharacterIndex);
            string CorrectAnswer = currentCharacter.Value;

            if (answer == CorrectAnswer)
            {
                //increase score if it was correct
                currentScore += 10;
                //call the update score function to change the label text
                UpdateScore();
                //Change the label to let them knw it was correct
                CorrectLabel.Text = "Correct!";
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
            //Take away points if they skip a question
            currentScore -= 5;
            //Call the function to update the score label
            UpdateScore();
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

        private void hintButton_Click(object sender, EventArgs e)
        {
            //Minues their score by 2 for usnig a hint
            currentScore -= 2;
            //Call the function to update the score label text
            UpdateScore();
            //create a variable to hold the character we are currently on
            var character = AnimeCharacters.ElementAt(CurrentCharacterIndex);
            //Get the name into a string variable so we can index it and pull it's first letter
            string name = character.Value;
            //display a messagebox to the user with the hint of the characters first letter of their name
            MessageBox.Show($"This character's name starts with the letter '{name[0]}' .");
            //Exit so another character is not pullled
            return;
        }
    }
}
