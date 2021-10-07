namespace MvcTutorial.Models.Study
{
    public class StudyTopic
    {
        public string question;
        public string answer;
        public int repetitions;

        public StudyTopic(string question, string answer, int repetitions)
        {
            this.question = question;
            this.answer = answer;
            this.repetitions = repetitions;
        }

        public StudyTopic() { }
    }
}
