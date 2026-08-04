using ASTquizApp.Models;

namespace ASTquizApp.Services
{
    public class QuestionService
    {

    public List<Question> GetRandomQuestions(
        List<Question> questions,
        int questionCount)
        {
            return questions
                .OrderBy(x => Guid.NewGuid())
                .Take(questionCount)
                .ToList();
        }
    }
}
