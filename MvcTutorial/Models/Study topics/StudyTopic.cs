namespace MvcTutorial.Models
{
    public class StudyTopic
    {
        public string question;
        public string answer;
        public int repetitions;

        public StudyTopic(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
            repetitions = 1;
        }

        public StudyTopic() { }
    }
}
