using System;
using System.Collections.Generic;

namespace exam_system.models
{
    // internal because ExamEventArgs is internal
    internal delegate void ExamStartedHandler(object sender, ExamEventArgs e);

    internal abstract class Exam : ICloneable, IComparable<Exam>
    {
        private ExamMode _mode;

        public int TimeByMinute { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; }
        public Subject Subject { get; set; }

        public event ExamStartedHandler ExamStarted;

        public ExamMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                if (_mode == ExamMode.Starting)
                    OnExamStarted();
            }
        }

        protected Exam(int timeByMinute, Subject subject, QuestionList questions)
            : this(timeByMinute, questions?.Count ?? 0, questions, new Dictionary<Question, Answer>(), subject)
        {
        }

        protected Exam(int timeByMinute, int numberOfQuestions, QuestionList questions,
                       Dictionary<Question, Answer> questionAnswerDictionary, Subject subject)
        {
            TimeByMinute = timeByMinute;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
            QuestionAnswerDictionary = questionAnswerDictionary;
            Subject = subject;
            _mode = ExamMode.Queued;
        }

        public abstract void ShowExam();

        protected virtual void OnExamStarted()
        {
            string name = Subject == null ? "" : Subject.SubjectName;
            ExamStarted?.Invoke(this, new ExamEventArgs(this, $"the {name} exam is starting now ({TimeByMinute} minutes)."));
        }

        public object Clone()
        {
            Exam copy = (Exam)MemberwiseClone();
            copy.QuestionAnswerDictionary = new Dictionary<Question, Answer>(QuestionAnswerDictionary);
            copy.ExamStarted = null; // the copy has no subscribers
            return copy;
        }

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return TimeByMinute.CompareTo(other.TimeByMinute);
        }

        public override string ToString()
        {
            return $"{GetType().Name} - Subject: {Subject?.SubjectName}, Time: {TimeByMinute} min, Questions: {NumberOfQuestions}, Mode: {Mode}";
        }

        public override bool Equals(object obj)
        {
            return obj is Exam other
                && GetType() == other.GetType()
                && TimeByMinute == other.TimeByMinute
                && NumberOfQuestions == other.NumberOfQuestions
                && ReferenceEquals(Subject, other.Subject);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), TimeByMinute, NumberOfQuestions, Subject?.SubjectId);
        }
    }
}
