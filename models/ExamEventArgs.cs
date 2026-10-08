using System;

namespace exam_system.models
{
    internal class ExamEventArgs : EventArgs
    {
        public Exam Exam { get; set; }
        public string Message { get; set; }

        public ExamEventArgs(string message) : this(null, message)
        {
        }

        public ExamEventArgs(Exam exam, string message)
        {
            Exam = exam;
            Message = message;
        }
    }
}
