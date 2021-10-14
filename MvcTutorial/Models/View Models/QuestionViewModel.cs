using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Models.View_Models
{
    public class QuestionViewModel
    {
        public Guid SessionKey { get; set; }
        public string Question { get; set; }
        public int TotalQuestions { get; set; }
        public string TutorialView { get; set; }

        public QuestionViewModel(Guid sessionKey, string question, int totalQuestions, string tutorialView)
        {
            SessionKey = sessionKey;
            Question = question;
            TotalQuestions = totalQuestions;
            TutorialView = tutorialView;
        }
    }
}
