using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using ApplicationLogic;
using Message = FacebookWrapper.ObjectModel.Message;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private readonly List<FictionUsers> r_ListOfFictionUsers;
        private readonly AppSettings r_AppSettings;
        private FacebookWrapper.LoginResult m_LoginResult;
        internal User LoggedInUser { get; set; }
        internal ApplicationManagerFacade ApplicationManagerFacade;
        private string season;
        private List<FictionUsers> friendsBornedInSelectedSeason = new List<FictionUsers> { };

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
            r_AppSettings = AppSettings.LoadFromFile();
            fetchFormSettings();
            ApplicationManagerFacade = ApplicationManagerFacade.Instance;
            ApplicationManagerFacade.LoggedInUser = LoggedInUser;
            ApplicationManagerFacade.CreateFeatures();
            r_ListOfFictionUsers = ApplicationManagerFacade.GetListOfFictionUsersToMainForm();
        }

        private void fetchFormSettings()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = r_AppSettings.LastWindowLocation;
            this.Size = r_AppSettings.LastWindowSize;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc");
            m_LoginResult = FacebookService.Login(
                "1303346456815400",
                    //// requested permissions:
                    "email",
                    "public_profile",
                    "user_age_range",   
                    "user_birthday",
                    "user_events",
                    "user_friends",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos");           
            LoggedInUser = m_LoginResult.LoggedInUser;
            new Thread(fetchUserInfo).Start();
            defineButtonsAsVisible();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (r_AppSettings.RememberUser && !string.IsNullOrEmpty(r_AppSettings.LastAccessToken))
            { 
                new Thread(autoLogin).Start();
            }
        }

        private void autoLogin()
        {
            m_LoginResult = FacebookService.Connect(r_AppSettings.LastAccessToken);
            LoggedInUser = m_LoginResult.LoggedInUser;
            fetchUserInfo();
            defineButtonsAsVisible();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            r_AppSettings.LastWindowSize = this.Size;
            r_AppSettings.LastWindowLocation = this.Location;
            r_AppSettings.RememberUser = this.checkBoxRememberMe.Checked;
            if (r_AppSettings.RememberUser)
            {
                r_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
            }

            r_AppSettings.SaveToFile();
        }

        private void defineButtonsAsVisible()
        {
            Invoke(new Action(() =>
            {
                buttonAlbum.Visible = true;
                buttonFriends.Visible = true;
                buttonPosts.Visible = true;
                buttonLikedPaages.Visible = true;
            }));
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.Enabled = true;
            pictureBoxProfile.Image = null;
        }

        private void fetchUserInfo()
        {
            Invoke(new Action(() =>
            {
                buttonLogin.Text = "Logged in";
                pictureBoxProfile.LoadAsync(LoggedInUser.PictureNormalURL);
                labelProfileName.Visible = true;
                labelProfileName.Text = LoggedInUser.Name;
                if (r_AppSettings.RememberUser)
                {
                    checkBoxRememberMe.Checked = true;
                }
                else
                {
                    checkBoxRememberMe.Checked = false;
                }
            }));
        }

        private void showFriends()
        {
            foreach (FictionUsers fictionUser in r_ListOfFictionUsers)
            {
                listBoxFriends.Invoke(new Action(() => listBoxFriends.Items.Add(fictionUser.Name)));
                if (listBoxFriends.Items.Count == 0)
                {
                    MessageBox.Show("No Friends to retrieve :(");
                }
            }

            /**
             * In case we can access user's friend via fecebook
             */
            ////  listBoxFriends.Invoke(new Action(() =>
            ////{
            ////if (listBoxFriends.Items.Count == 0)
            ////{
            ////    MessageBox.Show("No Friends to retrieve :(");
            ////}
            // }));
        }

        /**
        * In case we can access user's friend via fecebook
        */
        /*private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            new Thread(displaySelectedFriend).Start();
        }*/

        private void showAlbums()
        {
            listBoxAlbums.Invoke(new Action(() => bindingAlbums()));
            if (listBoxAlbums.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }

        private void bindingAlbums()
        {
            albumBindingSource.DataSource = LoggedInUser.Albums;
        }

        private void fetchPosts()
        {
            if(LoggedInUser.Posts.Count != 0)
            {
                listBoxPosts.Invoke(new Action(() => bindingPosts()));
            }
            else
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void bindingPosts()
        {
            postBindingSource.DataSource = LoggedInUser.Posts.Where(post => post.Message != null);
        }

        private void buttonTrivia_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                this.Hide();
                TriviaFriendsForm triviaFriendsForm =
                    FactoryForm.CreateSpecificForm("TriviaFriendsForm") as TriviaFriendsForm;
                triviaFriendsForm.ShowDialog();
                this.Show();
            }));
        }

        private void buttonFindYourMatch_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                this.Hide();
                FindYourMatchForm findYourMatchForm = FactoryForm.CreateSpecificForm("FindYourMatchForm") as FindYourMatchForm;
                findYourMatchForm.ShowDialog();
                this.Show();
            }));
        }

        private void fetchLikedPages()
        {
            listBoxLikedPages.Invoke(new Action(() => bindingLikedPages()));
            if (listBoxLikedPages.Items.Count == 0)
            {
                MessageBox.Show("No liked pages to retrieve :(");
            }
        }

        private void bindingLikedPages()
        {
            pageBindingSource.DataSource = LoggedInUser.LikedPages;
        }

        private void buttonAlbum_Click(object sender, EventArgs e)
        {
            new Thread(showAlbums).Start();
        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            new Thread(showFriends).Start();
        }

        private void buttonLikedPaages_Click(object sender, EventArgs e)
        {
            new Thread(fetchLikedPages).Start();
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            new Thread(fetchPosts).Start();
        }

        private void fetchMatchFriendsBornedInSummer(string i_Season)
        {
            listBoxFilterBySeasonFriend.Items.Clear();
            friendsBornedInSelectedSeason = ApplicationManagerFacade.GetListOfMatchFriendsBySeason(i_Season);
            foreach (FictionUsers fictionUser in friendsBornedInSelectedSeason)
            {
                listBoxFilterBySeasonFriend.Invoke(new Action(() => listBoxFilterBySeasonFriend.Items.Add(fictionUser.Name)));
                if (listBoxFilterBySeasonFriend.Items.Count == 0)
                {
                    MessageBox.Show("There are no friends that borned in summer season :(");
                }
            }
        }

        private void fetchMatchFriendsBornedInWinter(string i_Season)
        {
            listBoxFilterBySeasonFriend.Items.Clear();
            friendsBornedInSelectedSeason = ApplicationManagerFacade.GetListOfMatchFriendsBySeason(i_Season);
            foreach (FictionUsers fictionUser in friendsBornedInSelectedSeason)
            {
                listBoxFilterBySeasonFriend.Invoke(new Action(() => listBoxFilterBySeasonFriend.Items.Add(fictionUser.Name)));
                if (listBoxFilterBySeasonFriend.Items.Count == 0)
                {
                    MessageBox.Show("There are no friends that borned in winter season :(");
                }
            }
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

        private void checkedListBoxSeasons_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            season = (sender as CheckedListBox).SelectedItem.ToString();
            makeTheOtherCheckBoxOptionsEnabled(sender);
            if (season.Equals("Summer"))
            {
                fetchMatchFriendsBornedInSummer(season);
            }
            else if (season.Equals("Winter"))
            {
                fetchMatchFriendsBornedInWinter(season);
            }
        }
    }
}