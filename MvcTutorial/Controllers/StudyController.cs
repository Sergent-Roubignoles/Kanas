using Microsoft.AspNetCore.Mvc;
using MvcTutorial.Data;
using MvcTutorial.Models;
using MvcTutorial.Models.View_Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MvcTutorial.Controllers
{
    public class StudyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hiragana()
        {
            return View();
        }

        public IActionResult Katakana()
        {
            return View();
        }
        
        public IActionResult StartStudy(string topicCode)
        {
            if (topicCode == null)
                return null;
            var session = StudySessionManager.NewSessionWithTopicCode(topicCode);
            var sessionKey = StudySessionManager.AddSession(session);

            var viewData = new QuestionViewModel(sessionKey, session.currentQuestion.question, session.QuestionsRemaining(), session.tutorialView, session.nextStudyLink);
            return View("Question", viewData);
        }

        /// <summary>
        /// Validates the user's answer, loads the next question and sends feedback to the user.
        /// </summary>
        /// <param name="sessionKey">The user's private session key.</param>
        /// <param name="answer">The user's answer to the current question.</param>
        /// <returns>The correct answer to the question.</returns>
        public string VerifyAnswer(string sessionKey, string answer)
        {
            answer = answer.ToLower();
            //Authentificate user and validate answer
            var guid = new Guid(sessionKey);
            var session = StudySessionManager.GetSession(guid);
            var correctAnswer = session.VerifyAnswer(answer);

            //Send correct answer back to user
            dynamic jsonResponse = new JObject();
            jsonResponse.correctAnswer = correctAnswer;
            jsonResponse.answerWasAccepted = (correctAnswer == answer);
            jsonResponse.questionsRemaining = session.QuestionsRemaining();
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonResponse);
        }

        /// <summary>
        /// Gets the current question. Ends the study if all questions were answered.
        /// </summary>
        /// <param name="sessionKey">The user's private session key.</param>
        /// <returns>The next question. The question is empty if all questions have been answered.</returns>
        public string NextQuestion(string sessionKey)
        {
            //Authentificate user
            var guid = new Guid(sessionKey);
            var session = StudySessionManager.GetSession(guid);
            
            //Get next question
            string nextQuestion = "";
            if (session.studyComplete)
            {
                StudySessionManager.TerminateSession(guid);
            }
            else
            {
                nextQuestion = session.currentQuestion.question;
            }

            //Send next question to the user
            dynamic jsonResponse = new JObject();
            jsonResponse.question = nextQuestion;
            jsonResponse.tutorial = session.extraTutorialId;
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonResponse);
        }
    }
}
