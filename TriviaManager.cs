using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ApplicationLogic.Observer;
using FacebookWrapper.ObjectModel;

namespace ApplicationLogic
{
    internal class TriviaManager
    {
        private readonly List<FictionUsers> r_ListOfFictionUsers;
        private readonly Dictionary<string, string> r_TriviaQuestionsAndAnswers;
        private readonly List<string> r_ListOfQuestions;
        private readonly List<string> r_ListOfFeedbackToTriviaForm = new List<string>()
        {
            "Let's see how good you know your friend",
            "You should know your friend better!",
            "You got this",
            "Think twice before you answer"
        };
        private int m_CorrectAnswers = 0;
        private int m_WrongAnswers = 0;
        internal FictionUsers ChosenFriend { get; set; }
        internal readonly IListener r_Listener;
        private readonly INotifier r_Notifier;
        

        /**
         * In case we can access the user's friends via facebook
         * //internal User ChosenFriend;
         * //private DateTime m_BirthDateOfTheFriend;
         * // internal User LoggedInUser { get; set; }
           // internal ApplicationManagerFacade ApplicationManagerFacade;
         *
         */

        public TriviaManager()
        {
            ////LoggedInUser = ApplicationManagerFacade.LoggedInUser;
            r_ListOfQuestions = new List<string>();
            r_TriviaQuestionsAndAnswers = new Dictionary<string, string>();
            r_ListOfFictionUsers = new List<FictionUsers>();
            initializeListOfFictionFriends();
            r_Listener = new MessageBoxListener();
            r_Notifier = new TriviaFormNotifier();
        }

        private void initializeListOfFictionFriends()
        {
            FictionUsers friend1 = new FictionUsers("25", "Holon", "Haim Levi", "January");
            FictionUsers friend2 = new FictionUsers("20", "Ramle", "Dor Cohen", "August");
            FictionUsers friend3 = new FictionUsers("22", "Karmiel", "Dana Ron", "September");

            r_ListOfFictionUsers.Add(friend1);
            r_ListOfFictionUsers.Add(friend2);
            r_ListOfFictionUsers.Add(friend3);
        }

        public List<FictionUsers> GetListOfFictionUsers()
        {
            return r_ListOfFictionUsers;
        }

        public void InitializeChosenFriend(FictionUsers i_ChosenFriend)
        {
            ChosenFriend = i_ChosenFriend;
            ////updateTheBirthDateOfTheChosenFriend();
        }

        /**
         * In case we can access the user's friends via facebook
         */
        ////private void updateTheBirthDateOfTheChosenFriend()
        ////{
        ////    m_BirthDateOfTheFriend = Convert.ToDateTime(ChosenFriend.Birthday);
        ////}

        internal void initializeQuestions(FictionUsers i_ChosenFriend)
        {
            if (r_ListOfQuestions != null)
            {
                r_ListOfQuestions.Clear();
            }

            r_ListOfQuestions.Add($"In which city {i_ChosenFriend.Name} lives?");
            r_ListOfQuestions.Add($"How old {i_ChosenFriend.Name} is?");
            r_ListOfQuestions.Add($"What is {i_ChosenFriend.Name}'s birthday month?");
        }

        internal void initializeDictionaryOfQuestionsAndAnswers()
        {
            if (r_TriviaQuestionsAndAnswers != null)
            {
                r_TriviaQuestionsAndAnswers.Clear();
            }

            foreach (eKeyQuestions keyQuestion in Enum.GetValues(typeof(eKeyQuestions)))
            {
                r_TriviaQuestionsAndAnswers.Add(r_ListOfQuestions[(int)keyQuestion], getSpecificAnswer(keyQuestion));
            }
        }

        private string getSpecificAnswer(eKeyQuestions i_KeyQuestion)
        {
            string specificAnswer = null;
            
            switch (i_KeyQuestion)
            {
                case eKeyQuestions.City:
                    ////specificAnswer = ChosenFriend.Location.Location.City;
                   specificAnswer = ChosenFriend.City;
                    break;
                case eKeyQuestions.Age:
                    ////specificAnswer = calculateTheAgeOfTheFriend();
                    specificAnswer = ChosenFriend.Age;
                    break;
                case eKeyQuestions.BirthMonth:
                    ////specificAnswer = m_BirthDateOfTheFriend.Month.ToString();
                    specificAnswer = ChosenFriend.BirthMonth;
                    break;
            }

            return specificAnswer;
        }

        internal void resetWrongAndCorrectAnswers()
        {
            m_WrongAnswers = 0;
            m_CorrectAnswers = 0;
        }

        /**
         * In case we can access the user's friends via facebook
         */
        ////private string calculateTheAgeOfTheFriend()
        ////{
        ////    var todayTime = DateTime.Today;
        ////    int currentFriendAge = todayTime.Year - m_BirthDateOfTheFriend.Year - 1;
        ////    return currentFriendAge.ToString();
        ////}

        internal List<string> getListOfQuestions()
        {
            return r_ListOfQuestions;
        }

        internal List<string> getListOfAgesAnswers()
        {
            /**
             * In case we can access the user's friends via facebook
             * //string friendAge = calculateTheAgeOfTheFriend();
             */

            string friendAge = ChosenFriend.Age;
            List<string> listOfOptionalAgesAnswers = new List<string>();
            Random random = new Random();
            string firstAgeOptional;
            string secondAgeOptional; 
            int minAgeOptional = int.Parse(friendAge) - 5;
            int maxAgeOptional = int.Parse(friendAge) + 5;
            
            while (true)
            {
                firstAgeOptional = random.Next(minAgeOptional, maxAgeOptional).ToString();
                secondAgeOptional = random.Next(minAgeOptional, maxAgeOptional).ToString();
                if (!firstAgeOptional.Equals(secondAgeOptional) &&
                    !firstAgeOptional.Equals(friendAge) &&
                    !secondAgeOptional.Equals(friendAge))
                {
                    break;
                }
            }

            listOfOptionalAgesAnswers.Add(firstAgeOptional);
            listOfOptionalAgesAnswers.Add(secondAgeOptional);
            listOfOptionalAgesAnswers.Add(friendAge);

            return listOfOptionalAgesAnswers;
        }

        internal List<string> getListOfCitiesAnswers()
        {
            List<string> listOfOptionalCitiesAnswers = new List<string>();
            string correctAnswer = getSpecificAnswer(eKeyQuestions.City);
            Random random = new Random();
            int randomForFirstCityOptional;
            int randomForSecondCityOptional;
            string firstCityOptional;
            string secondCityOptional;

            while (true)
            {
                randomForFirstCityOptional = random.Next(Enum.GetNames(typeof(eCitiesAnswers)).Length);
                randomForSecondCityOptional = random.Next(Enum.GetNames(typeof(eCitiesAnswers)).Length);
                firstCityOptional = ((eCitiesAnswers)randomForFirstCityOptional).ToString();
                secondCityOptional = ((eCitiesAnswers)randomForSecondCityOptional).ToString();
                if(!firstCityOptional.Equals(secondCityOptional) &&
                   !firstCityOptional.Equals(correctAnswer) &&
                   !secondCityOptional.Equals(correctAnswer))
                {
                    break;
                }
            }

            listOfOptionalCitiesAnswers.Add(firstCityOptional);
            listOfOptionalCitiesAnswers.Add(secondCityOptional);
            listOfOptionalCitiesAnswers.Add(correctAnswer);

            return listOfOptionalCitiesAnswers;
        }

        internal List<string> getListOfMonthsAnswers()
        {
            List<string> listOfOptionalMonthsAnswers = new List<string>();
            string correctAnswer = getSpecificAnswer(eKeyQuestions.BirthMonth);
            Random random = new Random();
            int randomForFirstMonthOptional;
            int randomForSecondMonthOptional;
            string firstMonthOptional;
            string secondMonthOptional;

            while (true)
            {
                randomForFirstMonthOptional = random.Next(Enum.GetNames(typeof(eBirthMonth)).Length);
                randomForSecondMonthOptional = random.Next(Enum.GetNames(typeof(eBirthMonth)).Length);
                firstMonthOptional = ((eBirthMonth)randomForFirstMonthOptional).ToString();
                secondMonthOptional = ((eBirthMonth)randomForSecondMonthOptional).ToString();
                if (!firstMonthOptional.Equals(secondMonthOptional) &&
                    !firstMonthOptional.Equals(correctAnswer) &&
                    !secondMonthOptional.Equals(correctAnswer))
                {
                    break;
                }
            }

            listOfOptionalMonthsAnswers.Add(firstMonthOptional);
            listOfOptionalMonthsAnswers.Add(secondMonthOptional);
            listOfOptionalMonthsAnswers.Add(correctAnswer);

            return listOfOptionalMonthsAnswers;
        }

        internal bool checkIfAnswerIsCorrect(eKeyQuestions eCurrentQuestion, string chosenAnswer)
        {
            bool isCorrectAnswer = false;
            string indexOfQuestion = r_ListOfQuestions[(int)eCurrentQuestion];

            if (r_TriviaQuestionsAndAnswers[indexOfQuestion] == chosenAnswer)
            {
                isCorrectAnswer = true;
            }

            return isCorrectAnswer;
        }

        internal void updateResults(int i_IndexOfQuestion, bool i_IsCorrectAnswer)
        {
            if (i_IndexOfQuestion == 0)
            {
                m_CorrectAnswers = 0;
                m_WrongAnswers = 0;
            }
            if (i_IsCorrectAnswer)
            {
                m_CorrectAnswers++;
            }
            else
            {
                m_WrongAnswers++;
            }
        }

        internal List<string> getListOfFeedbackMessages()
        {
            return r_ListOfFeedbackToTriviaForm;
        }

        internal string getFeedbackToDisplay()
        {
            string m_Feedback;

            if (m_CorrectAnswers == 3)
            {
                m_Feedback = "Good Job! You Know About Your Friend Very Well";
            }
            else
            {
                m_Feedback = "You Should Know Your Friend Better";
            }

            return m_Feedback + Environment.NewLine +  "You Answered: " 
                + Environment.NewLine + m_CorrectAnswers + " Correct Answers" 
                + Environment.NewLine + m_WrongAnswers + " Wrong Answers";
        }

        internal void notifyFeedbackListeners(string i_FeedbackToDisplay)
        {
            r_Notifier.NotifyAll(i_FeedbackToDisplay);
        }

        internal string getFeedbackMessageToDisplay()
        {
           return r_Listener.GetFeedbackMessageToDisplay();
        }

        internal void addFeedbackListener()
        {
            r_Notifier.AddListener(r_Listener);
        }

        private enum eCitiesAnswers
        {
            Batyam,
            Ramle,
            Holon,
            Rishon,
            TelAviv,
            Karmiel,
            Lod,
            Rehovot,
            Yafo,
            Eilat
        }
    }
}