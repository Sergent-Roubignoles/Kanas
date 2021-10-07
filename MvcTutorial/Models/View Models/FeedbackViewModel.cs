using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Models.View_Models
{
    public class FeedbackViewModel
    {
        public Guid sessionKey { get; set; }
        public string question { get; set; }
        public string correctAnswer { get; set; }
        public string usersAnswer { get; set; }

        public FeedbackViewModel(Guid sessionKey, string question, string correctAnswer, string usersAnswer)
        {
            this.sessionKey = sessionKey;
            this.question = question;
            this.correctAnswer = correctAnswer;
            this.usersAnswer = usersAnswer;
        }
    }
}
