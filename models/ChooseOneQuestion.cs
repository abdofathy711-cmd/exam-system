using System.Linq;

namespace exam_system.models
{
    internal class ChooseOneQuestion : Question
    {
        public int CorrectAnswerId { get; set; }

        public ChooseOneQuestion(string header, string body, int marks, int correctAnswerId)
            : base(header, body, marks)
        {
            CorrectAnswerId = correctAnswerId;
        }

        public override void DisplayQuestion()
        {
            PrintQuestion("Choose ONE answer");
        }

        public override string GetCorrectAnswerText()
        {
            Answer a = Answers.FirstOrDefault(x => x.AnswerId == CorrectAnswerId);
            return a == null ? "N/A" : $"{a.AnswerId}) {a.AnswerText}";
        }
    }
}
