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
            LevelBar = new ProgressBar();
            SkipButton = new Button();
            CheckBox = new PictureBox();
            XBox = new PictureBox();
            ShowNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)CharacterImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CheckBox).BeginInit();
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
            SubmitButton.Click += button1_Click;
            // 
            // UserInput
            // 
            UserInput.BackColor = SystemColors.WindowFrame;
            UserInput.Location = new Point(167, 459);
            UserInput.Name = "UserInput";
            UserInput.Size = new Size(246, 23);
            UserInput.TabIndex = 2;
            // 
            // LevelBar
            // 
            LevelBar.Location = new Point(167, 168);
            LevelBar.Name = "LevelBar";
            LevelBar.Size = new Size(246, 23);
            LevelBar.TabIndex = 3;
            // 
            // SkipButton
            // 
            SkipButton.Location = new Point(419, 459);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new Size(75, 23);
            SkipButton.TabIndex = 4;
            SkipButton.Text = "Skip";
            SkipButton.UseVisualStyleBackColor = true;
            // 
            // CheckBox
            // 
            CheckBox.BackColor = Color.LightSteelBlue;
            CheckBox.Location = new Point(241, 123);
            CheckBox.Name = "CheckBox";
            CheckBox.Size = new Size(43, 40);
            CheckBox.TabIndex = 5;
            CheckBox.TabStop = false;
            // 
            // XBox
            // 
            XBox.BackColor = Color.LightSteelBlue;
            XBox.Location = new Point(299, 123);
            XBox.Name = "XBox";
            XBox.Size = new Size(42, 41);
            XBox.TabIndex = 6;
            XBox.TabStop = false;
            // 
            // ShowNameLabel
            // 
            ShowNameLabel.AutoSize = true;
            ShowNameLabel.Location = new Point(167, 426);
            ShowNameLabel.Name = "ShowNameLabel";
            ShowNameLabel.Size = new Size(71, 15);
            ShowNameLabel.TabIndex = 7;
            ShowNameLabel.Text = "Show Name";
            // 
            // frmGameplayScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 713);
            Controls.Add(ShowNameLabel);
            Controls.Add(XBox);
            Controls.Add(CheckBox);
            Controls.Add(SkipButton);
            Controls.Add(LevelBar);
            Controls.Add(UserInput);
            Controls.Add(SubmitButton);
            Controls.Add(CharacterImage);
            Name = "frmGameplayScreen";
            Text = "Guess the Character";
            ((System.ComponentModel.ISupportInitialize)CharacterImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)CheckBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)XBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox CharacterImage;
        private Button SubmitButton;
        private TextBox UserInput;
        private ProgressBar LevelBar;
        private Button SkipButton;
        private PictureBox CheckBox;
        private PictureBox XBox;
        private Label ShowNameLabel;
    }
}
