using System;
using System.Linq;

namespace exam_system.models
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        private static int _nextId = 1;

        public int QuestionId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        // short constructor -> chains to the full one (auto id + empty AnswerList)
        protected Question(string header, string body, int marks)
            : this(_nextId++, header, body, marks, new AnswerList())
        {
        }

        protected Question(int questionId, string header, string body, int marks, AnswerList answers)
        {
            QuestionId = questionId;
            Header = header;
            Body = body;
            Marks = marks;
            Answers = answers ?? new AnswerList();
        }

        public abstract void DisplayQuestion();
        public abstract string GetCorrectAnswerText();

        protected void PrintQuestion(string hint)
        {
            Console.WriteLine($"[{Header}] ({Marks} marks) {Body}  <{hint}>");
            foreach (Answer a in Answers)
                Console.WriteLine($"    {a.AnswerId}) {a.AnswerText}");
        }

        // ICloneable (deep copy of the answers)
        public virtual object Clone()
        {
            Question copy = (Question)MemberwiseClone();
            copy.Answers = new AnswerList();
            foreach (Answer a in Answers)
                copy.Answers.Add(new Answer(a.AnswerId, a.AnswerText));
            return copy;
        }

        // IComparable<Question> (by Marks)
        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            return Marks.CompareTo(other.Marks);
        }

        public override string ToString()
        {
            return $"QuestionId: {QuestionId}, Header: {Header}, Body: {Body}, Marks: {Marks}, Answers: {Answers}";
        }

        public override bool Equals(object obj)
        {
            return obj is Question other
                && GetType() == other.GetType()
                && QuestionId == other.QuestionId
                && Header == other.Header
                && Body == other.Body
                && Marks == other.Marks
                && Answers.SequenceEqual(other.Answers);
        }

        // Answers is mutable, so it is not part of the hash
        public override int GetHashCode()
        {
            return HashCode.Combine(QuestionId, Header, Body, Marks);
        }
    }
}
