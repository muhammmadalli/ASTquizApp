namespace ASTquizApp.Models
{
    public class Result
    {
        public string CandidateName { get; set; } = string.Empty;

        public int TotalQuestions { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }

        public double Percentage { get; set; }
    }
}