using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using ApplicationLogic;
using eKeyQuestions = ApplicationLogic.eKeyQuestions;
using FictionUsers = ApplicationLogic.FictionUsers;

namespace BasicFacebookFeatures
{
    public partial class TriviaFriendsForm : Form
    {
        private readonly List<FictionUsers> r_ListOfFictionUsers;
        private readonly List<string> r_TriviaQuestions;
        private int m_IndexOfQuestions = 0;
        private FictionUsers m_ChosenFriend;
        internal ApplicationManagerFacade ApplicationManagerFacade;
        internal DisplayFeedbackMessageVisitor DisplayFeedbackMessageVisitor { get; set; }

        /**
         * In the case we can access the login user's chosen friend via facebook
         * //// private User m_ChosenFriend;
         * //// private readonly User r_LoggedInUser;
         */

        public TriviaFriendsForm()
        {
            InitializeComponent();
            ApplicationManagerFacade = ApplicationManagerFacade.Instance;
            r_TriviaQuestions = ApplicationManagerFacade.GetListOfQuestions();
            r_ListOfFictionUsers = ApplicationManagerFacade.GetListOfFictionUsersToTriviaForm();
            initializeListBoxOfFriends();
            ////r_LoggedInUser = ApplicationManagerFacade.LoggedInUser;
            DisplayFeedbackMessageVisitor = new DisplayFeedbackMessageVisitor(ApplicationManagerFacade.GetListOfFeedbackMessagesToTrivia());
            DisplayFeedbackMessageVisitor.LabelMessageToDisplay = labelMessage;
        }

        private void initializeListBoxOfFriends()
        {
            /**
             * This section is in comment because we cant get user's friends via facebook
             */
            ////listBoxFriend.Items.Clear();
            ////listBoxFriend.DisplayMember = "Name";
            ////FacebookObjectCollection<User> userFriends = r_LoggedInUser.Friends;
            ////foreach (User friend in userFriends)
            ////{
            ////    listBoxFriend.Items.Add(friend);
            ////}

            foreach (var user in r_ListOfFictionUsers)
            {
                listBoxFriend.Items.Add(user.Name);
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                /**
                 * In case we can access the user's friend via facebook
                 */
                ////ApplicationManagerFacade.InitializeChosenFriend(sender as User);
                
                if (listBoxFriend.SelectedItem.ToString() == "Haim Levi")
                {
                    m_ChosenFriend = r_ListOfFictionUsers[0];
                }
                else if (listBoxFriend.SelectedItem.ToString() == "Dor Cohen")
                {
                    m_ChosenFriend = r_ListOfFictionUsers[1];
                }
                else if (listBoxFriend.SelectedItem.ToString() == "Dana Ron")
                {
                    m_ChosenFriend = r_ListOfFictionUsers[2];
                }

                listBoxFriend.Enabled = false;
                ApplicationManagerFacade.InitializeChosenFriend(m_ChosenFriend);
                ApplicationManagerFacade.ResetWrongAndCorrectAnswers();
                displaySelectedFriendQuestions();
                checkBoxChangeFriend.Enabled = true;
                buttonSubmit.Enabled = true;
            }));
        }

        private void displaySelectedFriendQuestions()
        {
            ApplicationManagerFacade.InitializeQuestions(m_ChosenFriend);
            ApplicationManagerFacade.InitializeDictionaryOfQuestionsAndAnswers();
            displayQuestionsAndAnswers();
        }

        private void displayQuestionsAndAnswers()
        {
           new Thread(displayQuestions).Start();
        }

        private void displayQuestions()
        {
            Invoke(new Action(() =>
            {
                ApplicationManagerFacade.GetListOfQuestions();
                pictureBoxNextQuestion.Enabled = false;
                labelDescriptionQuestion.Text = r_TriviaQuestions[m_IndexOfQuestions];
                labelDescriptionQuestion.Show();
                displayAnswers(m_IndexOfQuestions);
                if (m_IndexOfQuestions < 3)
                {
                    m_IndexOfQuestions++;
                }
                if (m_IndexOfQuestions == 3)
                {
                    pictureBoxNextQuestion.Enabled = false;
                }
            }));
        }

        private void pictureBoxNextQuestion_Click(object sender, EventArgs e)
        {
           displayQuestions();
        }
     
        private void displayAnswers(int i_IndexOfCurrentQuestion)
        { 
           List<string> answersToSpecificQuestion = ApplicationManagerFacade.GetListOfAnswers(i_IndexOfCurrentQuestion);
           radioButtonFirstAnswer.Text = answersToSpecificQuestion[0];
           radioButtonSecondAnswer.Text = answersToSpecificQuestion[1];
           radioButtonThirdAnswer.Text = answersToSpecificQuestion[2];
        }

        private void checkIfTheAnswerIsCorrect(object sender, EventArgs e) 
        {
            Invoke(new Action(() =>
            {
                eKeyQuestions currentQuestion = (eKeyQuestions)(m_IndexOfQuestions - 1);
                string chosenAnswer = null;
                bool isCorrectAnswer;

                if (radioButtonFirstAnswer.Checked)
                {
                    chosenAnswer = radioButtonFirstAnswer.Text;
                }
                else if (radioButtonSecondAnswer.Checked)
                {
                    chosenAnswer = radioButtonSecondAnswer.Text;
                }
                else if (radioButtonThirdAnswer.Checked)
                {
                    chosenAnswer = radioButtonThirdAnswer.Text;
                }

                isCorrectAnswer = ApplicationManagerFacade.CheckIfAnswerIsCorrect(currentQuestion, chosenAnswer);
                updateResults((int)currentQuestion, isCorrectAnswer);
                pictureBoxNextQuestion.Visible = true;
                pictureBoxNextQuestion.Enabled = true;
                checkIfItsTheLastQuestion(currentQuestion);
            }));
        }

        private void updateResults(int i_IndexOfQuestion, bool i_IsCorrectAnswer)
        {
            ApplicationManagerFacade.UpdateResults(i_IndexOfQuestion, i_IsCorrectAnswer);
        }

        private void checkIfItsTheLastQuestion(eKeyQuestions i_CurrentQuestion)
        {
            if ((int) i_CurrentQuestion == 2)
            {
                string feedbackToDisplay = ApplicationManagerFacade.GetFeedbackToDisplay();

                pictureBoxNextQuestion.Enabled = false;
                buttonSubmit.Enabled = false;
                labelFeedback.Visible = true;
                ApplicationManagerFacade.AddFeedbackListener();
                ApplicationManagerFacade.NotifyFeedbackListeners(feedbackToDisplay);
                MessageBox.Show(ApplicationManagerFacade.GetFeedbackMessageToDisplay());
            }
        }

        private void checkBoxChangeFriend_CheckedChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelFeedback.Text = string.Empty;
                if (checkBoxChangeFriend.Checked)
                {
                    listBoxFriend.Enabled = true;
                }
                else
                {
                    listBoxFriend.Enabled = false;
                }

                m_IndexOfQuestions = 0;
            }));
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            backToMainForm();
        }

        private void backToMainForm()
        {
            DisplayFeedbackMessageVisitor.back(this);
        }

        private void triviaFriendsForm_Close(object sender, FormClosedEventArgs e)
        {
            backToMainForm();

        }
    }
}