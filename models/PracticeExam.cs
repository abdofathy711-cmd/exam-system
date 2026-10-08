using System;

namespace exam_system.models
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int timeByMinute, Subject subject, QuestionList questions)
            : base(timeByMinute, subject, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine($"=== Practice Exam: {Subject.SubjectName} ===");
            Console.WriteLine($"Time: {TimeByMinute} minutes | Questions: {NumberOfQuestions}");
            Console.WriteLine();

            foreach (Question q in Questions)
            {
                q.DisplayQuestion();
                Console.WriteLine();
            }

            Console.Write("Press Enter when you finish the exam...");
            Console.ReadLine();

            // Practice exam shows the right answers after finishing
            Console.WriteLine();
            Console.WriteLine("--- Correct Answers ---");
            foreach (Question q in Questions)
                Console.WriteLine($"[{q.Header}] {q.GetCorrectAnswerText()}");
        }
    }
}
