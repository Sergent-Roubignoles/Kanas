using MvcTutorial.Models;
using MvcTutorial.Models.Study;
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
            var topicGroups = new List<StudyTopicGroup>();

            switch (split[0])
            {
                case "h":
                    switch (split[1])
                    {
                        case "a":
                            topicGroups.Add(stringArrayToTopicGroup( new string[,]
                            {
                                { "あ", "a" },
                                { "い", "i" },
                                { "う", "u" },
                                { "え", "e" },
                                { "お", "o" },
                                { "ん", "n" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup( new string[,]
                            {
                                { "あい", "ai" },
                                { "あう", "au" },
                                { "あお", "ao" },
                                { "いいえ", "iie" },
                                { "うえ", "ue" },
                                { "うん", "un" },
                                { "おおい", "ooi" },
                                { "おん", "on" },
                            }, 1));
                            break;
                        case "ka":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "か", "ka" },
                                { "き", "ki" },
                                { "く", "ku" },
                                { "け", "ke" },
                                { "こ", "ko" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "かう", "kau" },
                                { "かお", "kao" },
                                { "きく", "kiku" },
                                { "あき", "aki" },
                                { "おこ", "oko" },
                                { "うけ", "uke" },
                                { "いき", "iki" },
                                { "いかん", "ikan" },
                                { "きけん", "kiken" },
                            }, 1));
                            break;
                        case "ga":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "が", "ga" },
                                { "ぎ", "gi" },
                                { "ぐ", "gu" },
                                { "げ", "ge" },
                                { "ご", "go" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "けげん", "kegen" },
                                { "くぎ", "kugi" },
                                { "かぎ", "kagi" },
                                { "がんこ", "ganko" },
                                { "ぐんか", "gunka" },
                            }, 1));
                            break;
                        case "ya":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "や", "ya" },
                                { "ゆ", "yu" },
                                { "よ", "yo" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "きょう", "kyou" },
                                { "きゃく", "kyaku" },
                                { "きんきゅう", "kinkyuu" },
                                { "ぎゃく", "gyaku" },
                            }, 1));
                            break;
                        case "sa":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "さ", "sa" },
                                { "し", "shi" },
                                { "す", "su" },
                                { "せ", "se" },
                                { "そ", "so" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "しゃ", "sha" },
                                { "しゅ", "shu" },
                                { "しょ", "sho" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "しょうゆ", "shouyu" },
                                { "すし", "sushi" },
                                { "せいそ", "seiso" },
                                { "すいせい", "suisei" },
                                { "さす", "sasu" },
                                { "ししょう", "shishou" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "ざ", "za" },
                                { "じ", "ji" },
                                { "ず", "zu" },
                                { "ぜ", "ze" },
                                { "ぞ", "zo" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "じゃ", "ja" },
                                { "じゅ", "ju" },
                                { "じょ", "jo" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "しずか", "shizuka" },
                                { "ざこ", "zako" },
                                { "じこしょうかい", "jikoshoukai" },
                                { "ぜんぜん", "zenzen" },
                                { "かいぞく", "kaizoku" },
                            }, 1));
                            break;
                        case "ta":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "た", "ta" },
                                { "ち", "chi" },
                                { "つ", "tsu" },
                                { "て", "te" },
                                { "と", "to" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "たつ", "tatsu" },
                                { "ちいさい", "chiisai" },
                                { "ちゃんと", "chanto" },
                                { "たんとう", "tantou" },
                                { "てき", "teki" },
                                { "たて", "tate" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "かって", "katte" },
                                { "かっこいい", "kakkoii" },
                                { "さっさと", "sassato" },
                                { "どっち", "docchi" },
                                { "だっしゅつ", "dasshutsu" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "だ", "da" },
                                { "ぢ", "dji" },
                                { "づ", "dzu" },
                                { "で", "de" },
                                { "ど", "do" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "そだつ", "sodatsu" },
                                { "ちぢむ", "chidjimu" },
                                { "つづく", "tsudzuku" },
                                { "だって", "datte" },
                                { "どこ", "doko" },
                            }, 1));
                            break;
                        case "na":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "な", "na" },
                                { "に", "ni" },
                                { "ぬ", "nu" },
                                { "ね", "ne" },
                                { "の", "no" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "なんだ", "nanda" },
                                { "なに", "nani" },
                                { "いぬ", "inu" },
                                { "ねえさん", "neesan" },
                                { "ぬの", "nuno" },
                                { "にゅうがく", "nyuugaku" },
                                { "あんない", "annai" },
                                { "にんじゃ", "ninja" },
                            }, 1));
                            break;
                        case "ha":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "は", "ha" },
                                { "ひ", "hi" },
                                { "ふ", "fu" },
                                { "へ", "he" },
                                { "ほ", "ho" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "へんたい", "hentai" },
                                { "はんのう", "hannou" },
                                { "とうふ", "toufu" },
                                { "ほんとう", "hontou" },
                                { "ひどい", "hidoi" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "ば", "ba" },
                                { "び", "bi" },
                                { "ぶ", "bu" },
                                { "べ", "be" },
                                { "ぼ", "bo" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "べんとう", "bentou" },
                                { "びんかん", "binkan" },
                                { "ばんざい", "banzai" },
                                { "ぶた", "buta" },
                                { "ふんぼ", "funbo" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "ぱ", "pa" },
                                { "ぴ", "pi" },
                                { "ぷ", "pu" },
                                { "ぺ", "pe" },
                                { "ぽ", "po" },
                            }, 1));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "せんぱい", "senpai" },
                                { "いっぴき", "ippiki" },
                                { "せんぷう", "senpuu" },
                                { "いっぺん", "ippen" },
                                { "さんぽ", "sanpo" },
                            }, 1));
                            break;
                        case "ma":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "ま", "ma" },
                                { "み", "mi" },
                                { "む", "mu" },
                                { "め", "me" },
                                { "も", "mo" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "むめい", "mumei" },
                                { "みこ", "miko" },
                                { "つのまき", "tsunomaki" },
                                { "ふともも", "futomomo" },
                                { "みじゅく", "mijuku" },
                                { "めんどう", "mendou" },
                            }, 1));
                            break;
                        case "ra":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "ら", "ra" },
                                { "り", "ri" },
                                { "る", "ru" },
                                { "れ", "re" },
                                { "ろ", "ro" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "らんぼう", "ranbou" },
                                { "りんご", "ringo" },
                                { "おとる", "otoru" },
                                { "ひゃくれつ", "hyakuretsu" },
                                { "ろんぱ", "ronpa" },
                            }, 1));
                            break;
                        case "wa":
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "わ", "wa" },
                                { "を", "wo" },
                            }, 2));
                            topicGroups.Add(stringArrayToTopicGroup(new string[,]
                            {
                                { "わため", "watame" },
                                { "あわい", "awai" },
                            }, 1));
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

            return new StudySession(topicGroups);
        }

        private static StudyTopicGroup stringArrayToTopicGroup(string[,] topics, int repetitions)
        {
            var topicList = new List<StudyTopic>();
            for (int i = 0; i < topics.GetLength(0); i++)
                topicList.Add(new StudyTopic(topics[i, 0], topics[i, 1], repetitions));

            return new StudyTopicGroup(topicList);
        }
    }
}
