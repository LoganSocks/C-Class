using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
//I had to use this to update and pull from the leaderboard text file
using System.IO;
// I used this to make the leaderbaord text file get oepneed with whatever app is set to the users defualt
using System.Diagnostics;

namespace AnimeQuizApp
{
    public partial class frmGameplayScreen : Form
    {
        //Create a variable for the player name
        private string PlayerName;
        //This array will hold the players username to be put onto a leaderbroad
        private string[] Names_For_Scores = new string[10];
        //This one will hold teh scores for each player to go along with their username on the leaderboard
        private int[] Final_Score = new int[10];
        //This variavle will keep track of the length of the leaderboard
        private int Leaderboard_Length = 0;
        //This int will be the score
        private int Current_Score = 0;
        //This will be the text file the leaderboard will live in
        private string filepath = "leaderboard.txt";

        private Dictionary<Image, String> AnimeCharacters;
        //This will keep track of which character they are currently on in the eictionary
        private int CurrentCharacterIndex = 0;
        //Get the username from the welcome screen
        public frmGameplayScreen(string incomingName)
        {
            InitializeComponent();
            //Call this so the leaderboard doesnt get erased every game
            Load_Leaderboard();
            //turn the recieved variable from the welcome screen into the player name variable that was created
            this.PlayerName = incomingName;
            //Initialize the dictionary so it is not null
            AnimeCharacters = new Dictionary<Image, String>();
            //Function to pull character into image holder
            GetCharacters();
            //create a max Score variablke and use the GetMaxScore function to get the value
            int MaxScore = GetMaxScore();
            //Update the label to display the max score to the user
            Max_Score_Lbl.Text = $"Max score is {MaxScore} points!";

            //Start a round of the quiz
            StartNewRound();
            //Make the progress bar maximum equal to the amount of characters in the dictionary
            ProgressBar.Maximum = AnimeCharacters.Count;
            //Call the update score function
            UpdateScore();
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
                //Add the users data to the leaderboard
                Update_Leaderboard();
                //Call this to display a small messagebox of the leaderboard
                Display_Leaderboard();
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //Get the answer and convert it to all caps and get rid of extra spaces so correct answers will be correct
            string Answer = UserInput.Text.ToUpper().Trim();
            ValidateAnswer(Answer);
        }
        //This function will update the score label each time the score is changed
        private void UpdateScore()
        {
            //The $ acts like an f-string in python so I can put the variable directly into the text libe
            scoreLabel.Text = $"{PlayerName} your current score is {Current_Score}!";
        }
        //Function to get the max available score
        private int GetMaxScore()
        {   //Create an int to hold the maximum score number
            int total = 0;
            //Use a for loop to iterate through each available character in the dictionary
            for (int i = 0; i < AnimeCharacters.Count; i++)
            {   //For every character in the dictionary add 10 to the int created to hold the maximum score
                total += 10;
            }
            //Return the maximum score available as the total variable
            return total;
        }

        private void ValidateAnswer(string answer)
        {   //Try blokc to raise an exception
            try
            {   //Check if the characters dictionary is empty
                if (AnimeCharacters.Count == 0)
                    //If it is empty throw the new exception
                    throw new InvalidOperationException("No Characters Remaining!");

                var currentCharacter = AnimeCharacters.ElementAt(CurrentCharacterIndex);
                string CorrectAnswer = currentCharacter.Value;

                if (answer == CorrectAnswer)
                {
                    //increase score if it was correct
                    Current_Score += 10;
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
            }//Catch the exception
            catch (InvalidOperationException)
            {   //Display the error message to the users
                MessageBox.Show("No Characters Remaining.");
            }
        }


        private void SkipButton_Click(object sender, EventArgs e)
        {
            //Take away points if they skip a question
            Current_Score -= 5;
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
            Current_Score -= 2;
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

        //This function will add the users scores to the leaderboard
        private void Update_Leaderboard()
        {   //Usse try to give us an error message if an error occurs
            try
            {   //Check if the leaderboard is smaller than the number of users that played
                if (Leaderboard_Length < Names_For_Scores.Length)
                {   //Set the name the user input as the name to be put into the leaderboard
                    Names_For_Scores[Leaderboard_Length] = PlayerName;
                    //Get the users score to add to the leaderboard
                    Final_Score[Leaderboard_Length] = Current_Score;
                    //Increase the leaderboard index
                    Leaderboard_Length++;
                    //this will temporarily hold the data before it gets sent to the text file
                    //It creates a list because it is not fixed in size liek the arrays
                    List<string> toSave = new List<string>();
                    //This loop will write the names and scores to the text file
                    for (int i = 0; i < Leaderboard_Length; i++)
                    {   //Add extra text so the leaderboard is easier to read
                        toSave.Add($"{Names_For_Scores[i]}, {Final_Score[i]}");
                    }//Add all of the new text to the text file
                    File.WriteAllLines(filepath, toSave);
                }


            }//Catch if an error occurs
            catch (Exception ex)
            {   //Display an error message to the user
                MessageBox.Show("Error Updating Leaderboard: " + ex.Message);
            }
        }
        //This will display a mini leaderboard to the user after completing the game
        private void Display_Leaderboard()
        {   //This will be the header of the opo-up
            string output = "******** Previous Scores ******** \n";
            //This loop does the same as the Update leaderboards loop but instead of adding the data to a fgile it is displayed ina message box to the user
            for (int i = 0; i < Leaderboard_Length; i++)
            {   //Add the text that includes the score and name to the messagebox
                output += $"{Names_For_Scores[i]} had {Final_Score[i]} points! \n";
            }//Display the message box to the user
            MessageBox.Show(output, "Leaderboard");
        }
        //This function will ensure the leaderboard is not overwritten at the start of every round
        private void Load_Leaderboard()
        {   //Check if the leaderboard file exists
            if (File.Exists(filepath))
            {   //If it exists try 
                try
                {   // This will open the text file and read all of the lines in it
                    string[] lines = File.ReadAllLines(filepath);
                    //This for loop will first figure how many lines are in the file so it doesnt have to read emopty lines
                    //And it also sets the maximum number of lines to read at which is the size of our array
                    for (int i = 0; i < lines.Length && i < Names_For_Scores.Length; i++)
                    {   //This will split the lines of the text file at the comma
                        string[] parts = lines[i].Split(",");
                        //Checks if there are two parts now that it is split, the two parts being the name and score
                        if (parts.Length == 2)
                        {   //This saves the first part into the leaderboard again
                            Names_For_Scores[i] = parts[0];
                            //This does the same as above but for the score, It changes the score from a string into an integer with int.parse
                            Final_Score[i] = int.Parse(parts[1]);
                            //Increase the leaderboard 
                            Leaderboard_Length++;
                        }
                    }
                }//If an error occurs it will run this catch
                catch (Exception ex)
                {   //Adn display the error message to the user
                    MessageBox.Show("Error Loading Leaderboard: " + ex.Message);
                }
            }
        }

        private void XBox_Click(object sender, EventArgs e)
        {

        }

        private void frmGameplayScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   //try to open the file
            try
            {   //Check if the leaderboard file exists
                if (File.Exists(filepath))
                {   //This will tell the computer to open the text file with whataver app the user has set to their default
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filepath) { UseShellExecute = true });
                }//This will display if the leaderboard does not exist uyet
                else
                {   //Display theno leaderboard message
                    MessageBox.Show("No Leaderboard Yet.");
                }
            }//If an error occurs 
            catch (Exception ex)
            {   //Dsiplay the error message to the user
                MessageBox.Show("Error while trying to open the file: " + ex.Message);
            }
        }
    }
}
