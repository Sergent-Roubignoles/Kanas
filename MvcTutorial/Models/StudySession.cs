using MvcTutorial.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Models
{
    /// <summary>
    /// This class provides logic to go through a list of "topics" to study.
    /// Topics contain a question and an answer. Each topic will need to be sucessfully answered multiple times before the study session is considered "complete".
    /// </summary>
    public class StudySession
    {
        public List<StudyTopic> topics;
        public StudyTopic currentQuestion;
        public bool studyComplete = false;

        public StudySession(List<StudyTopic> topics)
        {
            this.topics = topics;
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
            {
                currentQuestion.repetitions--;
            }
            else
            {
                if (currentQuestion.repetitions <= 3)
                    currentQuestion.repetitions++;
            }

            ChangeQuestion();
            return correctAnswer;
        }

        /// <summary>
        /// Verifies the amount of questions not yet answered.
        /// </summary>
        /// <returns>The number of remaining questions.</returns>
        public int QuestionsRemaining()
        {
            int remainingQuestions = 0;
            foreach (StudyTopic topic in topics)
                remainingQuestions += topic.repetitions;
            return remainingQuestions;
        }

        private void ChangeQuestion()
        {
            List<StudyTopic> unfinishedQuestions = new List<StudyTopic>();
            foreach (StudyTopic topic in topics)
            {
                if (topic.repetitions > 0)
                    unfinishedQuestions.Add(topic);
            }

            if (unfinishedQuestions.Count == 0)
                studyComplete = true;
            else
                currentQuestion = unfinishedQuestions.ElementAt(new Random().Next(unfinishedQuestions.Count));
        }
    }
}
