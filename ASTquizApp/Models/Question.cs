
namespace ASTquizApp.Models{
    public class Question{
        public string Book { get; set; } = string.Empty;

        public string Chapter { get; set; } = string.Empty;

        public string Topic { get; set; } = string.Empty;

        public string QuestionText { get; set; } = string.Empty;

        public string OptionA { get; set; } = string.Empty;

        public string OptionB { get; set; } = string.Empty;

        public string OptionC { get; set; } = string.Empty;

        public string OptionD { get; set; } = string.Empty;

        public string CorrectAnswer { get; set; } = string.Empty;
    }
}