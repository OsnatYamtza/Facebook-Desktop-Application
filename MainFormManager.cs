using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    internal class MainFormManager
    {
        private readonly List<FictionUsers> r_ListOfFictionUsers;

        public MainFormManager()
        {
            r_ListOfFictionUsers = new List<FictionUsers>();
            initializeListOfFictionFriends();
        }

        private void initializeListOfFictionFriends()
        {
            FictionUsers friend1 = new FictionUsers("Michael Levi", "April");
            FictionUsers friend2 = new FictionUsers("Dor Cohen", "November");
            FictionUsers friend3 = new FictionUsers("Shalom Asayag", "February");
            FictionUsers friend4 = new FictionUsers("Tal Avital", "August");
            FictionUsers friend5 = new FictionUsers("Rona Grinberg", "December");

            r_ListOfFictionUsers.Add(friend1);
            r_ListOfFictionUsers.Add(friend2);
            r_ListOfFictionUsers.Add(friend3);
            r_ListOfFictionUsers.Add(friend4);
            r_ListOfFictionUsers.Add(friend5);
        }

        internal List<FictionUsers> getListOfFictionUsersToMainForm()
        {
            return r_ListOfFictionUsers;
        }
    }
}