using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public static class FactoryForm
    {
        public enum eFormName
        {
            FormMain,
            TriviaFriendsForm,
            FindYourMatchForm
        }

        public static Form CreateSpecificForm(string i_FormToCreate)
        {
            Form formToCreate;
            eFormName typeOfForm = (eFormName)Enum.Parse(typeof(eFormName), i_FormToCreate);

            switch (typeOfForm)
            {
                case eFormName.FormMain:
                    formToCreate = new FormMain();
                    break;
                case eFormName.TriviaFriendsForm:
                    formToCreate = new TriviaFriendsForm();
                    break;
                case eFormName.FindYourMatchForm:
                    formToCreate = new FindYourMatchForm();
                    break;
                default:
                    throw new Exception("Problem with creating the form");
            }

            return formToCreate;
        }
    }
}