using MvcTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTutorial.Data
{
    public static class StudySessionManager
    {
        static Dictionary<Guid, StudySession> activeSessions = new Dictionary<Guid, StudySession>();

        public static Guid AddSession(StudySession session)
        {
            var key = Guid.NewGuid();
            activeSessions.Add(key, session);

            return key;
        }

        public static StudySession GetSession(Guid key)
        {
            return activeSessions[key];
        }

        public static void TerminateSession(Guid key)
        {
            activeSessions.Remove(key);
        }

        public static StudySession NewSessionWithTopicCode(string topicCode)
        {
            if (topicCode == null)
                throw new ArgumentNullException(nameof(topicCode));

            var split = topicCode.Split('-');
            var topics = new List<StudySession.StudyTopic>();

            switch (split[0])
            {
                case "h":
                    switch (split[1])
                    {
                        case "a":
                            string[,] simpleTopics = new string[,]
                            {
                                { "あ", "a" },
                                { "い", "i" },
                                { "う", "u" },
                                { "え", "e" },
                                { "お", "o" },
                                { "ん", "n" },
                            };
                            topics.Add(new StudySession.StudyTopic("あ", "a"));
                            topics.Add(new StudySession.StudyTopic("い", "i"));
                            topics.Add(new StudySession.StudyTopic("う", "u"));
                            topics.Add(new StudySession.StudyTopic("え", "e"));
                            topics.Add(new StudySession.StudyTopic("お", "o"));
                            topics.Add(new StudySession.StudyTopic("ん", "n"));
                            break;
                        case "ka":
                            topics.Add(new StudySession.StudyTopic("か", "ka"));
                            topics.Add(new StudySession.StudyTopic("き", "ki"));
                            topics.Add(new StudySession.StudyTopic("く", "ku"));
                            topics.Add(new StudySession.StudyTopic("け", "ke"));
                            topics.Add(new StudySession.StudyTopic("こ", "ko"));
                            break;
                        case "ga":
                            topics.Add(new StudySession.StudyTopic("が", "ga"));
                            topics.Add(new StudySession.StudyTopic("ぎ", "gi"));
                            topics.Add(new StudySession.StudyTopic("ぐ", "gu"));
                            topics.Add(new StudySession.StudyTopic("げ", "ge"));
                            topics.Add(new StudySession.StudyTopic("ご", "go"));
                            break;
                        case "ya":
                            topics.Add(new StudySession.StudyTopic("や", "ya"));
                            topics.Add(new StudySession.StudyTopic("ゆ", "yu"));
                            topics.Add(new StudySession.StudyTopic("よ", "yo"));
                            topics.Add(new StudySession.StudyTopic("きゃ", "kya"));
                            topics.Add(new StudySession.StudyTopic("きゅ", "kyu"));
                            topics.Add(new StudySession.StudyTopic("きょ", "kyo"));
                            topics.Add(new StudySession.StudyTopic("ぎゃ", "gya"));
                            topics.Add(new StudySession.StudyTopic("ぎゅ", "gyu"));
                            topics.Add(new StudySession.StudyTopic("ぎょ", "gyo"));
                            break;
                        case "sa":
                            topics.Add(new StudySession.StudyTopic("さ", "sa"));
                            topics.Add(new StudySession.StudyTopic("し", "shi"));
                            topics.Add(new StudySession.StudyTopic("す", "su"));
                            topics.Add(new StudySession.StudyTopic("せ", "se"));
                            topics.Add(new StudySession.StudyTopic("そ", "so"));
                            topics.Add(new StudySession.StudyTopic("ざ", "za"));
                            topics.Add(new StudySession.StudyTopic("じ", "ji"));
                            topics.Add(new StudySession.StudyTopic("ず", "zu"));
                            topics.Add(new StudySession.StudyTopic("ぜ", "ze"));
                            topics.Add(new StudySession.StudyTopic("ぞ", "zo"));
                            topics.Add(new StudySession.StudyTopic("しゃ", "sha"));
                            topics.Add(new StudySession.StudyTopic("しゅ", "shu"));
                            topics.Add(new StudySession.StudyTopic("しょ", "sho"));
                            topics.Add(new StudySession.StudyTopic("じゃ", "ja"));
                            topics.Add(new StudySession.StudyTopic("じゅ", "ju"));
                            topics.Add(new StudySession.StudyTopic("じょ", "jo"));
                            break;
                        case "ta":
                            topics.Add(new StudySession.StudyTopic("た", "ta"));
                            topics.Add(new StudySession.StudyTopic("ち", "chi"));
                            topics.Add(new StudySession.StudyTopic("つ", "tsu"));
                            topics.Add(new StudySession.StudyTopic("て", "te"));
                            topics.Add(new StudySession.StudyTopic("と", "to"));
                            topics.Add(new StudySession.StudyTopic("だ", "da"));
                            topics.Add(new StudySession.StudyTopic("ぢ", "dji"));
                            topics.Add(new StudySession.StudyTopic("づ", "dzu"));
                            topics.Add(new StudySession.StudyTopic("で", "de"));
                            topics.Add(new StudySession.StudyTopic("ど", "do"));
                            break;
                        case "na":
                            topics.Add(new StudySession.StudyTopic("な", "na"));
                            topics.Add(new StudySession.StudyTopic("に", "ni"));
                            topics.Add(new StudySession.StudyTopic("ぬ", "nu"));
                            topics.Add(new StudySession.StudyTopic("ね", "ne"));
                            topics.Add(new StudySession.StudyTopic("の", "no"));
                            break;
                        case "ha":
                            topics.Add(new StudySession.StudyTopic("は", "ha"));
                            topics.Add(new StudySession.StudyTopic("ひ", "hi"));
                            topics.Add(new StudySession.StudyTopic("ふ", "fu"));
                            topics.Add(new StudySession.StudyTopic("へ", "he"));
                            topics.Add(new StudySession.StudyTopic("ほ", "ho"));
                            topics.Add(new StudySession.StudyTopic("ば", "ba"));
                            topics.Add(new StudySession.StudyTopic("び", "bi"));
                            topics.Add(new StudySession.StudyTopic("ぶ", "bu"));
                            topics.Add(new StudySession.StudyTopic("べ", "be"));
                            topics.Add(new StudySession.StudyTopic("ぼ", "bo"));
                            topics.Add(new StudySession.StudyTopic("ぱ", "pa"));
                            topics.Add(new StudySession.StudyTopic("ぴ", "pi"));
                            topics.Add(new StudySession.StudyTopic("ぷ", "pu"));
                            topics.Add(new StudySession.StudyTopic("ぺ", "pe"));
                            topics.Add(new StudySession.StudyTopic("ぽ", "po"));
                            break;
                        case "ma":
                            topics.Add(new StudySession.StudyTopic("ま", "ma"));
                            topics.Add(new StudySession.StudyTopic("み", "mi"));
                            topics.Add(new StudySession.StudyTopic("む", "mu"));
                            topics.Add(new StudySession.StudyTopic("め", "me"));
                            topics.Add(new StudySession.StudyTopic("も", "mo"));
                            break;
                        case "ra":
                            topics.Add(new StudySession.StudyTopic("ら", "ra"));
                            topics.Add(new StudySession.StudyTopic("り", "ri"));
                            topics.Add(new StudySession.StudyTopic("る", "ru"));
                            topics.Add(new StudySession.StudyTopic("れ", "re"));
                            topics.Add(new StudySession.StudyTopic("ろ", "ro"));
                            break;
                        case "wa":
                            topics.Add(new StudySession.StudyTopic("わ", "wa"));
                            topics.Add(new StudySession.StudyTopic("を", "wo"));
                            break;
                    }
                    break;
                case "k":
                    switch (split[1])
                    {
                        case "a":
                            break;
                        case "ka":
                            break;
                        case "sa":
                            break;
                    }
                    break;
            }

            return new StudySession(topics);
        }
    }
}
