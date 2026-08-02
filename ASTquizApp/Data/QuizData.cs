using ASTquizApp.Models;

namespace ASTquizApp.Data
{
    public static class QuizData
    {
        public static string CandidateName { get; set; }
            = "";

        public static List<Question> Questions { get; set; }
            = new List<Question>();

        public static Dictionary<int, string> Answers { get; set; }
            = new Dictionary<int, string>();
    }
}