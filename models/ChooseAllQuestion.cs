using System.Collections.Generic;
using System.Linq;

namespace exam_system.models
{
    internal class ChooseAllQuestion : Question
    {
        public List<int> CorrectAnswerIds { get; set; }

        public ChooseAllQuestion(string header, string body, int marks, List<int> correctAnswerIds)
            : base(header, body, marks)
        {
            CorrectAnswerIds = correctAnswerIds ?? new List<int>();
        }

        public override void DisplayQuestion()
        {
            PrintQuestion("Choose ALL that apply");
        }

        public override string GetCorrectAnswerText()
        {
            return string.Join(", ", Answers
                .Where(a => CorrectAnswerIds.Contains(a.AnswerId))
                .Select(a => $"{a.AnswerId}) {a.AnswerText}"));
        }

        public override object Clone()
        {
            ChooseAllQuestion copy = (ChooseAllQuestion)base.Clone();
            copy.CorrectAnswerIds = new List<int>(CorrectAnswerIds);
            return copy;
        }
    }
}
