using ASTquizApp.Models;

namespace ASTquizApp.Services
{
    public class ResultService
    {
        public Result CalculateResult(
            List<Question> questions,
            Dictionary<int, string> answers,
            string candidateName)
        {
            int correct = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (answers.ContainsKey(i))
                {
                    if (answers[i] ==
                       questions[i].CorrectAnswer)
                    {
                        correct++;
                    }
                }
            }

            int wrong =
                questions.Count - correct;

            double percentage =
                ((double)correct /
                questions.Count) * 100;

            return new Result
            {
                CandidateName = candidateName,
                TotalQuestions = questions.Count,
                CorrectAnswers = correct,
                WrongAnswers = wrong,
                Percentage = percentage
            };
        }
    }
}