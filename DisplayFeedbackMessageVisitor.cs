using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BasicFacebookFeatures
{
    internal class DisplayFeedbackMessageVisitor
    {
        private readonly Timer r_Timer = new Timer(2000);
        private readonly Random r_RandomIndex = new Random();
        private readonly  List<string> r_ListOfMessageFeedback;
        public Label LabelMessageToDisplay { get; set; }
        public int RandomIdx { get; set; }

        public DisplayFeedbackMessageVisitor(List<string> i_ListOfFeedbackMessages)
        {
            LabelMessageToDisplay = new Label();
            r_ListOfMessageFeedback = i_ListOfFeedbackMessages;
            r_Timer.Elapsed += setLabelMessage;
            r_Timer.Enabled = true;
            r_Timer.AutoReset = true;
            r_Timer.Start();
        }

        private void setLabelMessage(object sender, ElapsedEventArgs e)
        {
            RandomIdx = r_RandomIndex.Next(r_ListOfMessageFeedback.Count);
            LabelMessageToDisplay.Invoke(new Action(() => LabelMessageToDisplay.Text = r_ListOfMessageFeedback[RandomIdx]));
        }

        internal void back(Form i_CurrentForm)
        {
            r_Timer.Stop();
            i_CurrentForm.Close();
        }
    }
}
