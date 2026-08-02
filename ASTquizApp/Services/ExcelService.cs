using ClosedXML.Excel;
using ASTquizApp.Models;

namespace ASTquizApp.Services
{
    public class ExcelService
    {
        public List<Question> LoadQuestions(List<string> files)
        {
            List<Question> questions = new();

            foreach (var file in files)
            {
                using (var workbook = new XLWorkbook(file))
                {
                    var ws = workbook.Worksheet(1);

                    foreach (var row in ws.RowsUsed().Skip(1))
                    {
                        questions.Add(new Question
                        {
                            Book = row.Cell(1).GetString(),
                            Chapter = row.Cell(2).GetString(),
                            Topic = row.Cell(4).GetString(),

                            QuestionText = row.Cell(8).GetString(),

                            OptionA = row.Cell(9).GetString(),

                            OptionB = row.Cell(10).GetString(),

                            OptionC = row.Cell(11).GetString(),

                            OptionD = row.Cell(12).GetString(),

                            CorrectAnswer = row.Cell(13).GetString()
                        });
                    }
                }
            }

            return questions;
        }
    }
}