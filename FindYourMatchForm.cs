using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLogic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FindYourMatchForm : Form
    {
        private string m_City;
        private string m_Gender;
        private string m_Age;
        private FictionUsers m_PotentialMatch;
        internal ApplicationManagerFacade ApplicationManagerFacade;
        internal DisplayFeedbackMessageVisitor DisplayFeedbackMessageVisitor { get; set; }

        /**
         * In case we can get the user's friends via facebook
         */
        ////private readonly User r_LoggedInUser;
        ////private User m_PotentionalMatchUser;

        public FindYourMatchForm()
        {
            InitializeComponent();
            ApplicationManagerFacade = ApplicationManagerFacade.Instance;
            ////r_LoggedInUser = ApplicationManagerFacade.LoggedInUser;
            DisplayFeedbackMessageVisitor = new DisplayFeedbackMessageVisitor(ApplicationManagerFacade.GetListOfFeedbackMessagesToFindYourMatch());
            DisplayFeedbackMessageVisitor.LabelMessageToDisplay = labelMessage;
        }

        private void buttonCheckAnswers_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                bool isMatchExist;

                if (checkedListBoxGender.CheckedItems.Count != 0 &&
                   checkedListBoxAge.CheckedItems.Count != 0 &&
                   !textBoxCity.Text.Equals(string.Empty))
                {
                    isMatchExist = ApplicationManagerFacade.CheckIfThereIsMatch(m_Gender, m_Age, m_City);
                    if (isMatchExist)
                    {
                        m_PotentialMatch = ApplicationManagerFacade.GetPotentionalMatch();
                        MessageBox.Show("Your Potentional Match Is:" + Environment.NewLine +
                                        $"Name: {m_PotentialMatch.Name}" + Environment.NewLine +
                                        $"Age: {m_PotentialMatch.Age}" + Environment.NewLine +
                                        $"Gender: {m_PotentialMatch.Gender}" + Environment.NewLine +
                                        $"City: {m_PotentialMatch.City}");

                        /**
                         * In case we can get the user's friends via facebook
                         */
                        ////m_PotentionalMatchUser = ApplicationManagerFacade.GetPotentionalMatchUser();
                        ////int userAge = ApplicationManagerFacade.getUserAge();
                        ////MessageBox.Show("Your Potentional Match Is:" + Environment.NewLine +
                        ////                $"Name: {m_PotentionalMatchUser.Name}" + Environment.NewLine +
                        ////                $"Age: {userAge}" + Environment.NewLine +
                        ////                $"Gender: {m_PotentionalMatchUser.Gender}" + Environment.NewLine +
                        ////                $"City: {m_PotentionalMatchUser.Location}");
                    }
                    else
                    {
                        MessageBox.Show("Sorry, we can't find a match for you");
                    }
                }
                else
                {
                    MessageBox.Show("You should check all the three preferences");
                }
            }));
        }

        private void checkedListBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                m_Gender = (sender as CheckedListBox).SelectedItem.ToString();
                makeTheOtherCheckBoxOptionsEnabled(sender);
            }));
        }

        private void checkedListBoxAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                m_Age = (sender as CheckedListBox).SelectedItem.ToString();
                makeTheOtherCheckBoxOptionsEnabled(sender);
            }));
        }

        private void makeTheOtherCheckBoxOptionsEnabled(object i_Sender)
        {
            int indexOfChosenCheckBox;
            int countCheckBox;
            CheckedListBox currentCheckedListBox = i_Sender as CheckedListBox;

            if (currentCheckedListBox != null)
            {
                indexOfChosenCheckBox = currentCheckedListBox.SelectedIndex;
                countCheckBox = currentCheckedListBox.Items.Count;
                for (int i = 0; i < countCheckBox; i++)
                {
                    if (indexOfChosenCheckBox != i)
                    {
                        currentCheckedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            backToMainForm(); 
        }

        private void backToMainForm()
        {
            DisplayFeedbackMessageVisitor.back(this);
        }

        private void textBoxCity_Validating(object sender, CancelEventArgs e)
        {
            string patternContainsLattersAndSpaces = "^[A-Za-z ]+$";
            string patternContainsSpaces = "^[ ]+$";
            Regex regexForLattersAndSpaces = new Regex(patternContainsLattersAndSpaces);
            Regex regexForSpaces = new Regex(patternContainsSpaces);

            if (regexForSpaces.IsMatch(textBoxCity.Text))
            {
                MessageBox.Show("You should enter only characters");
            }
            if (!regexForLattersAndSpaces.IsMatch(textBoxCity.Text))
            {
                MessageBox.Show("Please enter valid letters !");
                e.Cancel = true;
            }
            else
            {
                m_City = textBoxCity.Text;
            }
        }

        private void findYourMatchForm_Close(object sender, FormClosedEventArgs e)
        {
            backToMainForm();
        }
    }
}