using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Models.Study
{
    public class StudyTopicGroup
    {
        private List<StudyTopic> topics;

        public StudyTopicGroup(List<StudyTopic> topics)
        {
            this.topics = topics;
        }

        public int QuestionsRemaining()
        {
            int total = 0;
            foreach (var topic in topics)
                total += topic.repetitions;

            return total;
        }

        public StudyTopic NextQuestion()
        {
            List<StudyTopic> unansweredQuestions = new List<StudyTopic>();
            foreach (var topic in topics)
            {
                if (topic.repetitions > 0)
                    unansweredQuestions.Add(topic);
            }
            topics = unansweredQuestions;

            return topics.ElementAt(new Random().Next(topics.Count));
        }
    }
}
