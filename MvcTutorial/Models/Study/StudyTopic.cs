namespace MvcTutorial.Models.Study
{
    public class StudyTopic
    {
        public string question;
        public string answer;
        public string answerExplanation;
        public int repetitions;

        public StudyTopic(string question, string answer, int repetitions, string answerExplanation = null)
        {
            this.question = question;
            this.answer = answer;
            this.answerExplanation = answerExplanation;
            this.repetitions = repetitions;
        }

        public StudyTopic() { }
    }
}
