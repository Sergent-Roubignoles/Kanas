using MvcTutorial.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Models.Study
{
    /// <summary>
    /// This class provides logic to go through a list of "topics" to study.
    /// Topics contain a question and an answer. Each topic will need to be sucessfully answered multiple times before the study session is considered "complete".
    /// </summary>
    public class StudySession
    {
        public List<StudyTopicGroup> topicGroups;
        public StudyTopic currentQuestion;
        public bool studyComplete = false;
        public string tutorialView;

        public StudySession(List<StudyTopicGroup> topicGroups, string tutorialView)
        {
            this.topicGroups = topicGroups;
            this.tutorialView = tutorialView;
            ChangeQuestion();
        }

        public StudySession() { }

        /// <summary>
        /// Validates the answer provided, and prepares the next question.
        /// </summary>
        /// <param name="answer">The user's answer to the current question.</param>
        /// <returns>The correct answer to the question.</returns>
        public string VerifyAnswer(string answer)
        {
            var correctAnswer = currentQuestion.answer;
            if (answer == correctAnswer)
                currentQuestion.repetitions--;

            ChangeQuestion(currentQuestion.question);
            return correctAnswer;
        }

        /// <summary>
        /// Verifies the amount of questions not yet answered.
        /// </summary>
        /// <returns>The number of remaining questions.</returns>
        public int QuestionsRemaining()
        {
            int remainingQuestions = 0;
            foreach (var topicGroup in topicGroups)
                remainingQuestions += topicGroup.QuestionsRemaining();

            return remainingQuestions;
        }

        private void ChangeQuestion(string previousQuestion = "")
        {
            if (topicGroups.First().QuestionsRemaining() == 0)
                topicGroups.RemoveAt(0);

            if (topicGroups.Count == 0)
                studyComplete = true;
            else
                currentQuestion = topicGroups.First().NextQuestion(previousQuestion);
        }
    }
}
