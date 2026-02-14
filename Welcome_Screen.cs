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
        public Welcome_Screen()
        {
            InitializeComponent();
            //Start with the star game button disabed until a username is input
            Start_Button.Enabled = false;
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
                }//create a new instance of the gamplaye screen and pass the username through
                frmGameplayScreen game = new frmGameplayScreen(Username_TB.Text);
                //show the game screen
                game.Show();
                //Hide the welcome screen
                this.Hide();
            }//catch the exception
            catch (ArgumentException ex)
            {   //Display the username error message
                MessageBox.Show(ex.Message, "Username Cannot Be Blank.");
            }
        }
        //Function to handle when the start game button is click
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

