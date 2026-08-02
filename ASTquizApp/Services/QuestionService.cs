using ASTquizApp.Models;

namespace ASTquizApp.Services
{
    public class QuestionService
    {

        public List<Question> GetRandomQuestions(List<Question> allQuestions)
        {
            Random rnd = new();

            return allQuestions
                    .OrderBy(x => rnd.Next())
                    .Take(100)
                    .ToList();
        }
    }
}
