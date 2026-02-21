using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnimeQuizApp
{
    public partial class Welcome_Screen : Form
    {

        private string Settings_Filepath = "User_Settings.txt";
        public Welcome_Screen() { 
            InitializeComponent();
            //Start with the star game button disabed until a username is input
            Start_Button.Enabled = false;
            //Call the load user function to get the username
            Load_User();
        }
        //Create a functino to get the username that was last used so the user is remembered
        private void Load_User()
        {   //Use to try to catch any errors and keeo the app running
            try
            {   //Check iof the file holding the username exists
                if (File.Exists(Settings_Filepath))
                {   //If it exists save the text on the file into a new variable that we can use
                    string SavedName = File.ReadAllText(Settings_Filepath);
                    //Put the name we got from the text file into the user input spot
                    Username_TB.Text = SavedName;
                    //Check if the user input has text in it ---- the ! means opposite basically or if not
                    if (!string.IsNullOrWhiteSpace(Username_TB.Text))
                    {   //enable the start button if there is text in the user input spot
                        Start_Button.Enabled = true;
                    }
                }
            }//catch if there was a problem loading the username
            catch (Exception ex)
            {   //Display the eroor message to the user
                MessageBox.Show("Couldn't load username: " + ex.Message);
            }
        }
        //Function to check for a username
        private void Check_Name()
        {
            //Creata a try block to raise an exception
            try
            {   //check ifg the username textbox is blank
                if (string.IsNullOrWhiteSpace(Username_TB.Text))
                {   //If it is blank raise the exception
                    throw new ArgumentException("Username Cannot Be Blank!");
                }
                //If there is a name in the box write it to the file that holds the username
                File.WriteAllText(Settings_Filepath, Username_TB.Text);
                //Create a new instance of the gameplay screen with the username passed through
                frmGameplayScreen game = new frmGameplayScreen(Username_TB.Text);
                //Show the gameplay screen
                game.Show();
                //Hide the welcome screen
                this.Hide();
            }//catch if an eroor when checking fior a username
            catch (ArgumentException ex)
            {   //Display the error message to the user
                MessageBox.Show(ex.Message, "Warning");
            }
        }
        private void Start_Button_Click(object sender, EventArgs e)
        {   //Call the check name function to check for ausername and transition to the gameplay screen
            Check_Name();
        }
        //Enable the start game button
        private void Username_TB_TextChanged(object sender, EventArgs e)
        {   //Only enable it if there is text in the username textbox
            Start_Button.Enabled = Username_TB.Text.Trim().Length > 0;
        }

        private void Welcome_Screen_Load(object sender, EventArgs e)
        {

        }
    }
}

