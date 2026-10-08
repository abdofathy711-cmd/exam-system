using System;

namespace exam_system.models
{
    internal class FinalExam : Exam
    {
        public FinalExam(int timeByMinute, Subject subject, QuestionList questions)
            : base(timeByMinute, subject, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine($"=== Final Exam: {Subject.SubjectName} ===");
            Console.WriteLine($"Time: {TimeByMinute} minutes | Questions: {NumberOfQuestions}");
            Console.WriteLine();

            // Final exam shows only the questions and their answers
            foreach (Question q in Questions)
            {
                q.DisplayQuestion();
                Console.WriteLine();
            }
        }
    }
}
