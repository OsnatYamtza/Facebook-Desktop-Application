namespace BasicFacebookFeatures
{
    partial class TriviaFriendsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TriviaFriendsForm));
            this.pictureBoxTriviaLogo = new System.Windows.Forms.PictureBox();
            this.labelChooseFriend = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.labelDescriptionQuestion = new System.Windows.Forms.Label();
            this.radioButtonFirstAnswer = new System.Windows.Forms.RadioButton();
            this.radioButtonSecondAnswer = new System.Windows.Forms.RadioButton();
            this.radioButtonThirdAnswer = new System.Windows.Forms.RadioButton();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.pictureBoxNextQuestion = new System.Windows.Forms.PictureBox();
            this.labelFeedback = new System.Windows.Forms.Label();
            this.listBoxFriend = new System.Windows.Forms.ListBox();
            this.checkBoxChangeFriend = new System.Windows.Forms.CheckBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.labelinstructionsDescriptionFirstSection = new System.Windows.Forms.Label();
            this.labelinstructionsDescriptionSecondSection = new System.Windows.Forms.Label();
            this.labelInstructionSecondDescription = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTriviaLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNextQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxTriviaLogo
            // 
            this.pictureBoxTriviaLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTriviaLogo.Image")));
            this.pictureBoxTriviaLogo.Location = new System.Drawing.Point(259, 10);
            this.pictureBoxTriviaLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxTriviaLogo.Name = "pictureBoxTriviaLogo";
            this.pictureBoxTriviaLogo.Size = new System.Drawing.Size(343, 70);
            this.pictureBoxTriviaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTriviaLogo.TabIndex = 0;
            this.pictureBoxTriviaLogo.TabStop = false;
            // 
            // labelChooseFriend
            // 
            this.labelChooseFriend.AutoSize = true;
            this.labelChooseFriend.Font = new System.Drawing.Font("Aharoni", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelChooseFriend.ForeColor = System.Drawing.Color.Purple;
            this.labelChooseFriend.Location = new System.Drawing.Point(35, 125);
            this.labelChooseFriend.Name = "labelChooseFriend";
            this.labelChooseFriend.Size = new System.Drawing.Size(171, 24);
            this.labelChooseFriend.TabIndex = 1;
            this.labelChooseFriend.Text = "Choose Friend";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Aharoni", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelQuestion.ForeColor = System.Drawing.Color.Purple;
            this.labelQuestion.Location = new System.Drawing.Point(310, 125);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(112, 24);
            this.labelQuestion.TabIndex = 4;
            this.labelQuestion.Text = "Question";
            // 
            // labelDescriptionQuestion
            // 
            this.labelDescriptionQuestion.AutoSize = true;
            this.labelDescriptionQuestion.Location = new System.Drawing.Point(311, 156);
            this.labelDescriptionQuestion.Name = "labelDescriptionQuestion";
            this.labelDescriptionQuestion.Size = new System.Drawing.Size(46, 17);
            this.labelDescriptionQuestion.TabIndex = 5;
            this.labelDescriptionQuestion.Text = "label1";
            this.labelDescriptionQuestion.Visible = false;
            // 
            // radioButtonFirstAnswer
            // 
            this.radioButtonFirstAnswer.AutoSize = true;
            this.radioButtonFirstAnswer.Location = new System.Drawing.Point(315, 199);
            this.radioButtonFirstAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonFirstAnswer.Name = "radioButtonFirstAnswer";
            this.radioButtonFirstAnswer.Size = new System.Drawing.Size(17, 16);
            this.radioButtonFirstAnswer.TabIndex = 6;
            this.radioButtonFirstAnswer.TabStop = true;
            this.radioButtonFirstAnswer.UseVisualStyleBackColor = true;
            // 
            // radioButtonSecondAnswer
            // 
            this.radioButtonSecondAnswer.AutoSize = true;
            this.radioButtonSecondAnswer.Location = new System.Drawing.Point(315, 249);
            this.radioButtonSecondAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonSecondAnswer.Name = "radioButtonSecondAnswer";
            this.radioButtonSecondAnswer.Size = new System.Drawing.Size(17, 16);
            this.radioButtonSecondAnswer.TabIndex = 7;
            this.radioButtonSecondAnswer.TabStop = true;
            this.radioButtonSecondAnswer.UseVisualStyleBackColor = true;
            // 
            // radioButtonThirdAnswer
            // 
            this.radioButtonThirdAnswer.AutoSize = true;
            this.radioButtonThirdAnswer.Location = new System.Drawing.Point(315, 291);
            this.radioButtonThirdAnswer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonThirdAnswer.Name = "radioButtonThirdAnswer";
            this.radioButtonThirdAnswer.Size = new System.Drawing.Size(17, 16);
            this.radioButtonThirdAnswer.TabIndex = 8;
            this.radioButtonThirdAnswer.TabStop = true;
            this.radioButtonThirdAnswer.UseVisualStyleBackColor = true;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Enabled = false;
            this.buttonSubmit.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonSubmit.Location = new System.Drawing.Point(315, 338);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(99, 34);
            this.buttonSubmit.TabIndex = 9;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.checkIfTheAnswerIsCorrect);
            // 
            // pictureBoxNextQuestion
            // 
            this.pictureBoxNextQuestion.Enabled = false;
            this.pictureBoxNextQuestion.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNextQuestion.Image")));
            this.pictureBoxNextQuestion.Location = new System.Drawing.Point(543, 299);
            this.pictureBoxNextQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxNextQuestion.Name = "pictureBoxNextQuestion";
            this.pictureBoxNextQuestion.Size = new System.Drawing.Size(348, 189);
            this.pictureBoxNextQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNextQuestion.TabIndex = 10;
            this.pictureBoxNextQuestion.TabStop = false;
            this.pictureBoxNextQuestion.Visible = false;
            this.pictureBoxNextQuestion.Click += new System.EventHandler(this.pictureBoxNextQuestion_Click);
            // 
            // labelFeedback
            // 
            this.labelFeedback.AutoSize = true;
            this.labelFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFeedback.ForeColor = System.Drawing.Color.Red;
            this.labelFeedback.Location = new System.Drawing.Point(539, 214);
            this.labelFeedback.Name = "labelFeedback";
            this.labelFeedback.Size = new System.Drawing.Size(0, 20);
            this.labelFeedback.TabIndex = 12;
            this.labelFeedback.Visible = false;
            // 
            // listBoxFriend
            // 
            this.listBoxFriend.FormattingEnabled = true;
            this.listBoxFriend.ItemHeight = 16;
            this.listBoxFriend.Location = new System.Drawing.Point(25, 165);
            this.listBoxFriend.Name = "listBoxFriend";
            this.listBoxFriend.Size = new System.Drawing.Size(233, 212);
            this.listBoxFriend.TabIndex = 13;
            this.listBoxFriend.Click += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // checkBoxChangeFriend
            // 
            this.checkBoxChangeFriend.AutoSize = true;
            this.checkBoxChangeFriend.Enabled = false;
            this.checkBoxChangeFriend.Location = new System.Drawing.Point(25, 382);
            this.checkBoxChangeFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxChangeFriend.Name = "checkBoxChangeFriend";
            this.checkBoxChangeFriend.Size = new System.Drawing.Size(188, 21);
            this.checkBoxChangeFriend.TabIndex = 14;
            this.checkBoxChangeFriend.Text = "Change to another friend";
            this.checkBoxChangeFriend.UseVisualStyleBackColor = true;
            this.checkBoxChangeFriend.CheckedChanged += new System.EventHandler(this.checkBoxChangeFriend_CheckedChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Indigo;
            this.buttonBack.Font = new System.Drawing.Font("Aharoni", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBack.Location = new System.Drawing.Point(778, 10);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(106, 54);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructions.ForeColor = System.Drawing.Color.GhostWhite;
            this.labelInstructions.Location = new System.Drawing.Point(644, 66);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(127, 24);
            this.labelInstructions.TabIndex = 16;
            this.labelInstructions.Text = "Instructions:";
            // 
            // labelinstructionsDescriptionFirstSection
            // 
            this.labelinstructionsDescriptionFirstSection.AutoSize = true;
            this.labelinstructionsDescriptionFirstSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelinstructionsDescriptionFirstSection.ForeColor = System.Drawing.Color.Green;
            this.labelinstructionsDescriptionFirstSection.Location = new System.Drawing.Point(466, 86);
            this.labelinstructionsDescriptionFirstSection.Name = "labelinstructionsDescriptionFirstSection";
            this.labelinstructionsDescriptionFirstSection.Size = new System.Drawing.Size(453, 20);
            this.labelinstructionsDescriptionFirstSection.TabIndex = 17;
            this.labelinstructionsDescriptionFirstSection.Text = "Choose a friend and click submit after each question";
            // 
            // labelinstructionsDescriptionSecondSection
            // 
            this.labelinstructionsDescriptionSecondSection.AutoSize = true;
            this.labelinstructionsDescriptionSecondSection.Location = new System.Drawing.Point(644, 155);
            this.labelinstructionsDescriptionSecondSection.Name = "labelinstructionsDescriptionSecondSection";
            this.labelinstructionsDescriptionSecondSection.Size = new System.Drawing.Size(0, 17);
            this.labelinstructionsDescriptionSecondSection.TabIndex = 18;
            // 
            // labelInstructionSecondDescription
            // 
            this.labelInstructionSecondDescription.AutoSize = true;
            this.labelInstructionSecondDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelInstructionSecondDescription.ForeColor = System.Drawing.Color.Green;
            this.labelInstructionSecondDescription.Location = new System.Drawing.Point(601, 106);
            this.labelInstructionSecondDescription.Name = "labelInstructionSecondDescription";
            this.labelInstructionSecondDescription.Size = new System.Drawing.Size(261, 20);
            this.labelInstructionSecondDescription.TabIndex = 19;
            this.labelInstructionSecondDescription.Text = "click next to the next question";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.labelMessage.Location = new System.Drawing.Point(55, 449);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(94, 24);
            this.labelMessage.TabIndex = 20;
            this.labelMessage.Text = "message";
            // 
            // TriviaFriendsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1006, 522);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelInstructionSecondDescription);
            this.Controls.Add(this.labelinstructionsDescriptionSecondSection);
            this.Controls.Add(this.labelinstructionsDescriptionFirstSection);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.checkBoxChangeFriend);
            this.Controls.Add(this.listBoxFriend);
            this.Controls.Add(this.labelFeedback);
            this.Controls.Add(this.pictureBoxNextQuestion);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.radioButtonThirdAnswer);
            this.Controls.Add(this.radioButtonSecondAnswer);
            this.Controls.Add(this.radioButtonFirstAnswer);
            this.Controls.Add(this.labelDescriptionQuestion);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.labelChooseFriend);
            this.Controls.Add(this.pictureBoxTriviaLogo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TriviaFriendsForm";
            this.Text = "Trivia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.triviaFriendsForm_Close);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTriviaLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNextQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxTriviaLogo;
        private System.Windows.Forms.Label labelChooseFriend;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Label labelDescriptionQuestion;
        private System.Windows.Forms.RadioButton radioButtonFirstAnswer;
        private System.Windows.Forms.RadioButton radioButtonSecondAnswer;
        private System.Windows.Forms.RadioButton radioButtonThirdAnswer;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.PictureBox pictureBoxNextQuestion;
        private System.Windows.Forms.Label labelFeedback;
        private System.Windows.Forms.ListBox listBoxFriend;
        private System.Windows.Forms.CheckBox checkBoxChangeFriend;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Label labelinstructionsDescriptionFirstSection;
        private System.Windows.Forms.Label labelinstructionsDescriptionSecondSection;
        private System.Windows.Forms.Label labelInstructionSecondDescription;
        private System.Windows.Forms.Label labelMessage;
    }
}