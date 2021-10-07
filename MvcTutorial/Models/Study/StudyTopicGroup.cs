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

        public StudyTopic NextQuestion(string previousQuestion)
        {
            var topicsWithMostRepetitions = GetTopicsWithMostRepetitions();
            if (topicsWithMostRepetitions.Count > 0)
            {
                FilterOutTopicWithQuestion(topicsWithMostRepetitions, previousQuestion);
                return topicsWithMostRepetitions.ElementAt(new Random().Next(topicsWithMostRepetitions.Count));
            }
            else
                throw new InvalidOperationException("All questions have already been answered.");
        }

        private List<StudyTopic> GetTopicsWithMostRepetitions()
        {
            List<StudyTopic> topicsWithMostRepetitions = new();
            int mostRepetitions = 0;

            foreach (var topic in topics)
            {
                if (topic.repetitions > 0)
                {
                    if (topic.repetitions > mostRepetitions)
                    {
                        mostRepetitions = topic.repetitions;
                        topicsWithMostRepetitions = new List<StudyTopic> { topic };
                    }
                    else
                    {
                        if (topic.repetitions == mostRepetitions)
                            topicsWithMostRepetitions.Add(topic);
                    }
                }
            }

            return topicsWithMostRepetitions;
        }

        private static List<StudyTopic> FilterOutTopicWithQuestion(List<StudyTopic> topicsToFilter,
            string questionToRemove)
        {
            if (topicsToFilter.Count > 1)
            {
                for (int i = 0; i < topicsToFilter.Count; i++)
                {
                    if (topicsToFilter[i].question == questionToRemove)
                    {
                        topicsToFilter.RemoveAt(i);
                        break;
                    }
                }
            }

            return topicsToFilter;
        }
    }
}
