using System;

namespace exam_system.models
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public override string ToString()
        {
            return $"AnswerId: {AnswerId}, AnswerText: {AnswerText}";
        }

        public override bool Equals(object obj)
        {
            return obj is Answer other
                && AnswerId == other.AnswerId
                && AnswerText == other.AnswerText;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AnswerId, AnswerText);
        }
    }
}
