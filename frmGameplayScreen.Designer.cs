namespace AnimeQuizApp
{
    partial class frmGameplayScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CharacterImage = new PictureBox();
            SubmitButton = new Button();
            UserInput = new TextBox();
            ProgressBar = new ProgressBar();
            SkipButton = new Button();
            XBox = new PictureBox();
            CorrectLabel = new Label();
            hintButton = new Button();
            scoreLabel = new Label();
            Max_Score_Lbl = new Label();
            Leaderboard_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)CharacterImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XBox).BeginInit();
            SuspendLayout();
            // 
            // CharacterImage
            // 
            CharacterImage.BackColor = Color.LightSteelBlue;
            CharacterImage.Location = new Point(167, 198);
            CharacterImage.Name = "CharacterImage";
            CharacterImage.Size = new Size(246, 225);
            CharacterImage.TabIndex = 0;
            CharacterImage.TabStop = false;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(252, 508);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(75, 23);
            SubmitButton.TabIndex = 1;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // UserInput
            // 
            UserInput.BackColor = SystemColors.ButtonHighlight;
            UserInput.Location = new Point(167, 459);
            UserInput.Name = "UserInput";
            UserInput.PlaceholderText = "Who's That Character?";
            UserInput.Size = new Size(246, 23);
            UserInput.TabIndex = 2;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(167, 168);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(246, 23);
            ProgressBar.TabIndex = 3;
            // 
            // SkipButton
            // 
            SkipButton.Location = new Point(419, 459);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new Size(75, 23);
            SkipButton.TabIndex = 4;
            SkipButton.Text = "Next";
            SkipButton.UseVisualStyleBackColor = true;
            SkipButton.Click += SkipButton_Click;
            // 
            // XBox
            // 
            XBox.BackColor = Color.LightSteelBlue;
            XBox.Location = new Point(266, 121);
            XBox.Name = "XBox";
            XBox.Size = new Size(42, 41);
            XBox.TabIndex = 6;
            XBox.TabStop = false;
            XBox.Click += XBox_Click;
            // 
            // CorrectLabel
            // 
            CorrectLabel.AutoSize = true;
            CorrectLabel.Location = new Point(167, 426);
            CorrectLabel.Name = "CorrectLabel";
            CorrectLabel.Size = new Size(0, 15);
            CorrectLabel.TabIndex = 7;
            // 
            // hintButton
            // 
            hintButton.Location = new Point(419, 430);
            hintButton.Name = "hintButton";
            hintButton.Size = new Size(76, 23);
            hintButton.TabIndex = 8;
            hintButton.Text = "Need Help?";
            hintButton.UseVisualStyleBackColor = true;
            hintButton.Click += hintButton_Click;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(340, 147);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(0, 15);
            scoreLabel.TabIndex = 9;
            // 
            // Max_Score_Lbl
            // 
            Max_Score_Lbl.AutoSize = true;
            Max_Score_Lbl.Location = new Point(227, 101);
            Max_Score_Lbl.Name = "Max_Score_Lbl";
            Max_Score_Lbl.Size = new Size(0, 15);
            Max_Score_Lbl.TabIndex = 10;
            // 
            // Leaderboard_Button
            // 
            Leaderboard_Button.Location = new Point(420, 401);
            Leaderboard_Button.Name = "Leaderboard_Button";
            Leaderboard_Button.Size = new Size(83, 23);
            Leaderboard_Button.TabIndex = 11;
            Leaderboard_Button.Text = "Leaderboard";
            Leaderboard_Button.UseVisualStyleBackColor = true;
            Leaderboard_Button.Click += button1_Click;
            // 
            // frmGameplayScreen
            // 
            AcceptButton = SubmitButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 713);
            Controls.Add(Leaderboard_Button);
            Controls.Add(Max_Score_Lbl);
            Controls.Add(scoreLabel);
            Controls.Add(hintButton);
            Controls.Add(CorrectLabel);
            Controls.Add(XBox);
            Controls.Add(SkipButton);
            Controls.Add(ProgressBar);
            Controls.Add(UserInput);
            Controls.Add(SubmitButton);
            Controls.Add(CharacterImage);
            Name = "frmGameplayScreen";
            Text = "Guess the Character";
            Load += frmGameplayScreen_Load;
            ((System.ComponentModel.ISupportInitialize)CharacterImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)XBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CharacterImage;
        private Button SubmitButton;
        private TextBox UserInput;
        private ProgressBar ProgressBar;
        private Button SkipButton;
        private PictureBox XBox;
        private Label CorrectLabel;
        private Button hintButton;
        private Label scoreLabel;
        private Label Max_Score_Lbl;
        private Button Leaderboard_Button;
    }
}
