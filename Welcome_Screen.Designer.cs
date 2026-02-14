namespace AnimeQuizApp
{
    partial class Welcome_Screen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Start_Button = new Button();
            label1 = new Label();
            Username_TB = new TextBox();
            SuspendLayout();
            // 
            // Start_Button
            // 
            Start_Button.FlatStyle = FlatStyle.Popup;
            Start_Button.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Start_Button.Location = new Point(309, 300);
            Start_Button.Name = "Start_Button";
            Start_Button.Size = new Size(167, 49);
            Start_Button.TabIndex = 0;
            Start_Button.Text = "Start Game";
            Start_Button.UseVisualStyleBackColor = true;
            Start_Button.Click += Start_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(260, 74);
            label1.Name = "label1";
            label1.Size = new Size(268, 28);
            label1.TabIndex = 1;
            label1.Text = "Anime Character Quiz";
            // 
            // Username_TB
            // 
            Username_TB.Location = new Point(309, 257);
            Username_TB.Name = "Username_TB";
            Username_TB.PlaceholderText = "Username";
            Username_TB.Size = new Size(167, 23);
            Username_TB.TabIndex = 2;
            Username_TB.TextChanged += Username_TB_TextChanged;
            // 
            // Welcome_Screen
            // 
            AcceptButton = Start_Button;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Welcome_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(Username_TB);
            Controls.Add(label1);
            Controls.Add(Start_Button);
            DoubleBuffered = true;
            Name = "Welcome_Screen";
            Text = "Welcome_Screen";
            Load += Welcome_Screen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Start_Button;
        private Label label1;
        private TextBox Username_TB;
    }
}