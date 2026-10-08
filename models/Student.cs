using System;

namespace exam_system.models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }

        public Student(string fullName) : this(0, fullName)
        {
        }

        public Student(int studentId, string fullName)
        {
            StudentId = studentId;
            FullName = fullName;
        }

        // event handler (matches ExamStartedHandler)
        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"[Notification] Student {FullName}: {e.Message}");
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
